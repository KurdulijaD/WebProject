using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;

namespace Web_Projekat.Models
{
    public class XMLWorker
    {
        public static List<User> LoadAllVisitors()
        {
            try
            {
                string path = "~/App_Data/visitors.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> visitors = new List<User>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextReader textReader = new StreamReader(path))
                {
                    visitors = (List<User>)serializer.Deserialize(textReader);
                }
                return visitors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
        }

        public static List<User> LoadAllTrainers()
        {
            try
            {
                string path = "~/App_Data/trainers.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> trainers = new List<User>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextReader textReader = new StreamReader(path))
                {
                    trainers = (List<User>)serializer.Deserialize(textReader);
                }
                return trainers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
        }

        public static List<User> LoadAllOwners()
        {
            try
            {
                string path = "~/App_Data/owners.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> owners = new List<User>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextReader textReader = new StreamReader(path))
                {
                    owners = (List<User>)serializer.Deserialize(textReader);
                }
                return owners;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
        }

        public static void AddVisitor(User user)
        {
            try
            {
                string path = "~/App_Data/visitors.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> visitors = LoadAllVisitors();
                visitors.Add(user);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, visitors);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AddTrainer(User user)
        {
            try
            {
                string path = "~/App_Data/trainers.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> trainers = LoadAllTrainers();
                trainers.Add(user);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, trainers);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AddOwner(User user)
        {
            try
            {
                string path = "~/App_Data/owners.xml";
                path = HostingEnvironment.MapPath(path);

                List<User> owners = LoadAllOwners();
                owners.Add(user);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, owners);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void UpdateVisitors(List<User> visitors)
        {
            string path = "~/App_Data/visitors.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (User u in visitors)
            {
                AddVisitor(u);
            }
        }

        public static void UpdateTrainers(List<User> trainers)
        {
            string path = "~/App_Data/trainers.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (User u in trainers)
            {
                AddTrainer(u);
            }
        }

        public static void UpdateOwner(List<User> owners)
        {
            string path = "~/App_Data/owners.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (User u in owners)
            {
                AddOwner(u);
            }
        }

        public static List<FitnessCenter> LoadAllFitnessCenters()
        {
            try
            {
                string path = "~/App_Data/fitnesscenters.xml";
                path = HostingEnvironment.MapPath(path);

                List<FitnessCenter> fitnesscenters = new List<FitnessCenter>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<FitnessCenter>));
                using (TextReader textReader = new StreamReader(path))
                {
                    fitnesscenters = (List<FitnessCenter>)serializer.Deserialize(textReader);
                }
                return fitnesscenters;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<FitnessCenter>();
            }
        }
        public static void AddFitnessCenter(FitnessCenter fc)
        {
            try
            {
                string path = "~/App_Data/fitnesscenters.xml";
                path = HostingEnvironment.MapPath(path);

                List<FitnessCenter> fitnesscenters = LoadAllFitnessCenters();
                fitnesscenters.Add(fc);

                XmlSerializer serializer = new XmlSerializer(typeof(List<FitnessCenter>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, fitnesscenters);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void UpdateFitnessCenters(List<FitnessCenter> fitnesscenters)
        {
            string path = "~/App_Data/fitnesscenters.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (FitnessCenter fc in fitnesscenters)
            {
                AddFitnessCenter(fc);
            }
        }

        public static List<GroupTraining> LoadAllGroupTrainings()
        {
            try
            {
                string path = "~/App_Data/grouptrainings.xml";
                path = HostingEnvironment.MapPath(path);

                List<GroupTraining> grouptrainings = new List<GroupTraining>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<GroupTraining>));
                using (TextReader textReader = new StreamReader(path))
                {
                    grouptrainings = (List<GroupTraining>)serializer.Deserialize(textReader);
                }
                return grouptrainings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<GroupTraining>();
            }
        }

        public static void AddGroupTraining(GroupTraining gt)
        {
            try
            {
                string path = "~/App_Data/grouptrainings.xml";
                path = HostingEnvironment.MapPath(path);

                List<GroupTraining> grouptrainings = LoadAllGroupTrainings();
                grouptrainings.Add(gt);

                XmlSerializer serializer = new XmlSerializer(typeof(List<GroupTraining>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, grouptrainings);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void UpdateGroupTraining(List<GroupTraining> grouptrainings)
        {
            string path = "~/App_Data/grouptrainings.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (GroupTraining gt in grouptrainings)
            {
                AddGroupTraining(gt);
            }
        }

        public static List<Comment> LoadAllComments()
        {
            try
            {
                string path = "~/App_Data/comments.xml";
                path = HostingEnvironment.MapPath(path);

                List<Comment> comments = new List<Comment>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Comment>));
                using (TextReader textReader = new StreamReader(path))
                {
                    comments = (List<Comment>)serializer.Deserialize(textReader);
                }
                return comments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Comment>();
            }
        }

        public static void AddComment(Comment com)
        {
            try
            {
                string path = "~/App_Data/comments.xml";
                path = HostingEnvironment.MapPath(path);

                List<Comment> comments = LoadAllComments();
                comments.Add(com);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Comment>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, comments);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void UpdateComment(List<Comment> comments)
        {
            string path = "~/App_Data/comments.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (Comment com in comments)
            {
                AddComment(com);
            }
        }

        public static List<KeyValuePair<User, List<GroupTraining>>> LoadFinishedTrainings()
        {
            try
            {
                string path = "~/App_Data/finishedtrainings.xml";
                path = HostingEnvironment.MapPath(path);

                List<KeyValuePair<User, List<GroupTraining>>> ft = new List<KeyValuePair<User, List<GroupTraining>>>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<User, List<GroupTraining>>>));
                using (TextReader textReader = new StreamReader(path))
                {
                    ft = (List<KeyValuePair<User, List<GroupTraining>>>)serializer.Deserialize(textReader);
                }
                return ft;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<KeyValuePair<User, List<GroupTraining>>>();
            }
        }

        public static List<KeyValuePair<User, List<GroupTraining>>> LoadSignedTrainings()
        {
            try
            {
                string path = "~/App_Data/signedtrainings.xml";
                path = HostingEnvironment.MapPath(path);

                List<KeyValuePair<User, List<GroupTraining>>> st = new List<KeyValuePair<User, List<GroupTraining>>>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<User, List<GroupTraining>>>));
                using (TextReader textReader = new StreamReader(path))
                {
                    st = (List<KeyValuePair<User, List<GroupTraining>>>)serializer.Deserialize(textReader);
                }
                return st;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<KeyValuePair<User, List<GroupTraining>>>();
            }
        }

        public static void AddSignedTraining(User u, GroupTraining gt)
        {
            try
            {
                string path = "~/App_Data/signedtrainings.xml";
                path = HostingEnvironment.MapPath(path);

                List<KeyValuePair<User, List<GroupTraining>>> grouptrainings = LoadSignedTrainings();
                Dictionary<User, List<GroupTraining>> dict = grouptrainings.ToDictionary(x => x.Key, x => x.Value);
                if (!dict.ContainsKey(u))
                    dict.Add(u, new List<GroupTraining>());

                dict[u].Add(gt);

                grouptrainings = dict.ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(List<GroupTraining>));
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, grouptrainings);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void UpdateSignedTrainings(Dictionary<User, List<GroupTraining>> dict)
        {
            string path = "~/App_Data/signedtrainings.xml";
            path = HostingEnvironment.MapPath(path);

            XmlDocument document = new XmlDocument();
            document.Load(path);
            document.DocumentElement.RemoveAll();
            document.Save(path);

            foreach (KeyValuePair<User, List<GroupTraining>> item in dict)
            {
                foreach(GroupTraining gt in item.Value)
                {
                    AddSignedTraining(item.Key, gt);
                }
            }
        }

        public static int GenerateTrainingId()
        {

             string path = "~/App_Data/trainingId.xml";
             path = HostingEnvironment.MapPath(path);

             int id;
             XmlSerializer serializer = new XmlSerializer(typeof(int));
             using (TextReader textReader = new StreamReader(path))
             {
                 id = (int)serializer.Deserialize(textReader);
             }

             using (TextWriter textWriter = new StreamWriter(path))
             {
                 serializer.Serialize(textWriter, ++id);
             }

            return id;
        }

        public static int GenerateFcId()
        {

            string path = "~/App_Data/fcId.xml";
            path = HostingEnvironment.MapPath(path);

            int id;
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (TextReader textReader = new StreamReader(path))
            {
                id = (int)serializer.Deserialize(textReader);
            }

            using (TextWriter textWriter = new StreamWriter(path))
            {
                serializer.Serialize(textWriter, ++id);
            }

            return id;
        }

        public static int GenerateCommentId()
        {

            string path = "~/App_Data/commentsId.xml";
            path = HostingEnvironment.MapPath(path);

            int id;
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (TextReader textReader = new StreamReader(path))
            {
                id = (int)serializer.Deserialize(textReader);
            }

            using (TextWriter textWriter = new StreamWriter(path))
            {
                serializer.Serialize(textWriter, ++id);
            }

            return id;
        }
    }
}