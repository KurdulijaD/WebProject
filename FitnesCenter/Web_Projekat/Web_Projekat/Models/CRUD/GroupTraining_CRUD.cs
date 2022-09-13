using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class GroupTraining_CRUD
    {
        public static List<GroupTraining> GetAllGP()
        {
            List<GroupTraining> gp = (List<GroupTraining>)HttpContext.Current.Application["grouptrainings"];
            return gp;
        }

        public static void AddGroupTraining(GroupTraining training)
        {
            List<GroupTraining> gp = (List<GroupTraining>)HttpContext.Current.Application["grouptrainings"];
            XMLWorker.AddGroupTraining(training);
            HttpContext.Current.Application["grouptrainings"] = XMLWorker.LoadAllGroupTrainings();
        }

        public static void RemoveGroupTraining(GroupTraining training)
        {
            List<GroupTraining> gp = (List<GroupTraining>)HttpContext.Current.Application["grouptrainings"];
            gp.Remove(training);
            XMLWorker.UpdateGroupTraining(gp);
            HttpContext.Current.Application["grouptrainings"] = XMLWorker.LoadAllGroupTrainings();
        }
    }
}