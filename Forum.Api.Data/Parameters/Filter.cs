using Forum.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Parameters
{
    public class Filter
    {
        public List<Expression<Func<Article, bool>>> Predicates { get; set; }
    }
}
