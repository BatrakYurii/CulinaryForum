using Forum.Api.Data.Abstactions;
using Forum.Api.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Services
{
    public class ImagesService : IImagesService
    {
        private readonly IImagesRepository _imagesRepository;
        public ImagesService(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }
        public async Task AddProfileImage(string path, string userId)
        {
            await _imagesRepository.AddProfileImage(path, userId);
        }

        public async Task AddArticlesImages(IEnumerable<string> pathList, int articleId)
        {
            await _imagesRepository.AddArticleImages(pathList, articleId);
        }

        
    }
}
