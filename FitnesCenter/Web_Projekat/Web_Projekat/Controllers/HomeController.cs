using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Web_Projekat.Models;

namespace Web_Projekat.Controllers
{
    //[RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        [Route("api/Home/GetAllFC")]
        [HttpGet]
        public List<FitnessCenter> GetAllFC()
        {
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();
            fitnessCenters = fitnessCenters.OrderBy(fc => fc.Name).ToList();
            return fitnessCenters;
        }


        [Route("api/Home/GetFCOwner")]
        [HttpGet]
        public List<FitnessCenter> GetFCOwner(string username)
        {
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();
            List<FitnessCenter> fc = new List<FitnessCenter>();

            foreach (var item in fitnessCenters)
            {
                if (item.Owner.Equals(username))
                    fc.Add(item);
            }

            return fc;
        }

        [Route("api/Home/GetTrainersForOwner")]
        [HttpGet]
        public List<User> GetTrainersForOwner(string username)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            List<User> temp = new List<User>();
            List<FitnessCenter> fitnessCenters = GetFCOwner(username);

            foreach (var item in trainers)
            {
                foreach(var fc in fitnessCenters)
                {
                    if (item.FitnessCenterId.Equals(fc.FcId))
                        temp.Add(item);
                }
            }

            return temp;
        }
        

        [Route("api/Home/GetTrainerByFcId")]
        [HttpGet]
        public List<User> GetTrainerByFcId(int fcId)
        {
            List<User> trainers = User_CRUD.GetAllUsersTrainer();
            List<User> retVal = new List<User>();

            foreach (var item in trainers)
            {
                if (item.FitnessCenterId == fcId)
                    retVal.Add(item);
            }

            return retVal;
        }
        

        [Route("api/Home/AddFitnessCenter")]
        [HttpPost]
        public IHttpActionResult AddFitnessCenter(FitnessCenterCreate fc)
        {
            int year = DateTime.Now.Year;
            List<User> owners = User_CRUD.GetAllUsersOwners();
            User temp = owners.Find(x => x.Username == fc.Username);
            Address a = new Address(fc.StreetName, fc.StreetNumber, fc.City, fc.PostNumber);
            FitnessCenter center = new FitnessCenter(fc.Name, a, year, fc.Username, fc.MonthlyPrice, fc.YearPrice, fc.TrainingPrice, fc.GroupTrainingPrice, fc.TrainingWithTrainerPrice);

            FitnessCenter_CRUD.AddFitnessCenter(center);
            temp.Centers.Add(center.FcId);
            XMLWorker.UpdateOwner(owners);

            return Ok();
        }

        [Route("api/Home/UpdateFitnessCenter/{parameter}")]
        [HttpPut]
        public IHttpActionResult UpdateFitnessCenter(string parameter, [FromBody]FitnessCenterCreate fc)
        {
            int id = Int32.Parse(parameter.Split('_')[0]);
            int year = Int32.Parse(parameter.Split('_')[1]);

            Address a = new Address(fc.StreetName, fc.StreetNumber, fc.City, fc.PostNumber);
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();
            FitnessCenter temp = fitnessCenters.Find(x => x.FcId == id);
            FitnessCenter center = new FitnessCenter(fc.Name, a, year, fc.Username, fc.MonthlyPrice, fc.YearPrice, fc.TrainingPrice, fc.GroupTrainingPrice, fc.TrainingWithTrainerPrice) { FcId = temp.FcId};

            FitnessCenter_CRUD.RemoveFitnessCenter(temp);
            FitnessCenter_CRUD.AddFitnessCenter(center);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            List<FitnessCenter> fitnessCenters = FitnessCenter_CRUD.GetAllFC();
            FitnessCenter temp = fitnessCenters.Find(x => x.FcId == id);
            List<GroupTraining> groupTrainings = GroupTraining_CRUD.GetAllGP();
            GroupTraining tempTraining = groupTrainings.Find(x => x.FitnessCenterId == id);
            List<User> trainers = User_CRUD.GetAllUsersTrainer();

            if (temp != null)
            {
                if (tempTraining == null)
                {
                    temp.Deleted = true;
                    foreach(var t in trainers)
                    {
                        if (t.FitnessCenterId == id)
                            t.Blocked = true;
                    }
                    return Ok();
                }
                    
            }

            return null;
        }


        [Route("api/Home/SearchFC")]
        [HttpGet]
        public List<FitnessCenter> SearchFC(string name, string address, string yearHigh, string yearLow)
        {
            List<FitnessCenter> fitnessCenters = GetAllFC();
            List<FitnessCenter> searchFC = new List<FitnessCenter>();

            if ((name == null || name == String.Empty) && (address == null || address == String.Empty) && (((yearHigh == null || yearHigh == String.Empty)) && ((yearLow == null || yearLow == String.Empty))))
            {
                return fitnessCenters;
            }

            int minYear = (yearLow == String.Empty || yearLow == null) ? 1950 : Int32.Parse(yearLow);
            int maxYear = (yearHigh == String.Empty || yearHigh == null) ? 2022 : Int32.Parse(yearHigh);

            foreach (var fc in fitnessCenters)
            {
                if (fc.OpeningYear > minYear && fc.OpeningYear < maxYear)
                {
                    if (address != null && address != String.Empty)
                    {
                        if (fc.Address.ToString().ToLower().Contains(address.ToLower()))
                        {
                            if (name != null && name != String.Empty)
                            {
                                if (fc.Name.ToLower().Contains(name.ToLower()))
                                {
                                    searchFC.Add(fc);
                                }
                            }
                            else
                            {
                                searchFC.Add(fc);
                            }
                        }
                    }
                    else if(name != null && name != String.Empty)
                    {
                            if (fc.Name.ToLower().Contains(name.ToLower()))
                            {
                                searchFC.Add(fc);
                            }
                    }
                    else
                    {
                        searchFC.Add(fc);
                    }                    
                }
            }

            return searchFC;
        }

        [Route("api/Home/SortFC")]
        [HttpGet]
        public List<FitnessCenter> SortFC(string sortType)
        {
            List<FitnessCenter> fitnessCenters = GetAllFC();
            var parameter = sortType.Split('_')[0];
            var type = sortType.Split('_')[1];

            switch (parameter)
            {
                case "name":
                    if (type == "asc")
                    {
                        fitnessCenters = fitnessCenters.OrderBy(x => x.Name).ToList();
                    }
                    else
                    {
                        fitnessCenters = fitnessCenters.OrderByDescending(x => x.Name).ToList();
                    }
                    break;

                case "address":
                    if (type == "asc")
                    {
                        fitnessCenters = fitnessCenters.OrderBy(x => x.Address.ToString()).ToList();
                    }
                    else
                    {
                        fitnessCenters = fitnessCenters.OrderByDescending(x => x.Address.ToString()).ToList();
                    }
                    break;

                case "year":
                    if (type == "asc")
                    {
                        fitnessCenters = fitnessCenters.OrderBy(x => x.OpeningYear).ToList();
                    }
                    else
                    {
                        fitnessCenters = fitnessCenters.OrderByDescending(x => x.OpeningYear).ToList();
                    }
                    break;
            }

            return fitnessCenters;
        }

        [Route("api/Home/GetFC")]
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

        [Route("api/Home/GetAllComments")]
        [HttpGet]
        public List<Comment> GetAllComments()
        {
            List<Comment> comments = Comment_CRUD.GetAllComments();
            return comments;
        }

        [Route("api/Home/GetNewComments")]
        [HttpGet]
        public List<Comment> GetNewComments(string username)
        {
            List<Comment> comments = Comment_CRUD.GetAllComments();
            List<Comment> com = new List<Comment>();
            List<FitnessCenter> fc = GetFCOwner(username);

            foreach(var c in comments)
            {
                foreach(var center in fc)
                {
                    if (c.FitnessCenterId == center.FcId && c.Validate == false)
                        com.Add(c);

                }
            }
            return com;
        }
        

        [Route("api/Home/LeaveComment")]
        [HttpPost]
        public IHttpActionResult LeaveComment(Comment c)
        {
            Comment com = new Comment(false, c.Visitor, c.FitnessCenterId, c.Text, c.Mark);
            Comment_CRUD.AddComment(com);
            XMLWorker.AddComment(com);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(int id)
        {
            List<Comment> comments = Comment_CRUD.GetAllComments();
            Comment temp = comments.Find(x => x.CommentId == id);
            temp.Validate = true;
            XMLWorker.UpdateComment(comments);
            return Ok();
        }
    }
}
