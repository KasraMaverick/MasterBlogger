using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Infrastructure.EFCore
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
    }
}
