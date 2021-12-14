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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsService commentsService, IMapper mapper)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }

        [Route("New")]
        [HttpPost]
        public async Task<CommentViewModel> Create(CommentPostModel model)
        {
            var createModel = _mapper.Map<CommentModel>(model);
            createModel.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var createdModel = await _commentsService.Create(createModel);

            return _mapper.Map<CommentViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CommentViewModel> GetById(int id)
        {
            var userModel = await _commentsService.GetById(id);

            return _mapper.Map<CommentViewModel>(userModel);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await _commentsService.Delete(id, userId);
        }

        [HttpGet]
        [Route("ForArticles/{id}")]
        public async Task<IEnumerable<CommentViewModel>> Get([FromRoute] int id)
        {
            var commentsViewModel = await _commentsService.Get(id);
            var commentsModel = new List<CommentViewModel>();
            foreach (var comment in commentsViewModel)
            {
                commentsModel.Add(_mapper.Map<CommentViewModel>(comment));
            }
            return commentsModel;

        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<CommentViewModel> Update(int id, CommentPostModel commentPostModel)
        {
            var createModel = _mapper.Map<CommentModel>(commentPostModel);

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; 

            var createdModel = await _commentsService.Update(id, createModel, userId);

            return _mapper.Map<CommentViewModel>(createdModel);
        }
    }
}
