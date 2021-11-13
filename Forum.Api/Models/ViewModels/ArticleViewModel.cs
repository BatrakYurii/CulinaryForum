using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string NickName { get; set; }
        public UserViewModel User { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
