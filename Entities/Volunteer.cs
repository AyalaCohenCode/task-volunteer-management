using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //public enum Skill//תחומי התמחות
    //{
    //    babysitter, cooking, transportation,cleaning, UnKnown
    //}
    public class Volunteer
    {
        public int Id { get; init; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<Skills> Skills { get; set; }= new List<Skills>();
    }
}
