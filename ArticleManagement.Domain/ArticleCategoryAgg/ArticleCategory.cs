using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleCategoryAgg.Services;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get;private set; }   
        public bool IsDeleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory() 
        {
        }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckIfRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            Articles = new List<Article>();
        }
        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
        void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
