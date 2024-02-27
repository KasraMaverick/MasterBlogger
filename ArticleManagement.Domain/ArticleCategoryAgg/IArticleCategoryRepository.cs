using System.Xml.Serialization;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAllArticleCategories();
        ArticleCategory Get(long id);
        void Create(ArticleCategory entity);
        void Save();
        
    }
}
