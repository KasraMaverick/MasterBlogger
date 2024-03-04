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
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
        }

        public List<ArticleCategoryViewModel> GetAllArticleCategories()
        {
            var articleCategories = _articleCategoryRepository.GetList();
            return articleCategories.Select(articleCategories => new ArticleCategoryViewModel
            {
                Id = articleCategories.Id, Title = articleCategories.Title, IsDeleted = articleCategories.IsDeleted,
                CreatedDate = articleCategories.CreatedDate.ToString(CultureInfo.InvariantCulture),
            }).OrderByDescending(x => x.Id).ToList();
        }

        public RenameArticleCategory GetArticleCategory(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            
        }
    }
}
