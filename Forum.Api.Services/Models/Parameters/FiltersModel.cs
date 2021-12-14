using Common.Enums;
using Forum.Api.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Models.Parameters
{
    public class FiltersModel
    {
        public int? NationalityId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsVegan { get; set; }
        public DateTime? CreateDateFrom { get; set; }
        public DateTime? CreateDateTo { get; set; }
    }
}
