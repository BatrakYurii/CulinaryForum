using Forum.Api.Data.Entities;
using Forum.Api.Data.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Api.Data.Abstactions
{
    public interface IArticlesRepository
    {
        Task<IEnumerable<Article>> Get(Pagination pagination, Sorting sorting, Filter filter);
        Task<Article> Get(int id);
        Task Update(int id, Article article);
        Task Create(Article article);
        Task Delete(int id);
    }
}
