using AutoMapper;
using Guide.BLL.Enums;
using Guide.BLL.Models;
using Guide.DAL.Repository;
using Guide.DAL.Repository.Interfaces;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guide.BLL.Helpers;

namespace Guide.Services.Concretes
{
    public class MarkerService : IMarkerService
    {
        private readonly IMarkerRepository _markerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarkerService(IMarkerRepository markerRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _markerRepository = markerRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MarkerDto> CreateMarker(MarkerDto marker)
        {
            if (marker == null)
            {
                throw new Exception("Model is not valid");
            }

            var markerInDb = _mapper.Map<MarkerDto, Marker>(marker);
            var category = await _categoryRepository.Get(c => c.Shortcut == marker.Shortcut);

            if(category == null)
            {
                category = await _categoryRepository.Get(c => c.Shortcut == CategoryEnum.INFORMATION.GetStringValue());
            }

            markerInDb.Category = category;

            _markerRepository.Add(markerInDb);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Marker, MarkerDto>(markerInDb);

        }

        public async Task DeleteMarker(long markerId)
        {
            var markerInDb = await _markerRepository.Get(m => m.Id == markerId);

            if (markerInDb == null)
            {
                throw new Exception("User does not exist");
            }

            _markerRepository.Remove(markerInDb);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<MarkerDto> GetMarker(long markerId)
        {
            var marker = await _markerRepository.Get(m => m.Id == markerId);

            if(marker == null)
            {
                throw new Exception("User does not exist");
            }

            return _mapper.Map<Marker, MarkerDto>(marker);
        }

        public async Task<List<MarkerDto>> GetMarkers()
        {
            var markers = await _markerRepository.GetAll();

            if(markers == null)
            {
                throw new Exception("There's no markers in database");
            }

            var mappedMarkers =  _mapper.Map<IEnumerable<Marker>, IEnumerable<MarkerDto>>(markers);

            return mappedMarkers.ToList();
        }

        public async Task<MarkerDto> UpdateMarker(MarkerDto marker)
        {
            var markerInDb = await _markerRepository.Get(u => u.Id == marker.Id);

            if (markerInDb == null)
            {
                throw new Exception("User does not exist");
            }

            var category = await _categoryRepository.Get(c => c.Shortcut == marker.Shortcut);

            if (category != null)
            {
                markerInDb.Category = category;
            }

            _mapper.Map(marker, markerInDb);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Marker, MarkerDto>(markerInDb);
        }

        public async Task<List<MarkerDto>> GetMarkersByUserId(long userId)
        {
            var markersInDb = await _markerRepository.GetMarkersByUserId(userId);

            if (markersInDb == null)
            {
                throw new Exception("User has not created any marker yet");
            }

            var mappedMarkers = _mapper.Map<IEnumerable<Marker>, IEnumerable<MarkerDto>>(markersInDb);

            return mappedMarkers.ToList();
        }
    }
}
