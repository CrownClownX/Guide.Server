﻿using AutoMapper;
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
            var user = await _userRepository.Get(u => u.Id == userId);

            if(user == null)
            {
                throw new Exception("User does not exist");
            }

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

            if (users == null)
            {
                throw new Exception("There's no users in database");
            }

            var mappedUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

            return mappedUsers.ToList();
        }
    }
}
