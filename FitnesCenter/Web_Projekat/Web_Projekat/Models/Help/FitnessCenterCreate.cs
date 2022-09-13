using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class FitnessCenterCreate
    {
        string username;
        string name;
        string streetName;
        int streetNumber;
        string city;
        int postNumber;
        int openingYear;
        int monthlyPrice;
        int yearPrice;
        int trainingPrice;
        int groupTrainingPrice;
        int trainingWithTrainerPrice;

        public FitnessCenterCreate()
        {

        }

        public FitnessCenterCreate(string username, string name, string streetName, int streetNumber, string city, int postNumber, int openingYear, int monthlyPrice, int yearPrice, int trainingPrice, int groupTrainingPrice, int trainingWithTrainerPrice)
        {
            this.username = username;
            this.name = name;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.city = city;
            this.postNumber = postNumber;
            this.openingYear = openingYear;
            this.monthlyPrice = monthlyPrice;
            this.yearPrice = yearPrice;
            this.trainingPrice = trainingPrice;
            this.groupTrainingPrice = groupTrainingPrice;
            this.trainingWithTrainerPrice = trainingWithTrainerPrice;
        }

        public string Name { get => name; set => name = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public int StreetNumber { get => streetNumber; set => streetNumber = value; }
        public string City { get => city; set => city = value; }
        public int PostNumber { get => postNumber; set => postNumber = value; }
        public int OpeningYear { get => openingYear; set => openingYear = value; }
        public int MonthlyPrice { get => monthlyPrice; set => monthlyPrice = value; }
        public int YearPrice { get => yearPrice; set => yearPrice = value; }
        public int TrainingPrice { get => trainingPrice; set => trainingPrice = value; }
        public int GroupTrainingPrice { get => groupTrainingPrice; set => groupTrainingPrice = value; }
        public int TrainingWithTrainerPrice { get => trainingWithTrainerPrice; set => trainingWithTrainerPrice = value; }
        public string Username { get => username; set => username = value; }
    }
}