using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class RegistrationUser
    {
        string username;
        string password;
        string firstName;
        string lastName;
        string gender;
        string email;
        string birthday;

        public RegistrationUser()
        {

        }

        public RegistrationUser(string username, string password, string firstName, string lastName, string gender, string email, string birthday)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Email = email;
            this.Birthday = birthday;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public string Birthday { get => birthday; set => birthday = value; }
    }
}