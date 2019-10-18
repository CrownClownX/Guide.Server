using AutoMapper;
using Guide.BLL.Models;
using Guide.DAL.Repository;
using Guide.DAL.Repository.Interfaces;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
    }
}
