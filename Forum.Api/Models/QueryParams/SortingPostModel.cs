using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.QueryParams
{
    public class SortingPostModel
    {
        public SortDirectionEnum? SortDirection { get; set; }
        //public SortFieldEnum? SortItem { get; set; }
        //public bool IsSortingSelected { get; set; }
    }
}
