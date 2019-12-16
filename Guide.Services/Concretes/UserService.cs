using AutoMapper;
using Guide.BLL.Exceptions;
using Guide.BLL.Models;
using Guide.DAL.Helpers;
using Guide.DAL.Repository;
using Guide.DAL.Repository.Interfaces;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserDto> GetUser(long userId)
        {
            var user = await _userRepository.GetWithThrow(u => u.Id == userId);

            var mappedUser = _mapper.Map<User, UserDto>(user);

            return mappedUser;
        }

        public async Task<List<UserDto>> GetUsers(int itemPerPage, int page)
        {
            var query = new QueryDate<User, long>
            {
                CurrentPage = page,
                ItemsPerPage = itemPerPage,
                SortBy = u => u.Id
            };

            var users = await _userRepository.GetAllWithPaging(query);

            var mappedUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

            return mappedUsers.ToList();
        }

        public async Task<UserDto> CreateUser(NewUserDto user)
        {
            if (user == null)
            {
                throw new ModelNotValidException();
            }

            var userInDb = _mapper.Map<NewUserDto, User>(user);

            _userRepository.Add(userInDb);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<User, UserDto>(userInDb);
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var userInDb = await _userRepository.GetWithThrow(u => u.Id == user.Id);

            _mapper.Map(user, userInDb);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<User, UserDto>(userInDb);
        }

        public async Task DeleteUser(long userId)
        {
            var userInDb = await _userRepository.GetWithThrow(u => u.Id == userId);

            _userRepository.Remove(userInDb);
            await _unitOfWork.CompleteAsync();
        }
    }
}
