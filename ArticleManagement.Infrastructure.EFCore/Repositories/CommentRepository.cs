using ArticleManagement.Application.Contracts.Comment;
using ArticleManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            Save();
        }

        public Comment GetComment(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);

        }

        public List<CommentViewModel> GetCommentList()
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
