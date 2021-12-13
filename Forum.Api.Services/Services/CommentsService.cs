using AutoMapper;
using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }
        public async Task<CommentModel> Create(CommentModel commentModel)
        {
            var entity = _mapper.Map<Comment>(commentModel);

            await _commentsRepository.Create(entity);
            commentModel.Id = entity.Id;

            return commentModel;
        }

        public async Task Delete(int id, string UserId)
        {
            await _commentsRepository.Delete(id, UserId);

        }

        public async Task<IEnumerable<CommentModel>> Get()
        {
            var comments = await _commentsRepository.Get();
            var commentsModel = new List<CommentModel>();
            foreach (var comment in comments)
            {
                commentsModel.Add(_mapper.Map<CommentModel>(comment));
            }
            return commentsModel;
        }

        public async Task<CommentModel> Get(int id)
        {
            var model = await _commentsRepository.Get(id);
            var commentModel = _mapper.Map<CommentModel>(model);
            return commentModel;
        }

        public async Task<CommentModel> Update(int id, CommentModel commentModel, string userId)
        {
            var entity = _mapper.Map<Comment>(commentModel);
            await _commentsRepository.Update(id, entity, userId);
            commentModel.Id = entity.Id;

            return commentModel;
        }
    }
}
