using Forum.Api.Data.Entities;
using System;
using System.Linq.Expressions;

namespace Forum.Api.Data.Parameters
{
    public class Sorting
    {
        public bool IsAscending { get; set; }
        public Expression<Func<Article, object>> SortingExpression{ get; set; }
    }
}
