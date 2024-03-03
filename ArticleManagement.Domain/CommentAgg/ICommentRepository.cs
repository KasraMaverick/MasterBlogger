using ArticleManagement.Application.Contracts.Comment;

namespace ArticleManagement.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSaveComment(Comment entity);
        List<CommentViewModel> GetCommentList();

    }
}
