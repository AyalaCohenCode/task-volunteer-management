using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int VolunteerId { get; set; }
        public DateTime EndDate { get; set; }
    }
}
