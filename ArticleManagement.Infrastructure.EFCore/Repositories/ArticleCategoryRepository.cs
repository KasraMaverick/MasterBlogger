using _0_Framework.Infrastructure;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System.Security.Cryptography.X509Certificates;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly ArticleContext _context;
        public ArticleCategoryRepository(ArticleContext context) : base(context) 
        {
            _context = context;
        }

        public List<ArticleCategory> GetList()
        {
            return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

    }
}
