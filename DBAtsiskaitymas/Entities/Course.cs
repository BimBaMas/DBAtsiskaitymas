using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Atsiskaitymas.Entities
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /*[ForeignKey("Departamentas")]
        public int Departamentas_Id { get; set; }*/
        public string Name{ get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public Course()
        {

        }
        public Course(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }
    }
}
