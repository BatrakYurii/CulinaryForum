using AutoMapper;
using Forum.Api.Auth.Conficuration;
using Forum.Api.Auth.Models;
using Forum.Api.Data.Entities;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.PutModels;
using Forum.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ManagersController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, IMapper mapper,
            UserManager<User> userManager)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] ManagerPostModel managerDetails)
        {
            if (!ModelState.IsValid || managerDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }
            //var identityUser = mapper.Map<User>(managerDetails);
            var identityUser = new User() { UserName = managerDetails.UserName, Email = managerDetails.Email, RegisterDate = DateTime.UtcNow };
            var result = await _userManager.CreateAsync(identityUser, managerDetails.Password);
            var roleName = RolesEnum.Manager.GetEnumDescription();

            await _userManager.AddToRoleAsync(identityUser, roleName);


            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (var error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "Manager Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        [Route("Edit")]
        public async Task<ManagerViewModel> UpdateUser([FromBody] ManagerPutModel managerPutModel)
        {
            if (!ModelState.IsValid || managerPutModel == null)
            {
                throw new BadHttpRequestException("Model is not valid");
            }
            var managerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var manager = await _userManager.FindByIdAsync(managerId);

            if (!string.IsNullOrEmpty(managerPutModel.Email))
            {
                if (managerPutModel.Email != manager.Email)
                {
                    var updatedUser = await _userManager.SetEmailAsync(manager, managerPutModel.Email);
                    if (!updatedUser.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occured setting email for user with ID {managerId}");
                    }
                }
            }
            else
            {
                throw new BadHttpRequestException("Email is empty");
            }



            if (!string.IsNullOrEmpty(managerPutModel.UserName))
            {
                if (managerPutModel.UserName != manager.UserName)
                {
                    var updatedUser = await _userManager.SetUserNameAsync(manager, managerPutModel.UserName);
                }
            }
            else
            {
                throw new BadHttpRequestException("UserName is empty");
            }

            if (!string.IsNullOrEmpty(managerPutModel.NewPassword)
                && !string.IsNullOrEmpty(managerPutModel.OldPassword))
            {
                if (await _userManager.CheckPasswordAsync(manager, managerPutModel.OldPassword))
                {
                    var updatedUser = await _userManager.ChangePasswordAsync(manager, managerPutModel.OldPassword, managerPutModel.NewPassword);
                    if (!updatedUser.Succeeded)
                    {
                        throw new BadHttpRequestException(string.Join(Environment.NewLine, updatedUser.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Old password is incorrect");
                }
            }
            else
            {
                throw new BadHttpRequestException("Old password or new password is empty");
            }

            return _mapper.Map<ManagerViewModel>(manager);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{managerId}")]
        public async Task Delete([FromRoute]string managerId)
        {
            var user = await _userManager.FindByIdAsync(managerId);

            var role = RolesEnum.User.GetEnumDescription();

            var isManager = await _userManager.IsInRoleAsync(user, role);

            if (isManager)
            {
                await _userManager.DeleteAsync(user);
            }
            else
            {
                throw new BadHttpRequestException("I have not enough rules");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        [Route("{managerId}")]
        public async Task<ManagerViewModel> Get(string managerId)
        {
            var user = await _userManager.FindByIdAsync(managerId);
            return _mapper.Map<ManagerViewModel>(user);
        }

    }
}
