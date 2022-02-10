using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        [HttpPost]
        public String Create(String name, DateTime startDate, DateTime endDate, int? priority)  
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    ProjectModel result = new ProjectModel(name, startDate, endDate, priority);
                    db.Projects.Add(result);
                    db.SaveChanges();
                    return "Задача \"" + result.ProjectName + "\" успешно добавлена";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public IEnumerable<ProjectModel> Read()
        {
            var list = new List<ProjectModel>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var item in db.Projects.OrderBy(c => c.Priority))
                {
                    ProjectModel temp = new ProjectModel();
                    temp.Id = item.Id;
                    temp.ProjectName = item.ProjectName;
                    temp.StartDate = item.StartDate;
                    temp.EndDate = item.EndDate;
                    temp.Status = ProjectModel.getStatus(item.StartDate, item.EndDate);
                    temp.Priority = item.Priority;
                    list.Add(temp);
                }
            }
            return list;
        }
        [HttpPatch]
        public String Update(int id, String projectName, DateTime startDate, DateTime endDate, int priority)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    ProjectModel result = db.Projects.First(c => c.Id == id);
                    result.ProjectName = projectName;
                    result.StartDate = startDate;
                    result.EndDate = endDate;
                    result.Priority = priority;
                    db.SaveChanges();
                    return "Задача \"" + result.ProjectName + "\" успешно обновленна";
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
                    ProjectModel result = db.Projects.First(c => c.Id == id);
                    db.Remove(result);
                    db.SaveChanges();
                    return "Задача \"" + result.ProjectName + "\" успешно удалена";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
