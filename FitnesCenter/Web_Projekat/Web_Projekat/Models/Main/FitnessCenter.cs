using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class FitnessCenter
    {
        string name;
        Address address;
        int openingYear;
        string owner;
        int monthlyPrice;
        int yearPrice;
        int trainingPrice;
        int groupTrainingPrice;
        int trainingWithTrainerPrice;
        bool deleted;
        int fcId;

        public FitnessCenter()
        {

        }

        public FitnessCenter(string name, Address address, int openingYear, string owner, int monthlyPrice, int yearPrice, int trainingPrice, int groupTrainingPrice, int trainingWithTrainerPrice)
        {
            this.name = name;
            this.address = address;
            this.openingYear = openingYear;
            this.owner = owner;
            this.monthlyPrice = monthlyPrice;
            this.yearPrice = yearPrice;
            this.trainingPrice = trainingPrice;
            this.groupTrainingPrice = groupTrainingPrice;
            this.trainingWithTrainerPrice = trainingWithTrainerPrice;
            this.Deleted = false;
            this.fcId = XMLWorker.GenerateFcId();
        }

        public string Name { get => name; set => name = value; }
        public Address Address { get => address; set => address = value; }
        public int OpeningYear { get => openingYear; set => openingYear = value; }
        public string Owner { get => owner; set => owner = value; }
        public int MonthlyPrice { get => monthlyPrice; set => monthlyPrice = value; }
        public int YearPrice { get => yearPrice; set => yearPrice = value; }
        public int TrainingPrice { get => trainingPrice; set => trainingPrice = value; }
        public int GroupTrainingPrice { get => groupTrainingPrice; set => groupTrainingPrice = value; }
        public int TrainingWithTrainerPrice { get => trainingWithTrainerPrice; set => trainingWithTrainerPrice = value; }
        public bool Deleted { get => deleted; set => deleted = value; }
        public int FcId { get => fcId; set => fcId = value; }
    }
}