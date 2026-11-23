using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repotroty
{
    public class TaskVolunteerRepostory
    {
        DataContext dataContext = new DataContext();

        public IEnumerable<TaskVolunteer> GetAll() => dataContext.Tasks;
        
        public TaskVolunteer GetById(int id) => dataContext.Tasks.FirstOrDefault(v => v.IdTask == id);
        public void Add(TaskVolunteer v) => dataContext.Tasks.Add(v);

        public void Update(TaskVolunteer taskVolunteer)
        {
            var TaskVolunteerToUpdate = dataContext.Tasks.FirstOrDefault(v => v.IdTask == taskVolunteer.IdTask);
            TaskVolunteerToUpdate.Type = taskVolunteer.Type;
            TaskVolunteerToUpdate.TaskDescription = taskVolunteer.TaskDescription;
            TaskVolunteerToUpdate.DateAndTime = taskVolunteer.DateAndTime;
            TaskVolunteerToUpdate.Address = taskVolunteer.Address;
            TaskVolunteerToUpdate.status= taskVolunteer.status;
        }
        public void Delete(int id)
        {
            var taskVolunteerDelete = dataContext.Tasks.FirstOrDefault(v => v.IdTask == id);

            dataContext.Tasks.Remove(taskVolunteerDelete);
        }

    }
}
