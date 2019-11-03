using Guide.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Intefaces
{
    public interface IMarkerService
    {
        Task<List<MarkerDto>> GetMarkers();
        Task<MarkerDto> GetMarker(long markerId);
        Task<List<MarkerDto>> GetMarkersByUserId(long userId);
        Task<MarkerDto> CreateMarker(MarkerDto marker);
        Task<MarkerDto> UpdateMarker(MarkerDto marker);
        Task DeleteMarker(long markerId);
    }
}
