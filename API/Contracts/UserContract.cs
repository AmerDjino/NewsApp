namespace Contracts
{
    public class UserContract
    {
        public UserContract()
        {
        }

        public UserContract(string fisrName, string lastName, string userName, string? token = null)
        {
            FisrName = fisrName;
            LastName = lastName;
            UserName = userName;
            Token = token;
        }
        public string FisrName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? Token { get; set; }
    }
}