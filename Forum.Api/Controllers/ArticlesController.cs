using AutoMapper;
using Forum.Api.Data.Entities;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.QueryParams;
using Forum.Api.Models.ViewModels;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Models;
using Forum.Api.Services.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ArticlesController(IArticlesService articleService, IMapper mapper, UserManager<User> userManager)
        {
            _articlesService = articleService;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<ArticleViewModel>> Get([FromQuery] PaginationPostModel paginationPostModel,
                                                             [FromQuery] SortingPostModel sortingPostModel,
                                                             [FromQuery] FiltersPostModel filtersPostModel)
        {
            var paginationModel = _mapper.Map<PаginationModel>(paginationPostModel);
            var sortingModel = _mapper.Map<SortingModel>(sortingPostModel);
            var filtersModel = _mapper.Map<FiltersModel>(filtersPostModel);

            var articlesViewModel = await _articlesService.Get(paginationModel, sortingModel, filtersModel);
            var articlesModel = new List<ArticleViewModel>();
            foreach (var article in articlesViewModel)
            {
                articlesModel.Add(_mapper.Map<ArticleViewModel>(article));
            }
            return articlesModel;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ArticleViewModel> Get(int id)
        {
            var articleModel = await _articlesService.Get(id);

            return _mapper.Map<ArticleViewModel>(articleModel);
        }

        [Authorize]
        [HttpPost]
        [Route("New")]
        public async Task<ArticleViewModel> Greate(ArticlePostModel articlePostModel)
        {
            var createModel = _mapper.Map<ArticleModel>(articlePostModel);
            createModel.CreateDate = DateTime.UtcNow;
            createModel.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var createdModel = await _articlesService.Create(createModel);

            return _mapper.Map<ArticleViewModel>(createdModel);
        }

        [Authorize]
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ArticleViewModel> Update([FromRoute]int id, [FromBody]ArticlePostModel articlePostModel)
        {
            var createModel = _mapper.Map<ArticleModel>(articlePostModel);

            createModel.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var createdModel = await _articlesService.Update(id, createModel);

            return _mapper.Map<ArticleViewModel>(createdModel);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task Delete([FromRoute]int id)
        {

            //var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await _articlesService.Delete(id);
        }
    }
}
