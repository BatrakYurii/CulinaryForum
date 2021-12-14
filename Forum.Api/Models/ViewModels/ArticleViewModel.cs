using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Models.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
        public int CuisineNationalityId { get; set; }
        public bool IsVegan { get; set; }
        public string CookingTime{get;set;}
        public CuisineNationalityViewModel CuisineNationality { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<string> Images { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
