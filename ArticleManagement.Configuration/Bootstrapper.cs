using ArticleManagement.Application;
using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Application.Contracts.ArticleCategory;
using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleAgg.Services;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.ArticleCategoryAgg.Services;
using ArticleManagement.Infrastructure.EFCore;
using ArticleManagement.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleManagement.Configuration
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddDbContext<ArticleContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
