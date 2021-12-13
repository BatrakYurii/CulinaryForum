using AutoMapper;
using System.IO;
using System.Text;
using Forum.Api.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Forum.Api.Data.Entities;
using Forum.Api.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        private readonly UserManager<User> _userManager;
        private readonly IImagesService _imagesService;
        public ImagesController(IMapper mapper, IWebHostEnvironment webHost, UserManager<User> userManager)
        {
            _mapper = mapper;
            _webHost = webHost;
            _userManager = userManager;
        }

        [Authorize(Roles = "Manager, User")]
        [Route("UserIcon")]
        [HttpPost]
        public async Task AddOrReplaceProfileImage([FromForm]IFormFile imgFile)
        {
            if (imgFile != null)
            {
                var imgExt = Path.GetExtension(imgFile.FileName);
                if (!(imgExt == ".jpg" || imgExt == ".png"))
                {
                    throw new BadImageFormatException("Incorrect file format");
                }

                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByIdAsync(userId);

                var imagePath = Path.Combine(_webHost.WebRootPath, user.AvatarImage);

                if(user.AvatarImage != null)
                {
                    System.IO.File.Delete(imagePath);
                }               

                var imageName = await UploadImage(imgFile, Path.Combine(_webHost.WebRootPath, "profileImages"));
                await _imagesService.AddProfileImage(Path.Combine("profileImages", imageName), user.Id);
            }
            else
            {
                return;
            }
        }

        [Route("articles/{articleId}")]
        [HttpPost]
        public async Task AddArticlesImages([FromForm] IFormFileCollection images, [FromRoute] int articleId, string articleUserId )
        {
            if (images.Count != 0) 
            {
                foreach(var image in images)
                {
                    var imgExt = Path.GetExtension(image.FileName);
                    if (!(imgExt == ".jpg" || imgExt == ".png"))
                    {
                        throw new BadImageFormatException("Incorrect file format");
                    }
                }

                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                if (userId != articleUserId)
                    throw new BadHttpRequestException("You have not enough rules");

                var pathList = new List<string>();
                foreach (var image in images)
                {
                    var imageName = await UploadImage(image, Path.Combine(_webHost.WebRootPath, "articleImages"));
                    pathList.Add(Path.Combine("articleImages", imageName));
                }
                await _imagesService.AddArticlesImages(pathList, articleId);

            }
            else
            {
                return;
            }
        }

        private async Task<string> UploadImage (IFormFile image, string path)
        {
            using var readStream = image.OpenReadStream();
            var fileExtension = Path.GetExtension(image.FileName);

            var newFileName = $"{Guid.NewGuid()}{fileExtension}";
            var fullPath = Path.Combine(path, newFileName);
            var buffer = new byte[readStream.Length];

            await readStream.ReadAsync(buffer, 0, buffer.Length);
            await System.IO.File.WriteAllBytesAsync(fullPath, buffer);
            return newFileName;          
        }
        
    }
}
