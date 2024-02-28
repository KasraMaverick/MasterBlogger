using ArticleManagement.Application.Contracts.ArticleCategory;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.ArticleCategoryAgg.Services;
using System.Globalization;

namespace ArticleManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.GetArticleCategory(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
        }

        public List<ArticleCategoryViewModel> GetAllArticleCategories()
        {
            var articleCategories = _articleCategoryRepository.GetAllArticleCategories();
            var result = new List<ArticleCategoryViewModel>();
            foreach(var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreatedDate = articleCategory.CreatedDate.ToString(CultureInfo.InvariantCulture),
                });
            }
            return result;
        }

        public RenameArticleCategory GetArticleCategory(long id)
        {
            var articleCategory = _articleCategoryRepository.GetArticleCategory(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.GetArticleCategory(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetArticleCategory(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }
    }
}
