using AutoMapper;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.ViewModels;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;

        public ArticlesController(IArticlesService articleService, IMapper mapper)
        {
            _articlesService = articleService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IEnumerable<ArticleViewModel>> Get()
        {
            var articlesViewModel =  await _articlesService.Get();
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

        [Authorize(Roles = "User")]
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

        [Authorize(Roles = "User")]
        [HttpPut]
        [Route ("Change")]
        public async Task<ArticleViewModel> Update(int id, ArticlePostModel articlePostModel)
        {
            var createModel = _mapper.Map<ArticleModel>(articlePostModel);

            var createdModel = await _articlesService.Update(id, createModel);

            return _mapper.Map<ArticleViewModel>(createdModel);
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _articlesService.Delete(id);
        }
    }
}
