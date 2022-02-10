using System;

namespace Task1
{
    public class TaskModel
    {
        public int Id { get; set; }
        public String TaskName { get; set; }
        public String TaskDiscription { get; set; }
        public int? Priority { get; set; }

        public TaskModel(string taskName, string taskDiscription, int? priority)
        {
            TaskName = taskName;
            TaskDiscription = taskDiscription;
            Priority = priority;
        }

    }
}
