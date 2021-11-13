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
        public UserPostModel User { get; set; }
    }
}
