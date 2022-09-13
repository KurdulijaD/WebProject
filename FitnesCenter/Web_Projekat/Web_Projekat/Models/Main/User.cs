using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public enum EGender
    {
        MALE,
        FEMALE
    }

    public enum ERole
    {
        VISITOR,
        TRAINER,
        OWNER
    }

    public class User
    {
        string username;
        string password;
        string firstName;
        string lastName;
        EGender gender;
        string email;
        DateTime birthday;
        ERole role;
        List<int> signedTrainings;
        int fitnessCenterId;
        List<int> centers;
        bool blocked;

        public User()
        {

        }

        //visitor
        public User(string username, string password, string firstName, string lastName, EGender gender, string email, DateTime birthday, ERole role, List<int> signedTrainings)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Email = email;
            this.Birthday = birthday;
            this.Role = role;
            this.SignedTrainings = signedTrainings;
        }

        //trainer
        public User(string username, string password, string firstName, string lastName, EGender gender, string email, DateTime birthday, ERole role, List<int> signedTrainings, int fitnessCenterId)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Email = email;
            this.Birthday = birthday;
            this.Role = role;
            this.SignedTrainings = signedTrainings;
            this.FitnessCenterId = fitnessCenterId;
            this.Blocked = false;
        }

        //owner
        public User(string username, string password, string firstName, string lastName, EGender gender, string email, DateTime birthday, ERole role)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Email = email;
            this.Birthday = birthday;
            this.Role = role;
            this.Centers = centers;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public EGender Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public ERole Role { get => role; set => role = value; }
        public List<int> SignedTrainings { get => signedTrainings; set => signedTrainings = value; }
        public int FitnessCenterId { get => fitnessCenterId; set => fitnessCenterId = value; }
        public List<int> Centers { get => centers; set => centers = value; }
        public string StrBirthday { get => Birthday.ToString("dd/MM/yyyy"); }
        public string StrRole { get => Role.ToString(); }
        public bool Blocked { get => blocked; set => blocked = value; }
    }
}