using AutoMapper;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.ViewModels;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Controllers
{
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

        [HttpPost]
        public async Task<CommentViewModel> Create(CommentPostModel model)
        {
            var createModel = _mapper.Map<CommentModel>(model);

            var createdModel = await _commentsService.Create(createModel);

            return _mapper.Map<CommentViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CommentViewModel> GetById(int id)
        {
            var userModel = await _commentsService.Get(id);

            return _mapper.Map<CommentViewModel>(userModel);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _commentsService.Delete(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CommentViewModel>> Get()
        {
            var commentsViewModel = await _commentsService.Get();
            var commentsModel = new List<CommentViewModel>();
            foreach (var comment in commentsViewModel)
            {
                commentsModel.Add(_mapper.Map<CommentViewModel>(comment));
            }
            return commentsModel;

        }

        [HttpPut]
        public async Task<CommentViewModel> Update(int id, CommentPostModel commentPostModel)
        {
            var createModel = _mapper.Map<CommentModel>(commentPostModel);

            var createdModel = await _commentsService.Update(id, createModel);

            return _mapper.Map<CommentViewModel>(createdModel);
        }
    }
}
