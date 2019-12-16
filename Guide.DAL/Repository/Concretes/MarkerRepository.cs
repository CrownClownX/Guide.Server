using Guide.BLL.Exceptions;
using Guide.BLL.Models;
using Guide.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guide.DAL.Repository.Concretes
{
    public class MarkerRepository : Repository<Marker>, IMarkerRepository
    {
        public MarkerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<Marker> GetWithThrow(Expression<Func<Marker, bool>> predicate)
        {
            var marker = await _context.Set<Marker>()
                .Include(m => m.Category)
                .Include(m => m.User)
                .FirstOrDefaultAsync(predicate);

            if(marker == null)
            {
                throw new DataNotFoundException();
            }

            return marker;
        }

        public override async Task<IEnumerable<Marker>> GetAll()
        {
            return await _context.Set<Marker>()
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<List<Marker>> GetMarkersByUserId(long userId)
        {
            var user = await _context.Set<User>()
                .Include(m => m.Markers)
                .ThenInclude(m => m.Category)
                .SingleOrDefaultAsync(u => u.Id == userId);

            return user.Markers;
        }
    }
}
