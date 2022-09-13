using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class CreateTraining
    {
        string username;
        string name;
        ETrainingType trainingType;
        int durationOfTraining;
        DateTime dateOfTraining;
        int maxVisitor;

        public CreateTraining()
        {

        }

        public CreateTraining(string username, string name, ETrainingType trainingType, int durationOfTraining, DateTime dateOfTraining, int maxVisitor)
        {
            this.username = username;
            this.name = name;
            this.trainingType = trainingType;
            this.durationOfTraining = durationOfTraining;
            this.dateOfTraining = dateOfTraining;
            this.maxVisitor = maxVisitor;
        }

        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public ETrainingType TrainingType { get => trainingType; set => trainingType = value; }
        public int DurationOfTraining { get => durationOfTraining; set => durationOfTraining = value; }
        public DateTime DateOfTraining { get => dateOfTraining; set => dateOfTraining = value; }
        public int MaxVisitor { get => maxVisitor; set => maxVisitor = value; }
    }
}