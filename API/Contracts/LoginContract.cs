using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class LoginContract
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginContract(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
