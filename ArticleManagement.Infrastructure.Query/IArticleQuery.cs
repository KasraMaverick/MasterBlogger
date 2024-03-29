﻿namespace ArticleManagement.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView GetArticle(long id);
    }
}
