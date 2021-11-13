using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ArticlId { get; set; }
        public Article Article { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
