using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum Status
    {
        open, checkered, completed
    }
    public class TaskVolunteer
    {
        [Key]
        public int IdTask { get; init; }// משנה שאפשר להכניס ערך פעם אחת בלבד
        public Skills Type { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Address { get; set; }
        public Status status { get; set; }

    }
}
