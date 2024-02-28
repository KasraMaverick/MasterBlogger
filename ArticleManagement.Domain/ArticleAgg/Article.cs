using ArticleManagement.Domain.ArticleCategoryAgg;

namespace ArticleManagement.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {   
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            Image = image;
            IsDeleted = false;
            CreatedDate = DateTime.Now; 
        }
    }
}
