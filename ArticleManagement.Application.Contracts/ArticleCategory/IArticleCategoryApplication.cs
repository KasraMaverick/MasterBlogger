namespace ArticleManagement.Application.Contracts.ArticleCategory
{
    public interface  IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory GetArticleCategory(long id);
        List<ArticleCategoryViewModel> GetAllArticleCategories();

    }
}
