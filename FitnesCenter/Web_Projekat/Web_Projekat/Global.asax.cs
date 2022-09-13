using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.Serialization;
using Web_Projekat.Models;

namespace Web_Projekat
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Generisi();


            HttpContext.Current.Application["fitnesscenters"] = XMLWorker.LoadAllFitnessCenters();

            HttpContext.Current.Application["visitors"] = XMLWorker.LoadAllVisitors();
            HttpContext.Current.Application["trainers"] = XMLWorker.LoadAllTrainers();
            HttpContext.Current.Application["owners"] = XMLWorker.LoadAllOwners();

            HttpContext.Current.Application["grouptrainings"] = XMLWorker.LoadAllGroupTrainings();

            HttpContext.Current.Application["comments"] = XMLWorker.LoadAllComments();

            var LogedUsers = new Dictionary<string, User>();
            HttpContext.Current.Application["logedusers"] = LogedUsers;
        }
  

        public void Generisi()
        {
            Address a1 = new Address("Kosovska", 1, "Bileca", 12000);
            Address a2 = new Address("Novo Naselje", 2, "Gacko", 18000);
            Address a3 = new Address("Dr. Sime Milosevica", 10, "Novi Sad", 21000);
            Address a4 = new Address("Cirpanova", 2, "Novi Sad", 18000);
            Address a5 = new Address("Trg republike", 10, "Novi Sad", 21000);

            FitnessCenter f1 = new FitnessCenter("Fitness Zone", a1, 2015, "mika", 20, 200, 5, 3, 10) { Deleted = false};
            FitnessCenter f2 = new FitnessCenter("No Limit", a2, 2020, "pera", 30, 250, 10, 5, 20) { Deleted = false };
            FitnessCenter f3 = new FitnessCenter("Classic Gym", a3, 2006, "zika", 15, 150, 10, 10, 20) { Deleted = false };
            FitnessCenter f4 = new FitnessCenter("Gladiator Fitness", a4, 2002, "pera", 30, 300, 15, 20, 25) { Deleted = false };
            FitnessCenter f5 = new FitnessCenter("Flex Fitness", a5, 2017, "zika", 10, 100, 5, 5, 10) { Deleted = false };
            List<FitnessCenter> fcs = new List<FitnessCenter>() { f1, f2, f3, f4, f5 };

            GroupTraining gt1 = new GroupTraining("Fight Club", ETrainingType.LES_MILLS, f1.FcId, 120, new DateTime(2022, 7, 7, 12, 0, 0), 20, new List<string>()) { Finished = false, Deleted = false};
            GroupTraining gt2 = new GroupTraining("Power Pilates", ETrainingType.BODY_PUMP, f1.FcId, 120, new DateTime(2022, 7, 7, 10, 30, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt3 = new GroupTraining("Yoga Time", ETrainingType.YOGA, f2.FcId, 90, new DateTime(2022, 7, 11, 8, 0, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt4 = new GroupTraining("Cardio", ETrainingType.BODY_PUMP, f3.FcId, 60,new DateTime(2022, 7, 9, 9, 30, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt5 = new GroupTraining("Burn Zone", ETrainingType.LES_MILLS, f3.FcId, 120, new DateTime(2022, 8, 7, 11, 0, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt6 = new GroupTraining("Tonus", ETrainingType.BODY_PUMP, f4.FcId, 90, new DateTime(2022, 8, 12, 9, 0, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt7 = new GroupTraining("Zen Zone", ETrainingType.YOGA, f4.FcId, 120, new DateTime(2022, 7, 10, 12, 30, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gt8 = new GroupTraining("Glute 300", ETrainingType.LES_MILLS, f5.FcId, 60, new DateTime(2022, 7, 8, 12, 0, 0), 20, new List<string>()) { Finished = false, Deleted = false };
            GroupTraining gtf1 = new GroupTraining("Box Club", ETrainingType.BODY_PUMP, f1.FcId, 90, new DateTime(2022, 5, 8, 9, 0, 0), 20, new List<string>() { "dejo", "malina"}) { Finished = true, Deleted = false };
            GroupTraining gtf2 = new GroupTraining("Burn Zone", ETrainingType.YOGA, f1.FcId, 120, new DateTime(2022, 4, 10, 12, 30, 0), 20, new List<string>() { "dejo", "malina" }) { Finished = true, Deleted = false };
            GroupTraining gtf3 = new GroupTraining("Glute 300", ETrainingType.LES_MILLS, f4.FcId, 60, new DateTime(2022, 5, 9, 12, 0, 0), 20, new List<string>() { "dejo", "malina" }) { Finished = true, Deleted = false };
            GroupTraining gtf4 = new GroupTraining("Body Building", ETrainingType.BODY_PUMP, f4.FcId, 60, new DateTime(2022, 4, 11, 20, 0, 0), 20, new List<string>() { "dejo", "malina" }) { Finished = true, Deleted = false };
            GroupTraining gt9 = new GroupTraining("Fit Zone", ETrainingType.LES_MILLS, f2.FcId, 60, new DateTime(2022, 7, 12, 20, 0, 0), 20, new List<string>() { "dejo", "malina" }) { Finished = false, Deleted = false };
            List<GroupTraining> gp = new List<GroupTraining>() { gt1, gt2, gt3, gt4, gt5, gt6, gt7, gt8, gtf1, gtf2, gtf3, gtf4 };

            

            User owner1 = new User("mika", "mika", "Mitar", "Miric", EGender.MALE, "miric@gmail.com", new DateTime(1985, 12, 10), ERole.OWNER) {Centers = new List<int> { f1.FcId } };
            User owner2 = new User("pera", "pera", "Petar", "Peric", EGender.MALE, "peric@gmail.com", new DateTime(1980, 10, 16), ERole.OWNER) { Centers = new List<int> { f2.FcId, f4.FcId } };
            User owner3 = new User("zika", "zika", "Zivko", "Dakovic", EGender.MALE, "daka@gmail.com", new DateTime(1995, 2, 21), ERole.OWNER) { Centers = new List<int> { f3.FcId, f5.FcId } };
            List<User> owners = new List<User>() { owner1, owner2, owner3 };

            User t1 = new User("Luka", "cirko", "Luka", "Ciric", EGender.MALE, "cirko@hotmail.com", new DateTime(2000, 6, 24), ERole.TRAINER, new List<int>() { gt1.TrainingId, gt2.TrainingId, gtf1.TrainingId, gtf2.TrainingId }, f2.FcId);
            User t2 = new User("sofija", "sofija", "Sofija", "Dangubic", EGender.FEMALE, "cirko", new DateTime(2001, 2, 16), ERole.TRAINER, new List<int>() { gt6.TrainingId, gt7.TrainingId, gtf3.TrainingId, gtf4.TrainingId }, f1.FcId);
            List<User> trainers = new List<User>() { t1, t2 };

            User v1 = new User("dejo", "dejo", "Dejan", "Kurdulija", EGender.MALE, "dejokurda@gmail.com", new DateTime(2000, 3, 24), ERole.VISITOR, new List<int>() { gtf1.TrainingId, gtf2.TrainingId, gtf3.TrainingId, gtf4.TrainingId });
            User v2 = new User("malina", "malina", "Nemanja", "Malinovic", EGender.MALE, "malina@gmail.com", new DateTime(2000, 5, 15), ERole.VISITOR, new List<int>() { gtf1.TrainingId, gtf2.TrainingId, gtf3.TrainingId, gtf4.TrainingId });
            List<User> visitors = new List<User>() { v1, v2 };

            Comment c1 = new Comment(true, v1, fcs[1].FcId, "Dobar fitnes centar", 8);
            Comment c2 = new Comment(true, v2, fcs[1].FcId, "Nije los", 7);
            List<Comment> c = new List<Comment>() { c1, c2 };

            XmlSerializer serialiser1 = new XmlSerializer(typeof(List<FitnessCenter>));
           XmlSerializer serialiser2 = new XmlSerializer(typeof(List<GroupTraining>));
           XmlSerializer serialiser3 = new XmlSerializer(typeof(List<User>));
            XmlSerializer serialiser4 = new XmlSerializer(typeof(List<User>));
            XmlSerializer serialiser5 = new XmlSerializer(typeof(List<User>));
            XmlSerializer serialiser6 = new XmlSerializer(typeof(List<Comment>));
            // Create the TextWriter for the serialiser to use
            TextWriter filestream1 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\fitnesscenters.xml");
           TextWriter filestream2 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\grouptrainings.xml");
           TextWriter filestream3 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\visitors.xml");
          TextWriter filestream4 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\trainers.xml");
           TextWriter filestream5 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\owners.xml");
           TextWriter filestream6 = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\comments.xml");


            //write to the file
            serialiser1.Serialize(filestream1, fcs);
            serialiser2.Serialize(filestream2, gp);
            serialiser3.Serialize(filestream3, visitors);
            serialiser4.Serialize(filestream4, trainers);
            serialiser5.Serialize(filestream5, owners);
            serialiser6.Serialize(filestream6, c);

            // Close the file
           filestream1.Close();
           filestream2.Close();
           filestream3.Close();
           filestream4.Close();
           filestream5.Close();
           filestream6.Close();

            //XmlSerializer serialiser = new XmlSerializer(typeof(int));
            //
            //// Create the TextWriter for the serialiser to use
            //TextWriter filestream = new StreamWriter(@"C:\Users\Dejan\Desktop\pr45-2019-web-projekat\Web_Projekat\Web_Projekat\App_Data\trainingId.xml");
            //
            //int TrainingId = 0;
            ////write to the file
            //serialiser.Serialize(filestream, TrainingId);
            //
            //// Close the file
            //filestream.Close();

        }
    }
}
