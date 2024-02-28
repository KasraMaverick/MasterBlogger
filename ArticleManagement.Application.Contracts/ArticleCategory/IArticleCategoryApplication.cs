namespace ArticleManagement.Application.Contracts.ArticleCategory
{
    public interface  IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        void Remove(long id);   
        void Activate(long id); 
        RenameArticleCategory GetArticleCategory(long id);
        List<ArticleCategoryViewModel> GetAllArticleCategories();

    }
}
