using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public ArticleModel Article{ get; set; }
        public string UserId { get; set; }
        public UserModel User{ get; set; }
    }
}
