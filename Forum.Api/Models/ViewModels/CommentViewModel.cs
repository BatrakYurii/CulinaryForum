using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ArticleViewModel Article { get; set; }
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
