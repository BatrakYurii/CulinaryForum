using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ForumContext _ctx;

        public ArticlesRepository(ForumContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Article article)
        {
            _ctx.Articles.Add(article);
             await _ctx.SaveChangesAsync();           

        }

        public async Task Delete(int id)
        {
            var article = await _ctx.Articles
                .FirstOrDefaultAsync(x => x.Id == id);
            _ctx.Articles.Remove(article);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> Get()
        {
            var articles = await _ctx.Articles.Include(a => a.User).Include(a => a.Comments).AsNoTracking().ToListAsync();
            return articles;
        }

        public async Task<Article> Get(int id)
        {
            var article = await _ctx.Articles.Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return article;
        }

        public async Task<Article> Update(int id, Article article)
        {
            var deleteArticle = await _ctx.Articles
                .FirstOrDefaultAsync(x => x.Id == id);
            _ctx.Articles.Remove(deleteArticle);
            article.Id = id;
            _ctx.Articles.Add(article);
            await _ctx.SaveChangesAsync();
            return article;
        }
    }
}
