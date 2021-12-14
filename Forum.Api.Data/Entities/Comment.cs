using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Forum.Api.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
