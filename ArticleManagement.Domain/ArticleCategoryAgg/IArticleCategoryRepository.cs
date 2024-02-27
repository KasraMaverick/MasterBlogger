namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        public List<ArticleCategory> GetAllArticleCategories();
        public void Create(ArticleCategory entity);
    }
}
