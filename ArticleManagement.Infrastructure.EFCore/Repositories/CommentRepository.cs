using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contracts.Comment;
using ArticleManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly ArticleContext _context;
        public CommentRepository(ArticleContext context): base(context) 
        {
            _context= context;
        }
        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id, 
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title

            }).ToList();
        }
    }
}
