namespace ArticleManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string shortDescription { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long ArticleCategoryId { get; set; }

    }
}
