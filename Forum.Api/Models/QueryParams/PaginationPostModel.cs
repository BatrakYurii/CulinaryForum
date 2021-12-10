using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.QueryParams
{
    public class PaginationPostModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
