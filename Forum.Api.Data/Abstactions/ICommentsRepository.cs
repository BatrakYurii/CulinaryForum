
using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Abstactions
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> Get();
        Task<Comment> Get(int id);
        Task<Comment> Update(int id, Comment comment);
        Task<Comment> Create(Comment comment);
        Task Delete(int id);
    }
}
