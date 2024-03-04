using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly ArticleContext _context;
        public ArticleRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

    }
}
