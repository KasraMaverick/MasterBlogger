using ArticleManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ArticleManagement.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly ArticleContext _context;
        public ArticleQuery(ArticleContext context)
        {
            _context = context;
        }
        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(c => c.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id  = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
            }).ToList();
        }
    }
}
