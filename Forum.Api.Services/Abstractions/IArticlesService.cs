using Forum.Api.Services.Models;
using Forum.Api.Services.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Abstractions
{
    public interface IArticlesService
    {
        public Task<IEnumerable<ArticleModel>> Get(PаginationModel paginationModel, SortingModel sortingModel, FiltersModel filtersModel);
        public Task<ArticleModel> Get(int id);
        public Task<ArticleModel> Update(int id, ArticleModel articleModel);
        public Task<ArticleModel> Create(ArticleModel articleModel);
        public Task Delete(int id);
    }
}
