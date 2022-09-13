using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class LoginUser
    {
        string username;
        string password;

        public LoginUser()
        {

        }

        public LoginUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}