using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Atsiskaitymas.Entities
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        { 
        
        }
        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Courses = new List<Course>();
        }
    }
}
