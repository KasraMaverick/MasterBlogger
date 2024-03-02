﻿using ArticleManagement.Application.Contracts.Article;

namespace ArticleManagement.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetArticleViewModels();
        void CreateAndSave(Article entity);
        Article Get(long id);
        void Save();
        bool Exists(string title);

    }
}
