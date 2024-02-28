using ArticleManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.ArticleManagement
{
    public class ArticleListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        private readonly IArticleApplication _articleApplication;
        public ArticleListModel()
        {
            Articles = _articleApplication.GetAllArticles();
        }
        public void OnGet()
        {
        }
    }
}
