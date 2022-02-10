using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Task1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {

        [HttpPost]
        public String Create(String name, String discription, int priority)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    TaskModel result = new TaskModel(name, discription, priority);
                    db.Tasks.Add(result);
                    db.SaveChanges();
                    return "Задача \"" + result.TaskName + "\" успешно добавлена";
                }
            }
            catch (Exception e) {
                return e.Message;
            }
        }
        
        [HttpGet]
        public IEnumerable<TaskModel> Read() {
            var list = new List<TaskModel>();
            using (ApplicationContext db = new ApplicationContext()) 
            {
                foreach (var item in db.Tasks.OrderBy(c => c.Priority)) 
                {
                    TaskModel temp = new TaskModel(item.TaskName, item.TaskDiscription, item.Priority);
                    temp.Id = item.Id;
                    list.Add(temp);
                }
            }
            return list;
        }

        [HttpPatch]
        public String Update(int id, String name, String discription, int? priority)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    TaskModel result = db.Tasks.First(c => c.Id == id);
                    if (name != "") result.TaskName = name;
                    if (discription != "") result.TaskDiscription = discription;
                    if (priority != null) result.Priority = priority;
                    db.SaveChanges();
                    return "Задача \"" + result.TaskName + "\" успешно обновленна";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpDelete]
        public String Delete(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    TaskModel result = db.Tasks.First(c => c.Id == id);
                    db.Remove(result);
                    db.SaveChanges();
                    return "Задача \"" + result.TaskName + "\" успешно удалена";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
