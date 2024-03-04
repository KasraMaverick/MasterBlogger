using _0_Framework.Infrastructure;
using ArticleManagement.Application;
using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Application.Contracts.ArticleCategory;
using ArticleManagement.Application.Contracts.Comment;
using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleAgg.Services;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.ArticleCategoryAgg.Services;
using ArticleManagement.Domain.CommentAgg;
using ArticleManagement.Infrastructure.EFCore;
using ArticleManagement.Infrastructure.EFCore.Repositories;
using ArticleManagement.Infrastructure.Query;
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

            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ArticleContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
