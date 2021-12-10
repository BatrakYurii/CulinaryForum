using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Services.Models.Parameters
{
    public class PаginationModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int PagesCount { get; set; }
    }
}
