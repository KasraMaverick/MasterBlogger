using ArticleManagement.Domain.CommentAgg;
using ArticleManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ArticleManagement.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly ArticleContext _context;
        public ArticleQuery(ArticleContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles.Include(c => c.ArticleCategory).
                Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirmed))
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(c => c.ArticleCategory).
                Include(x => x.Comments).
                Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)
            }).ToList();
        }
        public List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView
            {
                Name = comment.Name,
                CreatedDate = comment.CreatedDate.ToString(CultureInfo.InvariantCulture),
                Message = comment.Message,
            }).ToList();

            //var result = new List<CommentQueryView>();
            //foreach(var comment in comments)
            //{
            //    result.Add(new CommentQueryView
            //    {
            //        Name = comment.Name,
            //        CreatedDate = comment.CreatedDate.ToString(CultureInfo.InvariantCulture),
            //        Message = comment.Message,
            //    });
                
            //}
            //return result;
        }
    }
}
