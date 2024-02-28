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
        public List<ArticleViewModel> GetAllArticles()
        {
            return _articleRepository.GetArticleViewModels();
        }
    }
}
