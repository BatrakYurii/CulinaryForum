﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title {get;set;}
        public IEnumerable<ArticlesCategories> ArticlesCategories { get; set; }
    }
}
