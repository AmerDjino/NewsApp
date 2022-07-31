using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BLLayer.Interfaces
{
    public interface IAccountService
    {
        public Task<UserContract> RegisterUser(RegistrationContract registrationContract);
        public Task<UserContract> Login(LoginContract loginContract);
    }
}
