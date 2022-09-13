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
    public class TrainingController : ApiController
    {
        [Route("api/Training/GetSpecificGT")]
        [HttpGet]
        public List<GroupTraining> GetSpecificGT(int id)
        {
            List<GroupTraining> allGroupTrainings = GroupTraining_CRUD.GetAllGP();
            List<GroupTraining> gt = new List<GroupTraining>();
            foreach (var item in allGroupTrainings)
            {
                if (item.FitnessCenterId == id)
                {
                    gt.Add(item);
                }
            }

            return gt;
        }

        [Route("api/Training/GetTrainingById")]
        [HttpGet]
        public GroupTraining GetTrainingById(int id)
        {
            List<GroupTraining> allGroupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining temp = allGroupTrainings.Find(x => x.TrainingId == id);

            if(temp != null)
            {
                return temp;
            }

            return null;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            List<GroupTraining> allGroupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining temp = allGroupTrainings.Find(x => x.TrainingId == id);

            if (temp != null)
            {
                if(temp.Visitors.Count == 0)
                {
                    temp.Deleted = true;
                    return Ok();
                }  
            }

            XMLWorker.UpdateGroupTraining(allGroupTrainings);
            return null;
        }

        [Route("api/Training/GetVisitorsOfTraining")]
        [HttpGet]
        public List<User> GetVisitorsOfTraining(int id)
        {
            List<GroupTraining> allGroupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining temp = allGroupTrainings.Find(x => x.TrainingId == id);
            List<User> visitors = User_CRUD.GetAllUsersVisitor();
            List<User> visitorsOfTraining = new List<User>();
            foreach(var usrnm in temp.Visitors)
            {
                foreach(var user in visitors)
                {
                    if (user.Username.Equals(usrnm))
                        visitorsOfTraining.Add(user);
                }
            }

            return visitorsOfTraining;
            
        }

        [Route("api/Training/SignTraining/{parameter}")]
        [HttpPost]
        public IHttpActionResult SignTraining(string parameter)
        {
            int id = Int32.Parse(parameter.Split('_')[0]);
            string username = parameter.Split('_')[1];

            List<GroupTraining> gps = GroupTraining_CRUD.GetAllGP();
            List<User> users = User_CRUD.GetAllUsersVisitor();

            User tempU = users.Find(x => x.Username == username);
            GroupTraining tempT = gps.Find(x => x.TrainingId == id);

            tempT.Visitors.Add(tempU.Username);
            tempU.SignedTrainings.Add(tempT.TrainingId);

            XMLWorker.UpdateVisitors(users);
            XMLWorker.UpdateGroupTraining(gps);
            HttpContext.Current.Application["visitors"] = users;

            return Ok();
        }

        [Route("api/Training/UnsignTraining/{parameter}")]
        [HttpPost]
        public IHttpActionResult UnsignTraining(string parameter)
        {
            int id = Int32.Parse(parameter.Split('_')[0]);
            string username = parameter.Split('_')[1];

            List<GroupTraining> gps = GroupTraining_CRUD.GetAllGP();
            List<User> users = User_CRUD.GetAllUsersVisitor();

            User tempU = users.Find(x => x.Username == username);
            GroupTraining tempT = gps.Find(x => x.TrainingId == id);

            tempT.Visitors.Remove(tempU.Username);
            tempU.SignedTrainings.Remove(tempT.TrainingId);

            XMLWorker.UpdateVisitors(users);
            XMLWorker.UpdateGroupTraining(gps);
            HttpContext.Current.Application["visitors"] = users;

            return Ok();
        }

        [Route("api/Training/GetMyTrainings")]
        [HttpGet]
        public List<GroupTraining> GetMyTrainings(string username)
        {
            List<User> users = User_CRUD.GetAllUsersVisitor();
            User temp = users.Find(x => x.Username == username);
            List<GroupTraining> groupTrainings = GroupTraining_CRUD.GetAllGP();
            List<GroupTraining> finishedTrainings = new List<GroupTraining>();
            foreach(var id in temp.SignedTrainings)
            {
                foreach(var training in groupTrainings)
                {
                    if (id == training.TrainingId)
                        finishedTrainings.Add(training);
                }
            }

            return finishedTrainings;
        }

        [Route("api/Training/GetFC")]
        [HttpGet]
        public FitnessCenter GetFC(int id)
        {
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();

            FitnessCenter temp = fitnessCenters.Find(x => x.FcId == id);
            if (temp == null)
            {
                BadRequest();
            }

            return temp;
        }

        [Route("api/Training/SearchTrainings")]
        [HttpGet]
        public List<GroupTraining> SearchTrainings(string username, string trName, string fcName, string type)
        {
            List<GroupTraining> groupTrainings = GetMyTrainings(username);
            List<GroupTraining> searchedGT = new List<GroupTraining>();
            

            if ((trName == null || trName == String.Empty) && (fcName == null || fcName == String.Empty) && type.Equals("SVI"))
            {
                return groupTrainings;
            }


            foreach (var tr in groupTrainings)
            {
                if(type != "SVI")
                {
                    if(tr.TrainingType.ToString().Equals(type))
                    {
                        if(trName != null && trName != String.Empty)
                        {
                            if (tr.Name.ToLower().Contains(trName.ToLower()))
                            {
                                if(fcName != null && fcName != String.Empty)
                                {
                                    FitnessCenter temp = GetFC(tr.FitnessCenterId);
                                    if (temp.Name.ToLower().Contains(fcName.ToLower()))
                                    {
                                        searchedGT.Add(tr);
                                    }
                                }
                                else
                                {
                                    searchedGT.Add(tr);
                                }
                            }
                        }
                        else if(fcName != null && fcName != String.Empty)
                        {
                            FitnessCenter temp = GetFC(tr.FitnessCenterId);
                            if (temp.Name.ToLower().Contains(fcName.ToLower()))
                            {
                                searchedGT.Add(tr);
                            }
                        }
                        else
                        {
                            searchedGT.Add(tr);
                        }                            
                    }
                }
                else if(trName != null && trName != String.Empty)
                {
                    if (tr.Name.ToLower().Contains(trName.ToLower()))
                    {
                        if (fcName != null && fcName != String.Empty)
                        {
                            FitnessCenter temp = GetFC(tr.FitnessCenterId);
                            if (temp.Name.ToLower().Contains(fcName.ToLower()))
                            {
                                searchedGT.Add(tr);
                            }
                        }
                        else
                        {
                            searchedGT.Add(tr);
                        }                            
                    }
                }
                else if(fcName != null && fcName != String.Empty)
                {
                    FitnessCenter temp = GetFC(tr.FitnessCenterId);
                    if (temp.Name.ToLower().Contains(fcName.ToLower()))
                    {
                        searchedGT.Add(tr);
                    }
                }
            }

            return searchedGT;
        }

       
        [Route("api/Training/SortTrainings")]
        [HttpGet]
        public List<GroupTraining> SortTrainings(string sortType, string username)
        {
            List<GroupTraining> groupTrainings = GetMyTrainings(username);
            var parameter = sortType.Split('_')[0];
            var type = sortType.Split('_')[1];

            switch (parameter)
            {
                case "name":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.Name).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.Name).ToList();
                    }
                    break;

                case "type":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.TrainingType.ToString()).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.TrainingType.ToString()).ToList();
                    }
                    break;

                case "date":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.DateOfTraining).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.DateOfTraining).ToList();
                    }
                    break;
            }

            return groupTrainings;
        }

        [Route("api/Training/AddTraining")]
        [HttpPost]
        public IHttpActionResult AddTraining(CreateTraining gt)
        {
            TimeSpan ts = new TimeSpan(3, 0, 0, 0);
            DateTime now = DateTime.Now;
            TimeSpan ts2 = gt.DateOfTraining.Subtract(now);
            if (gt.DateOfTraining.Subtract(now) < ts)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(gt.Name) || gt.DateOfTraining == null)
            {
                return null;
            }

            DateTime dt = Convert.ToDateTime(gt.DateOfTraining.ToString("dd/MM/yyyy HH:mm"));
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            User temp = trainers.Find(x => x.Username == gt.Username);
            List<GroupTraining> groupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining training = new GroupTraining(gt.Name, gt.TrainingType, temp.FitnessCenterId, gt.DurationOfTraining, gt.DateOfTraining, gt.MaxVisitor, new List<string>()) { Deleted = false, Finished = false};

            groupTrainings.Add(training);
            temp.SignedTrainings.Add(training.TrainingId);

            XMLWorker.AddGroupTraining(training);
            XMLWorker.UpdateTrainers(trainers);

            return Ok();
        }

        [Route("api/Training/GetTrainingsForTrainer")]
        [HttpGet]
        public List<GroupTraining> GetTrainingsForTrainer(string username)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            User temp = trainers.Find(x => x.Username.Equals(username));
            List<GroupTraining> groupTrainings = GroupTraining_CRUD.GetAllGP();
            List<GroupTraining> gt = new List<GroupTraining>();

            foreach(var id in temp.SignedTrainings)
            {
                foreach(GroupTraining training in groupTrainings)
                {
                    if (training.TrainingId == id)
                        gt.Add(training);
                }
            }
            return gt;
        }

        [Route("api/Training/SortTrainerTrainings")]
        [HttpGet]
        public List<GroupTraining> SortTrainerTrainings(string sortType, string username)
        {
            List<GroupTraining> groupTrainings = GetTrainingsForTrainer(username);
            var parameter = sortType.Split('_')[0];
            var type = sortType.Split('_')[1];

            switch (parameter)
            {
                case "name":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.Name).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.Name).ToList();
                    }
                    break;

                case "type":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.TrainingType.ToString()).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.TrainingType.ToString()).ToList();
                    }
                    break;

                case "date":
                    if (type == "asc")
                    {
                        groupTrainings = groupTrainings.OrderBy(x => x.DateOfTraining).ToList();
                    }
                    else
                    {
                        groupTrainings = groupTrainings.OrderByDescending(x => x.DateOfTraining).ToList();
                    }
                    break;
            }

            return groupTrainings;
        }

        [Route("api/Training/SearchTraining")]
        [HttpGet]
        public List<GroupTraining> SearchTraining(string username, string name, string type, string yearHigh, string yearLow)
        {
            List<GroupTraining> groupTrainings = GetTrainingsForTrainer(username);
            List<GroupTraining> searchedGT = new List<GroupTraining>();
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();

            if ((name == null || name == String.Empty)  && yearHigh == null  && yearLow == null)
            {
                return groupTrainings;
            }

            FitnessCenter temp = fitnessCenters.Find(x => x.FcId == groupTrainings[0].FitnessCenterId);
            int openingYear = temp.OpeningYear;

            DateTime minDate = (String.IsNullOrEmpty(yearLow)) ? new DateTime(openingYear, 1, 1) : DateTime.Parse(yearLow);
            DateTime maxDate = (String.IsNullOrEmpty(yearHigh)) ? DateTime.Now.Date : DateTime.Parse(yearHigh);

            foreach (var gt in groupTrainings)
            {
                if (gt.DateOfTraining >= minDate && gt.DateOfTraining <= maxDate)
                {
                    if(type !="SVI")
                    {
                        if (gt.TrainingType.ToString().Equals(type))
                        {
                            if(!string.IsNullOrWhiteSpace(name))
                            {
                                if (gt.Name.ToLower().Contains(name.ToLower()))
                                {
                                    searchedGT.Add(gt);
                                }
                            }
                            else
                            {
                                searchedGT.Add(gt);
                            }
                        }                        
                    }
                    else if (!string.IsNullOrWhiteSpace(name))
                    {
                        if (gt.Name.ToLower().Contains(name.ToLower()))
                        {
                            searchedGT.Add(gt);
                        }
                    }
                    else
                    {
                        searchedGT.Add(gt);
                    }
                }
            }

            return searchedGT;
        }

        [Route("api/Training/UpdateTraining/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateTraining(int id, [FromBody]GroupTraining gp)
        {           
            List<GroupTraining> groupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining tempT = groupTrainings.Find(x => x.TrainingId == id);
            GroupTraining training = new GroupTraining(gp.Name, gp.TrainingType, tempT.FitnessCenterId, gp.DurationOfTraining, gp.DateOfTraining, gp.MaxVisitor, tempT.Visitors) { TrainingId = tempT.TrainingId};

            GroupTraining_CRUD.RemoveGroupTraining(tempT);
            GroupTraining_CRUD.AddGroupTraining(training);

            return Ok();
        }
    }
}
