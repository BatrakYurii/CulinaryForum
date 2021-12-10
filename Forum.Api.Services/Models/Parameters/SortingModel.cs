using System;
using System.Collections.Generic;
using Common.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Models.Parameters
{
    public class SortingModel
    {
        public SortDirectionEnum? SortDirection { get; set; }
        //public SortFieldEnum? SortItem { get; set; }
        //public bool IsSortingSelected { get; set; }
    }
}
