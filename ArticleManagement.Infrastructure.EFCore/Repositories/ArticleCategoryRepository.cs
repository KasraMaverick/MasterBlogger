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
            Save();
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategory> GetAllArticleCategories()
        {
            return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
