using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.QueryParams
{
    public class PaginationViewModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? TotalPages { get; set; }
    }
}
