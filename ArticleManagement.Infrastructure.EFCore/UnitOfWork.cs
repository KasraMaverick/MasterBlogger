using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Infrastructure.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext Context)
        { 
            _context = Context;
        }
        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
