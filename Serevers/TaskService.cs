using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repotroty;
namespace Service
{
    public class TaskService {
        TaskVolunteerRepostory repo = new TaskVolunteerRepostory();
        public List<TaskToShow> GetAllTaskFromService(string? sortBy) 
        { 
            var tasks=repo.GetAll();
            if(sortBy != null) 
            {
                if (sortBy == "date")
                    tasks = tasks.OrderBy(t => t.DateAndTime);
                if (sortBy == "location") 
                   tasks = tasks.OrderBy(t => t.Address);

            }
            var list = new List<TaskToShow>();
            foreach(var task in tasks)
            {
                string typeAsString=task.Type.ToString();   
                string dateAsString=task.DateAndTime.ToString();
                string statsAsString=task.status.ToString();
                list.Add(new TaskToShow(task.IdTask, typeAsString, task.TaskDescription, dateAsString, task.Address, statsAsString));
             }       
            return list;
        }

    public void Add(TaskToAdd taskToAdd)
        {
            List<TaskVolunteer> list = repo.GetAll().ToList();

            if (taskToAdd.TaskDescription.Length>=10&&30<= taskToAdd.TaskDescription.Length)
            {
                TaskVolunteer taskVolunteer = new TaskVolunteer() { IdTask = list.Count + 1, TaskDescription = taskToAdd.TaskDescription, DateAndTime = taskToAdd.DateAndTime, Address = taskToAdd.Address, status = Status.open };
                repo.Add(taskVolunteer);
            }
            else
                throw new Exception("The description should be shorter or longer.");

        }
   
        public void UpdateTask(int id, TaskToUpdate taskToUpdate)
        { 
        var taskById=repo.GetById(id);
            if (taskById == null) 
                throw new Exception("There is no task number {id}.");
            //if (taskToUpdate.Type != null)
            //    taskById.Type = (Skill)Enum.Parse(typeof(Skill),taskToUpdate.Type,true);
            if (taskToUpdate.TaskDescription != null)
                taskById.TaskDescription = taskToUpdate.TaskDescription;
            if (taskToUpdate.DateAndTime != null)
                taskById.DateAndTime = DateTime.Parse(taskToUpdate.DateAndTime);
            if (taskToUpdate.Address != null)
                taskById.Address = taskToUpdate.Address;
            if (taskToUpdate.status != null)
                taskById.status =(Status)Enum.Parse(typeof(Status), taskToUpdate.status, true);

            repo.Update(taskById);
        }

    //public Skill GetMatchedSkills(TaskToAdd taskToAdd)
    //    {
    //        //ליצור רשימה מהמיומנויות
    //        //למחוק את סימומת הing
    //        //לעבור על כל מילה ברשימה ולבדוק אם היא קיימת בתאור 
    //        //אם כן להחזיר את המיומנות הזו
    //        var skills = Enum.GetNames(typeof(Skill)).ToList();
    //        for (int i = 0; i < skills.Count; i++)
    //        {
    //            if (skills[i].Contains("ing"))
    //                skills[i] = skills[i].Substring(0, skills[i].Length - 3);
    //        }
    //        //sk.Substring(0, sk.Length - 4);

    //        Console.WriteLine(skills);
    //        for (int i = 0; i < skills.Count; i++)
    //        {
    //            if (taskToAdd.TaskDescription.Contains(skills[i].ToLower()))
    //                return Enum.GetValues<Skill>()[i];
    //        }
    //        return Skill.UnKnown;


    //    }

        public TaskToShow GetById(int id)
        {
            var taskById=repo.GetById(id);
            string typeAsString = taskById.Type.ToString();
            string dateAsString = taskById.DateAndTime.ToString();
            string statsAsString = taskById.status.ToString();

            return new TaskToShow(id,typeAsString,taskById.TaskDescription,dateAsString,taskById.Address,statsAsString);

        }

        public IEnumerable<TaskToShow> GetOpenedTaskFromService()
        {
            var tasks = repo.GetAll().Where(x=>x.status==Status.open);
            var list = new List<TaskToShow>();
            foreach (var task in tasks)
            {
                string typeAsString = task.Type.ToString();
                string dateAsString = task.DateAndTime.ToString();
                string statsAsString = task.status.ToString();
                list.Add(new TaskToShow(task.IdTask, typeAsString, task.TaskDescription, dateAsString, task.Address, statsAsString));
            }
            return list;
        }

        public void UpdateStatus(int id, string status)
        {
            UpdateTask(id, new TaskToUpdate(null, null, null, null, status));
        }

       

        public IEnumerable<TaskToShow> FilterTasks(string? skill, string? dateTask, string? location)
        {
            var tasks = repo.GetAll();
            if (skill != null)
                tasks = tasks.Where(t => t.Type.ToString() == skill);
            if (dateTask != null)
                tasks = tasks.Where(t => t.DateAndTime.Equals(dateTask));
            if (location != null)
                tasks = tasks.Where(t => t.Address.Contains(location));
            List<TaskToShow> list = new List<TaskToShow>();
            foreach (var task in tasks)
            {
                string typeAsString = task.Type.ToString();
                string dateAsString = task.DateAndTime.ToString();
                string statsAsString = task.status.ToString();
                list.Add(new TaskToShow(task.IdTask, typeAsString, task.TaskDescription, dateAsString, task.Address, statsAsString));
            }
            return list;
        }
    }
}

