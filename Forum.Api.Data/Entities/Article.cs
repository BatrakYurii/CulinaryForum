using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CuisineNationalityId { get; set; }
        public bool IsVegan { get; set; }
        public DateTime CookingTime { get; set; }
        public CuisineNationality CuisineNationality { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Image> Images { get; set; }
        public IEnumerable<ArticlesCategories> ArticlesCategories { get; set; }
    }
}
