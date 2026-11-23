using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repotroty
{
    internal class AssignmentRepostory
    {
        DataContext dataContext = new DataContext();
        public List<Assignment> GetAll() => dataContext.Assignments.ToList();
        public Volunteer GetById(int id) => dataContext.Volunteers.FirstOrDefault(v => v.Id == id);

        public void Add(Assignment a) => dataContext.Assignments.Add(a);
        public void Update(Assignment assignment)
        {
            var assignmentToUpdate = dataContext.Assignments.FirstOrDefault(v => v.TaskId == assignment.TaskId);
            assignmentToUpdate.VolunteerId = assignment.VolunteerId;
            assignmentToUpdate.EndDate = assignment.EndDate;
        }
        public void Delete(int id)
        {
            var AssignmentDelete = dataContext.Assignments.FirstOrDefault(v => v.TaskId == id);
            dataContext.Assignments.Remove(AssignmentDelete);
        }

    }
}
