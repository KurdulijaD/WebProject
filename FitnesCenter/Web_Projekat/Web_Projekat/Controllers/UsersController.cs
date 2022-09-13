using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web_Projekat.Models;

namespace Web_Projekat.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/Users/GetAllUsers")]
        [HttpGet]
        public List<User> GetAllUsers()
        {
            List<User> owners = User_CRUD.GetAllUsersOwners();
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            List<User> visitors = User_CRUD.GetAllUsersVisitor();

            List<User> temp = visitors.Concat(trainers).Concat(owners).ToList();
            return temp;
        }

        [Route("api/Users/GetAllVisitors")]
        [HttpGet]
        public List<User> GetAllVisitors()
        {
            return User_CRUD.GetAllUsersVisitor();
        }

        [Route("api/Users/GetVisitor")]
        [HttpGet]
        public User GetVisitor(string username)
        {
            List<User> visitors = User_CRUD.GetAllUsersVisitor();
            User temp = visitors.Find(x => x.Username.Equals(username));
            return temp;
        }

        [Route("api/Users/GetAllTrainers")]
        [HttpGet]
        public List<User> GetAllTrainers()
        {
            return User_CRUD.GetAllUsersTrainer();
        }

        [Route("api/Users/GetTrainer")]
        [HttpGet]
        public User GetTrainer(string username)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            User temp = trainers.Find(x => x.Username.Equals(username));
            return temp;
        }

        [Route("api/Users/GetOwner")]
        [HttpGet]
        public User GetOwner(string username)
        {
            List<User> owners = User_CRUD.GetAllUsersOwners();
            User temp = owners.Find(x => x.Username.Equals(username));
            return temp;
        }

        [Route("api/Users/GetAllOwners")]
        [HttpGet]
        public List<User> GetAllOwners()
        {
            return User_CRUD.GetAllUsersOwners();
        }

        [Route("api/Users/BlockTrainer/{username}")]
        [HttpPut]
        public IHttpActionResult BlockTrainer(string username)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            foreach (var t in trainers)
            {
                if (t.Username.Equals(username))
                    t.Blocked = true;
            }

            XMLWorker.UpdateTrainers(trainers);
            return Ok();
        }

        [Route("api/Users/UnblockTrainer/{username}")]
        [HttpPut]
        public IHttpActionResult UnblockTrainer(string username)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            foreach (var t in trainers)
            {
                if (t.Username.Equals(username))
                    t.Blocked = false;
            }

            XMLWorker.UpdateTrainers(trainers);
            return Ok();
        }

    }
}
