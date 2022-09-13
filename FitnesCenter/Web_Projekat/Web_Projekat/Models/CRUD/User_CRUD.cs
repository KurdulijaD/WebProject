using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class User_CRUD
    {
        public static void AddUserVisitor(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["visitors"];
            XMLWorker.AddVisitor(user);
            HttpContext.Current.Application["visitors"] = XMLWorker.LoadAllVisitors();
        }

        public static void RemoveUserVisitor(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["visitors"];
            users.Remove(user);
            XMLWorker.UpdateVisitors(users);
            HttpContext.Current.Application["visitors"] = XMLWorker.LoadAllVisitors(); 
        }

        public static List<User> GetAllUsersVisitor()
        {
            List<User> users = (List<User>)HttpContext.Current.Application["visitors"];
            return users;
        }

        public static List<User> GetAllUsersTrainer()
        {
            List<User> users = (List<User>)HttpContext.Current.Application["trainers"];
            return users;
        }

        public static void AddUserTrainer(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["trainers"];
            XMLWorker.AddTrainer(user);
            HttpContext.Current.Application["trainers"] = XMLWorker.LoadAllTrainers();
        }

        public static void RemoveUserTrainer(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["trainers"];
            users.Remove(user);
            XMLWorker.UpdateTrainers(users);
            HttpContext.Current.Application["trainers"] = XMLWorker.LoadAllTrainers();
        }

        public static List<User> GetAllUsersOwners()
        {
            List<User> users = (List<User>)HttpContext.Current.Application["owners"];
            return users;
        }

        public static void AddUserOwner(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["owners"];
            XMLWorker.AddOwner(user);
            HttpContext.Current.Application["owners"] = XMLWorker.LoadAllOwners();
        }

        public static void RemoveUserOwner(User user)
        {
            List<User> users = (List<User>)HttpContext.Current.Application["owners"];
            users.Remove(user);
            XMLWorker.UpdateOwner(users);
            HttpContext.Current.Application["owners"] = XMLWorker.LoadAllOwners();
        }

        public static void LogInWithToken(string username, User u)
        {
            Dictionary<string, User> log = (Dictionary<string, User>)HttpContext.Current.Application["logedusers"];
            log.Add(username, u);
            HttpContext.Current.Application["logedusers"] = log;
        }

        public static void LogOutWithToken(string username)
        {
            Dictionary<string, User> log = (Dictionary<string, User>)HttpContext.Current.Application["logedusers"];
            log.Remove(username);
            HttpContext.Current.Application["logedusers"] = log;
        }
    }
}