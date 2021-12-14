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
        public int CuisineNationalityId { get; set; }
        public bool IsVegan { get; set; }
        public DateTime CookingTime { get; set; } 
        //public CookingTimePostModel CookingTime { get; set; }
        public ICollection<CategoryPostModel> Categories { get; set; }
        //public ICollection<string> Images { get; set; }

    }
}
