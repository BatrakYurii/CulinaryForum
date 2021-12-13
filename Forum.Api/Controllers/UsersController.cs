using AutoMapper;
using Forum.Api.Auth.Models;
using Forum.Api.Data.Entities;
using Forum.Api.Models.PutModels;
using Forum.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [Route("Edit")]
        public async Task<UserViewModel> UpdateUser([FromBody] UserPutModel userPutModel)
        {
            if (!ModelState.IsValid || userPutModel == null)
            {
                throw new BadHttpRequestException("Not valid model");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user =  await _userManager.FindByIdAsync(userId);

            if (!string.IsNullOrEmpty(userPutModel.Email))
            {
                if(userPutModel.Email != user.Email)
                {
                    var updatedUser = await _userManager.SetEmailAsync(user, userPutModel.Email);
                    if (!updatedUser.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occured setting email for user with ID {userId}");
                    }
                }
            }
            else
            {
                throw new BadHttpRequestException("Email is empty");
            }        
              
            

            if (!string.IsNullOrEmpty(userPutModel.UserName))
            {
                if (userPutModel.UserName != user.UserName)
                {
                    var updatedUser = await _userManager.SetUserNameAsync(user, userPutModel.UserName);
                }
            }
            else
            {
                throw new BadHttpRequestException("UserName is empty");
            }

            if (!string.IsNullOrEmpty(userPutModel.NewPassword)
                && !string.IsNullOrEmpty(userPutModel.OldPassword))
            {
                if (await _userManager.CheckPasswordAsync(user, userPutModel.OldPassword))
                {
                    var updatedUser = await _userManager.ChangePasswordAsync(user, userPutModel.OldPassword, userPutModel.NewPassword);
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

            return _mapper.Map<UserViewModel>(user);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<UserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return _mapper.Map<UserViewModel>(user);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete]
        public async Task Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);         
            
            await _userManager.DeleteAsync(user);
            
            
        }

    }
}
