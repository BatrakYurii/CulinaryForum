using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Forum.Api.Data.Parameters;
using Microsoft.AspNetCore.Mvc;
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
            article.CuisineNationality = _ctx.CuisineNationalities.FirstOrDefault(x => x.Id == article.CuisineNationalityId);
            _ctx.Articles.Add(article);   
            
             await _ctx.SaveChangesAsync();      

        }

        public async Task Delete(int id)
        {
            var baseArticle = await _ctx.Articles.FirstOrDefaultAsync(x => x.Id == id);
            //if (baseArticle.UserId != userId)
            //{
            //    return;
            //}
            _ctx.Articles.Remove(baseArticle);
            _ctx.Comments.RemoveRange(_ctx.Comments.Where(c => c.ArticleId == id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> Get(Pagination pagination, Sorting sorting, Filter filter)
        {
            IQueryable<Article> articles = _ctx.Articles;

            if(filter.Predicates.Count != 0)
            foreach (var predicate in filter.Predicates)
                articles = articles.Where(predicate);

            if (sorting != null)
            {
                if (!sorting.IsAscending)
                {
                    articles = articles.OrderByDescending(sorting.SortingExpression);
                }
                else
                {
                    articles = articles.OrderBy(sorting.SortingExpression);
                }
            }

            var skip = (pagination.Page - 1) * pagination.PageSize;
            var take = pagination.PageSize;

            return await articles
                .Skip(skip)
                .Take(take)
                .Include(a => a.User)
                .Include(x => x.CuisineNationality)
                .Include(x => x.Images)
                .Include(x => x.Comments)
                .Include(x => x.ArticlesCategories)
                    .ThenInclude(x => x.Category)
                    .AsNoTracking().ToListAsync();
            
        }

        public async Task<Article> Get(int id)
        {
            var article = await _ctx.Articles.Include(x => x.Comments).Include(x => x.User).Include(x => x.Images).Include(x => x.ArticlesCategories).ThenInclude(x => x.Category).AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return article;
        }

        public async Task Update(int id, Article article)
        {
            var baseArticle = await _ctx.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (baseArticle.UserId != article.UserId)
            {
                return;
            }
            _ctx.ArticlesCategories.RemoveRange(_ctx.ArticlesCategories.Where(c => c.ArticleId == article.Id));
            baseArticle.Title = article.Title;
            baseArticle.Content = article.Content;
            baseArticle.Images = article.Images;
            baseArticle.ArticlesCategories = baseArticle.ArticlesCategories;
            baseArticle.CuisineNationalityId = article.CuisineNationalityId;
            await _ctx.SaveChangesAsync();
            return;
 
        }
    }
}
