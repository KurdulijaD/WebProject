using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Web_Projekat.Models;

namespace Web_Projekat.Controllers
{
    public class RegisterController : ApiController
    {
        [Route("api/Register/SignIn")]
        [HttpPost]
        public IHttpActionResult SignIn(RegistrationUser u)
        {
            if (u.Username == null || u.Username == String.Empty || u.FirstName == null || u.FirstName == String.Empty ||
                u.LastName == null || u.LastName == String.Empty || u.Password == null || u.Password == String.Empty ||
                u.Email == null || u.Email == String.Empty || u.Birthday == null)
            {
                return BadRequest();
            }

            if (!Regex.IsMatch(u.Username, @"^[a-zA-Z0-9]+$"))
            {
                return BadRequest();
            }

            List<User> users = User_CRUD.GetAllUsersVisitor();
            User temp = users.Find(x => x.Username.Equals(u.Username));
            if (temp != null)
            {
                return BadRequest();
            }

            EGender gender = EGender.MALE;
            if(!u.Gender.Contains("Muški"))
            {
                gender = EGender.FEMALE;
            }

            //2022-05-11
            string[] info = u.Birthday.Split('-');
            DateTime date = new DateTime(Int32.Parse(info[0]), Int32.Parse(info[1]), Int32.Parse(info[2]));

            User_CRUD.AddUserVisitor(new User(u.Username, u.Password, u.FirstName, u.LastName, gender, u.Email, date, ERole.VISITOR, new List<int>()));
            return Ok();
        }

        [Route("api/Register/SignInTrainer/{fcId}")]
        [HttpPost]
        public IHttpActionResult SignInTrainer(int fcId, [FromBody]RegistrationUser u)
        {
            if (u.Username == null || u.Username == String.Empty || u.FirstName == null || u.FirstName == String.Empty ||
                u.LastName == null || u.LastName == String.Empty || u.Password == null || u.Password == String.Empty ||
                u.Email == null || u.Email == String.Empty || u.Birthday == null)
            {
                return BadRequest();
            }

            if (!Regex.IsMatch(u.Username, @"^[a-zA-Z0-9]+$"))
            {
                return BadRequest();
            }

            List<User> users = User_CRUD.GetAllUsersVisitor();
            User temp = users.Find(x => x.Username.Equals(u.Username));
            if (temp != null)
            {
                return BadRequest();
            }

            EGender gender = EGender.MALE;
            if (!u.Gender.Contains("Muški"))
            {
                gender = EGender.FEMALE;
            }

            //2022-05-11
            string[] info = u.Birthday.Split('-');
            DateTime date = new DateTime(Int32.Parse(info[0]), Int32.Parse(info[1]), Int32.Parse(info[2]));

            User_CRUD.AddUserTrainer(new User(u.Username, u.Password, u.FirstName, u.LastName, gender, u.Email, date, ERole.TRAINER, new List<int>(), fcId));
            return Ok();
        }

        [Route("api/Register/Update/{username}")]
        [HttpPut]
        public IHttpActionResult Update(string username, [FromBody]User u)
        {
            List<User> users = User_CRUD.GetAllUsersVisitor();
            User temp = users.Find(x => x.Username.Equals(username));
            User user = new User(u.Username, u.Password, u.FirstName, u.LastName, u.Gender, u.Email, u.Birthday, ERole.VISITOR, temp.SignedTrainings);

            User_CRUD.RemoveUserVisitor(temp);
            User_CRUD.AddUserVisitor(user);
            return Ok();
        }

        [Route("api/Register/UpdateTrainer/{username}")]
        [HttpPut]
        public IHttpActionResult UpdateTrainer(string username, [FromBody]User u)
        {
            List<User> users = User_CRUD.GetAllUsersTrainer();
            User temp = users.Find(x => x.Username.Equals(username));
            User user = new User(u.Username, u.Password, u.FirstName, u.LastName, u.Gender, u.Email, u.Birthday, ERole.TRAINER, temp.SignedTrainings);

            User_CRUD.RemoveUserTrainer(temp);
            User_CRUD.AddUserTrainer(u);
            return Ok();
        }

        [Route("api/Register/UpdateOwner/{username}")]
        [HttpPut]
        public IHttpActionResult UpdateOwner(string username, [FromBody]User u)
        {
            List<User> users = User_CRUD.GetAllUsersOwners();
            User temp = users.Find(x => x.Username.Equals(username));
            User user = new User(u.Username, u.Password, u.FirstName, u.LastName, u.Gender, u.Email, u.Birthday, ERole.OWNER, temp.Centers);

            User_CRUD.RemoveUserOwner(temp);
            User_CRUD.AddUserOwner(u);
            return Ok();
        }
    }
}
