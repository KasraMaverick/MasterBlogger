using ArticleManagement.Domain.CommentAgg;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ArticleContext _context;
        public CommentRepository(ArticleContext context)
        {
            _context = context;
        }

        public void CreateAndSaveComment(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }
    }
}
