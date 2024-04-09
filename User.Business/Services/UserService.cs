using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Business.DTOs.Request;
using User.Business.DTOs.Response;
using User.DAL.Repositories;

namespace User.Business.Services
{
    public interface IUserService
    {
        void AddUser(UserRequestDTO userDto);
        void UpdateUser(UserRequestDTO userDto);
        public UserResponseDTO? GetUser(int userId);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(UserRequestDTO userDto)
        {
            _userRepository.AddUser(new DAL.Entities.User { 
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            });
        }
        public void UpdateUser(UserRequestDTO userDto)
        {
            string email = userDto.Email;
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            _userRepository.UpdateUser(user);
        }
        public UserResponseDTO? GetUser(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return null;
            }
            return new UserResponseDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }

    }
}
