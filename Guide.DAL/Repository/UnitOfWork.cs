using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
