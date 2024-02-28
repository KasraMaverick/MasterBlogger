using ArticleManagement.Domain.ArticleAgg;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;
        public ArticleRepository(ArticleContext context)
        {
            _context = context;
        }
    }
}
