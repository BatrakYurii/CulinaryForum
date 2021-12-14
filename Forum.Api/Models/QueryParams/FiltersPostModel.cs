using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.QueryParams
{
    public class FiltersPostModel
    {
        public int? NationalityId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsVegan { get; set; }
        public DateTime? CreateDateFrom { get; set; }
        public DateTime? CreateDateTo { get; set; }
    }
}
