using BLLayer.Interfaces;
using Contracts;
using DALayer.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BLLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserContract>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<UserContract> GetUserById(Guid userId)
        {
            return await _userRepository.GetUserById(userId);
        }
    }
}
