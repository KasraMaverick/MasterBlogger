namespace ArticleManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void AddComment(AddComment command);
        List<CommentViewModel> GetCommentList();
        void Confirm(long id);
        void Cancel(long id);

    }
}
