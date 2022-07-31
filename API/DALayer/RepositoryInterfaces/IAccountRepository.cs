using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DALayer.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        public Task<UserContract> RegisterUser(RegistrationContract registrationContract);
        public Task<UserContract> Login(LoginContract loginContract);
    }
}
