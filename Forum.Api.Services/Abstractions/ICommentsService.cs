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
        public Task<IEnumerable<CommentModel>> Get();
        public Task<CommentModel> Get(int id);
        public Task<CommentModel> Update(int id, CommentModel commentModel);
        public Task<CommentModel> Create(CommentModel commentModel);
        public Task Delete(int id);
    }
}
