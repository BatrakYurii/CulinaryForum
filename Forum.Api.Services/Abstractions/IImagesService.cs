using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Abstractions
{
    public interface IImagesService
    {
        public Task AddProfileImage(string path, string userId);
        public Task AddArticlesImages(IEnumerable<string> pathList, int articleId);
    }
}
