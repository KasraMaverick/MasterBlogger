namespace ArticleManagement.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckIfRecordAlreadyExists(string title);
    }
}
