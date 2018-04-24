using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentContext() : base("Homework12")
        { }
    }

}
