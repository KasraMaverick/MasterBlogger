using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Domain.ArticleAgg;

namespace ArticleManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
           var article = _articleRepository.Get(id);
           article.Activate();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.shortDescription, command.Image, command.Content, 
                command.ArticleCategoryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.shortDescription, command.Image, 
                command.Content, command.ArticleCategoryId);
            _unitOfWork.CommitTran();
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
            return _articleRepository.GetList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }
    }
}
