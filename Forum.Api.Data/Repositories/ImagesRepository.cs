using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private ForumContext _ctx;

        public ImagesRepository(ForumContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddArticleImages(IEnumerable<string> pathList, int articleId)
        {
            var article = await _ctx.Articles.FindAsync(articleId);
            var images = pathList.Select(p => new Image { Path = p });
            
            if (article.Images == null)
            {
                article.Images = new List<Image>();
            }


            foreach (var item in images)
            {
                article.Images.Add(item);
            }
            await _ctx.SaveChangesAsync();
        }

        public async Task AddProfileImage(string path, string userId)
        {
            var user = await _ctx.Users.FindAsync(userId);
            user.AvatarImage = path;
            await _ctx.SaveChangesAsync();
        }
    }
}
