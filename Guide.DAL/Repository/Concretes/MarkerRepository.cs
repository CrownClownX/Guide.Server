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

        public virtual async Task<Marker> Get(Expression<Func<Marker, bool>> predicate)
        {
            return await _context.Set<Marker>()
                .Include(m => m.Category)
                .Include(m => m.User)
                .SingleOrDefaultAsync(predicate);
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
