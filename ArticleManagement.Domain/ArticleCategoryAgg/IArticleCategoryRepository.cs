using System.Xml.Serialization;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAllArticleCategories();
        ArticleCategory GetArticleCategory(long id);
        void Create(ArticleCategory entity);
        void Save();
        bool Exists(string title);
        
    }
}
