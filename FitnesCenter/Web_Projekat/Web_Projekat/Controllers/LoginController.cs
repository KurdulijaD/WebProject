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
    public class LoginController : ApiController
    {
        [Route("api/Login/LogIn")]
        [HttpPost]
        public User LogIn(LoginUser loginUser)
        {
            List<User> usersVisitor = (List<User>)HttpContext.Current.Application["visitors"];
            List<User> usersTrainer = (List<User>)HttpContext.Current.Application["trainers"];
            List<User> usersOwner = (List<User>)HttpContext.Current.Application["owners"];

            if(loginUser.Username == null || loginUser.Username == String.Empty || loginUser.Password == null || loginUser.Password == String.Empty)
            {
                BadRequest();
            }

            User tempVisitor = usersVisitor.Find(x => x.Username == loginUser.Username && x.Password == loginUser.Password);
            if(tempVisitor != null)
            {
                User_CRUD.LogInWithToken(tempVisitor.Username, tempVisitor);
                return tempVisitor;
            }

            User tempTrainer = usersTrainer.Find(x => x.Username == loginUser.Username && x.Password == loginUser.Password);
            if (tempTrainer != null)
            {
                if(tempTrainer.Blocked == true)
                {
                    return null;
                }
                else
                {
                    User_CRUD.LogInWithToken(tempTrainer.Username, tempTrainer);
                    return tempTrainer;
                }
               
            }

            User tempOwner = usersOwner.Find(x => x.Username == loginUser.Username && x.Password == loginUser.Password);
            if (tempOwner != null)
            {
                User_CRUD.LogInWithToken(tempOwner.Username, tempOwner);
                return tempOwner;
            }

            return null;            
        }

        [Route("api/Login/LogOut/{username}")]
        [HttpPut]
        public IHttpActionResult LogOut(string username)
        {
            User_CRUD.LogOutWithToken(username);
            return Ok();
        }

    }
}
