using ArticleManagement.Application.Contracts.ArticleCategory;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System.Globalization;

namespace ArticleManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
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
    }
}
