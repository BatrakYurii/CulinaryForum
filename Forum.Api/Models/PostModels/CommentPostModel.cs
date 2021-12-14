using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.PostModels
{
    public class CommentPostModel
    {
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
