using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repotroty
{
    public  class DataContext:DbContext
    {
        //רשימת שיבוצים
        public  DbSet<Assignment> Assignments { get; set; }
        //רשימת משימות
        public  DbSet<TaskVolunteer> Tasks { get; set; }
        //רשימת מתנדבות
        public  DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Skills> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {        
             optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ChesedDB");}   

        //public List<Skill> Skills { get; set; }
        //static DataContext()
        //{
        //    Assignments=new List<Assignment>()
        //    {
        //    new Assignment() { TaskId = 111, VolunteerId = 1 },
        //    new Assignment() { TaskId = 444, VolunteerId = 2 },
        //    new Assignment() { TaskId = 333, VolunteerId = 3 },
        //    new Assignment() { TaskId = 222, VolunteerId = 1 }
        //    };
        //    Tasks = new()
        //    {
        //     new TaskVolunteer(){IdTask=111,Type=Skill.cooking,TaskDescription=" two babys",DateAndTime=new DateTime(2006,1,12),Address="boblik 3 Jerusalem",status=Status.checkered},
        //     new TaskVolunteer(){IdTask=222,Type=Skill.cleaning,TaskDescription="Floor washing",DateAndTime=new DateTime(2026,02,15),Address="yoshef vaiz 3 Jerusalem",status=Status.checkered},
        //     new TaskVolunteer(){IdTask=333,Type=Skill.transportation,TaskDescription="Transportation for girls",DateAndTime=new DateTime(2016,10,02),Address="beit adfos 10 Jerusalem ",status=Status.checkered},
        //     new TaskVolunteer(){IdTask=444,Type=Skill.cooking,TaskDescription="dinner",DateAndTime=new DateTime(2024,10,19),Address="achida 14 Ashdod",status=Status.checkered},
        //     new TaskVolunteer(){IdTask=555,Type=Skill.transportation,TaskDescription="Transportation for girls",DateAndTime=new DateTime(2016,10,02),Address="beit adfos 10 Jerusalem ",status=Status.completed},
        //     new TaskVolunteer(){IdTask=666,Type=Skill.cooking,TaskDescription="dinner",DateAndTime=new DateTime(2024,10,19),Address="achida 14 Ashdod",status=Status.open},

        //    };
        //    Volunteers = new() {
        //     new Volunteer(){Id=1, FullName="Yael Malka", PhoneNumber="053-3150812", EmailAddress="ym173@gmail.com"},
        //     new Volunteer(){Id=2, FullName="David Cohen", PhoneNumber="050-1234567", EmailAddress="david.cohen@gmail.com"},
        //     new Volunteer(){Id=3, FullName="Sara Levi", PhoneNumber="054-9876543", EmailAddress="sara.levi@gmail.com"},
        //     new Volunteer(){Id=4, FullName="Michael Stein", PhoneNumber="052-5556666", EmailAddress="michael.stein@gmail.com"},
        //     new Volunteer(){Id=5, FullName="Rachel Schwartz", PhoneNumber="057-2345678", EmailAddress="rachel.schwartz@gmail.com"},
        //     new Volunteer(){Id=6, FullName="Yonatan Green", PhoneNumber="053-8765432", EmailAddress="yonatan.green@gmail.com"},
        //     new Volunteer(){Id=7, FullName="Rachely Arguan", PhoneNumber="057-2345268", EmailAddress="racheli.Arguan@gmail.com"},
        //     new Volunteer(){Id=8, FullName="noa cohen", PhoneNumber="053-8761416", EmailAddress="noa.cohen@gmail.com"}
        //    };
        //    Volunteers[0].Skills.Add(Skill.cooking);
        //    Volunteers[0].Skills.Add(Skill.cleaning);
        //    Volunteers[0].Skills.Add(Skill.babysitter);
        //    Volunteers[1].Skills.Add(Skill.cooking);
        //    Volunteers[2].Skills.Add(Skill.cooking);
        //    Volunteers[2].Skills.Add(Skill.transportation);
        //    Volunteers[3].Skills.Add(Skill.transportation);
        //    Volunteers[4].Skills.Add(Skill.cleaning);
        //    Volunteers[4].Skills.Add(Skill.cleaning);
        //    Volunteers[4].Skills.Add(Skill.cooking);
        //    Volunteers[5].Skills.Add(Skill.transportation);
        //    Volunteers[6].Skills.Add(Skill.cooking);
        //    Volunteers[7].Skills.Add(Skill.transportation);

        //}
    }
}
