using BLLayer.Interfaces;
using Contracts;
using DALayer.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BLLayer
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;

        public AccountService(IAccountRepository accountRepository, ITokenService tokenService)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
        }

        public async Task<UserContract> Login(LoginContract loginContract)
        {
            var user = await _accountRepository.Login(loginContract);
            user.Token = _tokenService.GetToken(user);
            return user;
        }

        public async Task<UserContract> RegisterUser(RegistrationContract registrationContract)
        {
            var user =  await _accountRepository.RegisterUser(registrationContract);
            user.Token = _tokenService.GetToken(user);
            return user;
        }
    }
}
