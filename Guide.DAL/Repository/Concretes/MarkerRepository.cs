using Guide.BLL.Models;
using Guide.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Marker>> GetMarkersByUserId(long userId)
        {
            var user = await _context.Set<User>()
                .Include(m => m.Markers)
                .SingleOrDefaultAsync(u => u.Id == userId);

            return user.Markers;
        }
    }
}
