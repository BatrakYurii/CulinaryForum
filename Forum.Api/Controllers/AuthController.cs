using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Api.Auth.Conficuration;
using Forum.Api.Auth.Models;
using Forum.Api.Data.Entities;
using Forum.Api.Models.PostModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Forum.Api.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtBearerTokenSettings jwtBearerTokenSettings;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        public AuthController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, IMapper mapper,
            UserManager<User> userManager)
        {
            this.jwtBearerTokenSettings = jwtTokenOptions.Value;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserPostModel userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }
            //var identityUser = mapper.Map<User>(userDetails);
            var identityUser = new User() { UserName = userDetails.UserName, Email = userDetails.Email, RegisterDate = DateTime.UtcNow };
            var result = await userManager.CreateAsync(identityUser, userDetails.Password);
            var roleName = RolesEnum.User.GetEnumDescription();

            await userManager.AddToRoleAsync(identityUser, roleName);


            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (var error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            User identityUser;

            if (!ModelState.IsValid
                || request == null
                || (identityUser = await ValidateUserAsync(request)) == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }
            var roles = await userManager.GetRolesAsync(identityUser);
            var token = GenerateToken(identityUser, roles);

            return Ok(
                new
                {
                    AccessToken = token
                });
        }

        private string GenerateToken(User identityUser, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email),
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                    new Claim(ClaimTypes.Role, string.Join(',', roles))
                }),

                Expires = DateTime.Now.AddSeconds(jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtBearerTokenSettings.Audience,
                Issuer = jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        private async Task<User> ValidateUserAsync(Login credentials)
        {
            var identityUser = await userManager.FindByEmailAsync(credentials.Email);

            if (identityUser != null)
            {
                var result = userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }


    }
}