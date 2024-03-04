using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contracts.Comment;

namespace ArticleManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> GetList();
    }
}
