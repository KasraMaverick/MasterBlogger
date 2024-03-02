namespace ArticleManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAllArticles();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(long id); 

    }
}
