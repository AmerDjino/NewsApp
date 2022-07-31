using API.DBModels;
using Contracts;
using DALayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class UserRepository : IUserRepository
    {
        private readonly NewsAppDBContext _dbContext;
        public UserRepository(NewsAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserContract>> GetAllUsers()
        {
            var users = _dbContext.Users.AsAsyncEnumerable();
            List<UserContract> result = new List<UserContract>();
            await foreach (User user in users)
            {
               UserContract newUser = new UserContract(user.FirstName, user.LastName, user.Username);
               result.Add(newUser);
            }
            return result;
        }

        public async Task<UserContract> GetUserById(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            var usercontract = new UserContract(user.FirstName, user.LastName, user.Username);
            return usercontract;
        }
    }
}
