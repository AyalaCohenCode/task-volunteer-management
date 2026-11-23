using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Skills
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public List<Volunteer> volunteers { get; set; }
    }
}
