using ArticleManagement.Application.Contracts.Article;
using ArticleManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ArticleManagement.Infrastructure.EFCore.Repositories
{
    
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;
        public ArticleRepository(ArticleContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public bool Exists(string title)
        {
            return _context.Articles.Any(a => a.Title == title);
        }

        public Article Get(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> GetArticleViewModels()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
