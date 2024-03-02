namespace ArticleManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAllArticles();
        void Create(CreateArticle command);

    }
}
