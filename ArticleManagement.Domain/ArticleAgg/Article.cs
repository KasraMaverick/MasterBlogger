using _0_Framework.Domain;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.CommentAgg;

namespace ArticleManagement.Domain.ArticleAgg
{
    public class Article : DomainBase<long>
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        protected Article()
        {   
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            Image = image;
            IsDeleted = false;
            Comments = new List<Comment>();
        }
        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            Image = image;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
        public static void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
            if (articleCategoryId == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
