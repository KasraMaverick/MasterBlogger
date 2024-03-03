namespace ArticleManagement.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSaveComment(Comment entity);
    }
}
