using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.ArticleManagement
{
    public class EditArticleModel : PageModel
    {
        [BindProperty]
        public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }

        private readonly IArticleApplication _articleApplicaton;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditArticleModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplicaton = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            Article = _articleApplicaton.Get(id);
            ArticleCategories = _articleCategoryApplication.GetAllArticleCategories().
                Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();

        }
        public RedirectToPageResult OnPost()
        {
            _articleApplicaton.Edit(Article);
            return RedirectToPage("./ArticleList");
        }
        
    }
}
