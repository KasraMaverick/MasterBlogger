using ArticleManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class CreateArticleCategoryModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateArticleCategoryModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;       
        }
        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _articleCategoryApplication.Create(command);
            return RedirectToPage("./ArticleCategoryList");
        }
    }
}
