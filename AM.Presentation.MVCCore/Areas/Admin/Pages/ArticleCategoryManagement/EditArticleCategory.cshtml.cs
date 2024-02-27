using ArticleManagement.Application;
using ArticleManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class EditArticleCategoryModel : PageModel
    {
        [BindProperty]  
        public RenameArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditArticleCategoryModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetArticleCategory(id);
        }
    }
}
