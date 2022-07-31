using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BLLayer.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserContract>> GetAllUsers();
        public Task<UserContract> GetUserById(Guid userId);
    }
}
