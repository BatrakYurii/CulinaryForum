using AutoMapper;
using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Forum.Api.Data.Parameters;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Models;
using Forum.Api.Services.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IMapper _mapper;

        public ArticlesService(IArticlesRepository articlesRepository, IMapper mapper)
        {
            _articlesRepository = articlesRepository;
            _mapper = mapper;
        }

        public async Task<ArticleModel> Create(ArticleModel articleModel)
        {
            var entity = _mapper.Map<Article>(articleModel);
            articleModel.CreateDate = DateTime.UtcNow;

            await _articlesRepository.Create(entity);
            articleModel.Id = entity.Id;

            return articleModel;
        }

        public async Task Delete(int id)
        {
            await _articlesRepository.Delete(id);
        }

        public async Task<IEnumerable<ArticleModel>> Get(PаginationModel paginationModel, SortingModel sortingModel, FiltersModel filtersModel)
        {
           

            if(paginationModel.Page == null || paginationModel.PageSize == null)
            {
                paginationModel.Page = 1;
                paginationModel.PageSize = 5;

            }

            var pagination = _mapper.Map<Pagination>(paginationModel);
            var sorting = _mapper.Map<Sorting>(sortingModel);
            var filter = _mapper.Map<Filter>(filtersModel);

            var articles = await _articlesRepository.Get(pagination, sorting, filter);
            var articlesModel = new List<ArticleModel>();
            foreach (var article in articles)
            {
                articlesModel.Add(_mapper.Map<ArticleModel>(article));
            }
            return articlesModel;

        }

        public async Task<ArticleModel> Get(int id)
        {
            var model = await _articlesRepository.Get(id);
            var articleModel = _mapper.Map<ArticleModel>(model);
            return articleModel;
        }

        public async Task<ArticleModel> Update(int id, ArticleModel articleModel)
        {
            var entity = _mapper.Map<Article>(articleModel);
            await _articlesRepository.Update(id, entity);
            articleModel.Id = entity.Id;

            return articleModel;
        }
    }
}
