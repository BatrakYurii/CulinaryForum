
using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Abstactions
{
    public interface IArticlesRepository
    {
        Task<IEnumerable<Article>> Get();
        Task<Article> Get(int id);
        Task<Article> Update(int id, Article article);
        Task Create(Article article);
        Task Delete(int id);
    }
}
