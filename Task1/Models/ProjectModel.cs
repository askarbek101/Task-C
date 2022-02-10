using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public String ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
        public int? Priority { get; set; }

        public ProjectModel() { }

        public ProjectModel(string projectName, DateTime startDate, DateTime endDate, int? priority)
        {
            
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            Status = getStatus(startDate,endDate);
            Priority = priority;
        }

        public enum StatusEnum 
        {
            NotStarted,
            Active,
            Completed
        }

        public static StatusEnum getStatus(DateTime startDate, DateTime endDate) {
            return endDate < DateTime.Now ? StatusEnum.Completed : (startDate > DateTime.Now ? StatusEnum.Active : StatusEnum.NotStarted);
        }
    }
}
