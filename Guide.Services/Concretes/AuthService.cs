using AutoMapper;
using Guide.BLL.Exceptions;
using Guide.BLL.Logic.Interfaces;
using Guide.BLL.Models;
using Guide.DAL.Repository;
using Guide.DAL.Repository.Interfaces;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using Guide.Services.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthLogic _authLogic;

        public AuthService(IAuthLogic authLogic, IUserRepository userRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authLogic = authLogic;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> SignInUser(UserCredentialsDto credentials)
        {
            var user = await _userRepository
                .GetWithThrow(u => u.Email == credentials.Email);

            var encryptedPassword = _mapper.Map<User, Password>(user);

            _authLogic.VerifyPasswordHash(credentials.Password, encryptedPassword);

            var mappedUser = _mapper.Map<User, UserDto>(user);
            mappedUser.Token = _authLogic.GenerateToken(user.Id);

            return mappedUser;
        }

        public async Task<UserDto> SignUpPlayer(SignUpDto credentials)
        {
            var user = await _userRepository
                .Get(u => u.Email == credentials.Email);

            if (user != null)
            {
                throw new AlreadyExistException();
            }

            var encryptedPassword = _authLogic.CreatePasswordHash(credentials.Password);

            user = new User
            {
                Name = credentials.Name,
                Email = credentials.Email,
                PasswordHash = encryptedPassword.PasswordHash,
                PasswordSalt = encryptedPassword.PasswordSalt
            };

            _userRepository.Add(user);
            await _unitOfWork.CompleteAsync();

            var mappedUser = _mapper.Map<User, UserDto>(user);
            mappedUser.Token = _authLogic.GenerateToken(user.Id);

            return mappedUser;        }
    }
}
