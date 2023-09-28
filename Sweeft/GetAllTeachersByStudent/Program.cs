using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GetAllTeachersByStudent
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Subject { get; set; }
        public ICollection<Pupil> Pupils { get; set; }
    }

    public class Pupil
    {
        public int PupilID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
    }
}