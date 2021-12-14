using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Abstactions
{
    public interface IImagesRepository
    {
        public Task AddProfileImage(string path, string userId);
        public Task AddArticleImages(IEnumerable<string> pathList, int articleId);
    }
}
