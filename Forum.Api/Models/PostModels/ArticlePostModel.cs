using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.PostModels
{
    public class ArticlePostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int CuisineNationalityId { get; set; }
        public CuisineNationality CuisineNationality { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
