using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
