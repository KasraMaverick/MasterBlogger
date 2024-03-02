using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Domain.ArticleAgg;

namespace ArticleManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.shortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);

        }

        public List<ArticleViewModel> GetAllArticles()
        {
            return _articleRepository.GetArticleViewModels();
        }
    }
}
