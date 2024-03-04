using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contracts.Article;

namespace ArticleManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,  Article>
    {
        List<ArticleViewModel> GetList();
    }
}
