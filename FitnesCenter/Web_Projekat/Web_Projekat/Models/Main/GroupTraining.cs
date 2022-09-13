using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public enum ETrainingType
    {
        YOGA,
        LES_MILLS,
        BODY_PUMP
    }

    public class GroupTraining
    {
        string name;
        ETrainingType trainingType;
        int fitnessCenterId;
        int durationOfTraining;
        DateTime dateOfTraining; 
        int maxVisitor;
        List<string> visitors;
        bool deleted;
        bool finished;
        int trainingId;

        public GroupTraining()
        {

        }

        public GroupTraining(string name, ETrainingType trainingType, int fitnessCenterId, int durationOfTraining, DateTime dateOfTraining, int maxVisitor, List<string> visitors)
        {
            this.name = name;
            this.trainingType = trainingType;
            this.fitnessCenterId = fitnessCenterId;
            this.durationOfTraining = durationOfTraining;
            this.dateOfTraining = dateOfTraining;
            this.maxVisitor = maxVisitor;
            this.visitors = visitors;
            this.Deleted = false;
            this.trainingId = XMLWorker.GenerateTrainingId();
        }

        public string Name { get => name; set => name = value; }
        public ETrainingType TrainingType { get => trainingType; set => trainingType = value; }
        public int FitnessCenterId { get => fitnessCenterId; set => fitnessCenterId = value; }
        public int DurationOfTraining { get => durationOfTraining; set => durationOfTraining = value; }
        public DateTime DateOfTraining { get => dateOfTraining; set => dateOfTraining = value; }
        public int MaxVisitor { get => maxVisitor; set => maxVisitor = value; }
        public List<string> Visitors { get => visitors; set => visitors = value; }

        public string StrDate { get => DateOfTraining.ToString("dd/MM/yyyy HH:mm"); }
        public string Type { get => TrainingType.ToString(); }
        public bool Deleted { get => deleted; set => deleted = value; }
        public bool Finished { get => finished; set => finished = value; }
        public int Year { get => DateOfTraining.Year; }
        public int TrainingId { get => trainingId; set => trainingId = value; }
    }
}