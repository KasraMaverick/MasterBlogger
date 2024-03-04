using ArticleManagement.Domain.ArticleCategoryAgg.Exceptions;

namespace ArticleManagement.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void CheckIfRecordAlreadyExists(string title)
        {
            if (_articleRepository.Exists(x => x.Title == title))
            {
                throw new DuplicatedRecordException();
            }
        }
    }
}
