using _0_Framework.Infrastructure;
using System.Xml.Serialization;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        List<ArticleCategory> GetList();
    }
}
