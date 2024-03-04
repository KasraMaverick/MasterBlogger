namespace ArticleManagement.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        public void CheckIfRecordAlreadyExists(string title);

    }
}
