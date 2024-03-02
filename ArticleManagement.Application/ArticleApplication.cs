﻿using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Domain.ArticleAgg;

namespace ArticleManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.shortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);

        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.shortDescription, command.Image, 
                command.Content, command.ArticleCategoryId);

            _articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                Image = article.Image,
                shortDescription = article.ShortDescription,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId,
            };
        }

        public List<ArticleViewModel> GetAllArticles()
        {
            return _articleRepository.GetArticleViewModels();
        }
    }
}
