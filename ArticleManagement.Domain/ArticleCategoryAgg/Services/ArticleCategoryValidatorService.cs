using ArticleManagement.Domain.ArticleCategoryAgg.Exceptions;

namespace ArticleManagement.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
        public void CheckIfRecordAlreadyExists(string title)
        {
            if(_articleCategoryRepository.Exists(x => x.Title == title))
            {
                throw new DuplicatedRecordException("This record already exists in the database");
            }
        }
    }
}
