using ArticleManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.Presentation.MVCCore.Areas.Admin.Pages.CommentManagement
{
    public class CommentListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }

        private readonly ICommentApplication _commentApplication;
        public CommentListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }
        public void OnGet()
        {
            Comments = _commentApplication.GetCommentList();
        }
    }
}
