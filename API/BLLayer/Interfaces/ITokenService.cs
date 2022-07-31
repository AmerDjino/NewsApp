using Contracts;

namespace BLLayer.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(UserContract userContract);
    }
}
