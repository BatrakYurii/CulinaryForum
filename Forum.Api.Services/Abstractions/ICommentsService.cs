using Forum.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Abstractions
{
    public interface ICommentsService
    {
        public Task<IEnumerable<CommentModel>> Get(int id);
        public Task<CommentModel> GetById(int id);
        public Task<CommentModel> Update(int id, CommentModel comment, string userId);
        public Task<CommentModel> Create(CommentModel commentModel);
        public Task Delete(int id, string UserId);
    }
}
