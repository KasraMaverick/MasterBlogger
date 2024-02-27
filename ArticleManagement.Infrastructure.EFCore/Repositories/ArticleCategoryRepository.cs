using ArticleManagement.Domain.ArticleCategoryAgg;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ArticleContext _context;
        public ArticleCategoryRepository(ArticleContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            _context.SaveChanges();
        }

        public List<ArticleCategory> GetAllArticleCategories()
        {
            return _context.ArticleCategories.ToList();
        }
    }
}
