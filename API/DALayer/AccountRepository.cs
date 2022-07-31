using API.DBModels;
using Contracts;
using DALayer.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DALayer
{
    public class AccountRepository : IAccountRepository
    {
        private readonly NewsAppDBContext _dbContext;
        private readonly IUserRepository _userRepository;
        public AccountRepository(NewsAppDBContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<UserContract> Login(LoginContract loginContract)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Username == loginContract.Username);
            if(user == null)
            {
                return null;
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginContract.Password));
            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }
            var userContract = new UserContract(user.FirstName, user.LastName, user.LastName);
            return userContract;

        }

        public async Task<UserContract> RegisterUser(RegistrationContract registrationContract)
        {
            using var hmac = new HMACSHA512();
            Guid guid = Guid.NewGuid();
            var newUser = new User()
            {
                UserId = guid,
                Username = registrationContract.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationContract.Password)),
                PasswordSalt = hmac.Key,
                FirstName = registrationContract.FirstName,
                LastName = registrationContract.LastName,
                Email = registrationContract.Email,
            };
            try
            {
               await _dbContext.Users.AddAsync(newUser);
               await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new DbUpdateException();
            }
            var userCotract = await _userRepository.GetUserById(guid);
            return userCotract;
        }
    }
}
