using Guide.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.DAL.Repository.Interfaces
{
    public interface IMarkerRepository : IRepository<Marker>
    {
        Task<List<Marker>> GetMarkersByUserId(long userId);
    }
}
