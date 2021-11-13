namespace Forum.Api.Data.Entities
{
    public class ArticlesCategories
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int CaregoryId { get; set; }
        public Category Category { get; set; }
    }
}
