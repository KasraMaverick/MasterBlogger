using ArticleManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class ArticleCategoryListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategoryListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetAllArticleCategories();
        }
        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./ArticleCategoryList");

        }
        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("./ArticleCategoryList");
        }
    }
}
