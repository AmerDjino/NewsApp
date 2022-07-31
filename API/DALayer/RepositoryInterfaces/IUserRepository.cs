using Contracts;

namespace DALayer.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<List<UserContract>> GetAllUsers();
        public Task<UserContract> GetUserById(Guid userId);
    }
}
