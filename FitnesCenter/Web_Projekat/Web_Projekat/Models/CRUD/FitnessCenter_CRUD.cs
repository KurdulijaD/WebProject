using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class FitnessCenter_CRUD
    {
        public static List<FitnessCenter> GetAllFC()
        {
            List<FitnessCenter> fitnessCenters = (List<FitnessCenter>)HttpContext.Current.Application["fitnesscenters"];
            return fitnessCenters;
        }

        public static void AddFitnessCenter(FitnessCenter center)
        {
            List<FitnessCenter> fitnessCenters = (List<FitnessCenter>)HttpContext.Current.Application["fitnesscenters"];
            XMLWorker.AddFitnessCenter(center);
            HttpContext.Current.Application["fitnesscenters"] = XMLWorker.LoadAllFitnessCenters();
        }

        public static void RemoveFitnessCenter(FitnessCenter center)
        {
            List<FitnessCenter> fitnessCenters = (List<FitnessCenter>)HttpContext.Current.Application["fitnesscenters"];
            fitnessCenters.Remove(center);
            XMLWorker.UpdateFitnessCenters(fitnessCenters);
            HttpContext.Current.Application["fitnesscenters"] = XMLWorker.LoadAllFitnessCenters();
        }
    }
}