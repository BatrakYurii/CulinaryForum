using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CuisineNationalityId { get; set; }
        public CuisineNationalityModel CuisineNationality { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
