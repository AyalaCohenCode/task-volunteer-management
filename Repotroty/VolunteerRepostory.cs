using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repotroty
{
    internal class VolunteerRepostory
    {
        DataContext dataContext=new DataContext();
        public List<Volunteer> GetAll() => dataContext.Volunteers.ToList();
        public Volunteer GetById(int id) => dataContext.Volunteers.FirstOrDefault(v => v.Id == id);

        public void Add(Volunteer v) => dataContext.Volunteers.Add(v);
        public void Update(Volunteer Volunteer)
        {
            var VolunteerToUpdate = dataContext.Volunteers.FirstOrDefault(v => v.Id == Volunteer.Id);
            VolunteerToUpdate.FullName = Volunteer.FullName;
            VolunteerToUpdate.PhoneNumber = Volunteer.PhoneNumber;
            VolunteerToUpdate.EmailAddress = Volunteer.EmailAddress;

        }
        public void Delete(int id)
        {
            var VolunteerDelete = dataContext.Volunteers.FirstOrDefault(v => v.Id == id);
            dataContext.Volunteers.Remove(VolunteerDelete);
        }
    }
}
