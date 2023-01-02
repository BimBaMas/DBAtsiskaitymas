using DBAtsiskaitymas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas.Data
{
    public static class FillData
    {
        public static void Init()
        {
            Department department1 = new Department("Informatikos fakultetas");
            Department department2 = new Department("Fizikos fakultetas");
            Department department3 = new Department("Chemijos fakultetas");
            Department department4 = new Department("Mechanikos fakultetas");

            Course course1 = new Course("Fizika");
            Course course2 = new Course("Informatika");
            Course course3 = new Course("Chemija");
            Course course4 = new Course("Mechanika");

            Course course5 = new Course("Matematika");
            Course course6 = new Course("Anglu kalba");
            Course course7 = new Course("Kuno kultura");
            Course course8 = new Course("Filosofija");

            Student student1 = new Student("Vardas1", "Pavarde1");
            Student student2 = new Student("Vardas2", "Pavarde2");
            Student student3 = new Student("Vardas3", "Pavarde3");
            Student student4 = new Student("Vardas4", "Pavarde4");
            Student student5 = new Student("Vardas5", "Pavarde5");
            Student student6 = new Student("Vardas6", "Pavarde6");
            Student student7 = new Student("Vardas7", "Pavarde7");
            Student student8 = new Student("Vardas8", "Pavarde8");

            student1.Courses = new List<Course> { course2, course5, course8 };
            student2.Courses = new List<Course> { course2, course6, course7 };
            student3.Courses = new List<Course> { course1, course5, course8 };
            student4.Courses = new List<Course> { course1, course6, course7 };
            student5.Courses = new List<Course> { course3, course5, course8 };
            student6.Courses = new List<Course> { course3, course6, course7 };
            student7.Courses = new List<Course> { course4, course5, course8 };
            student8.Courses = new List<Course> { course4, course6, course7 };


            department1.Courses = new List<Course> { course2, course5, course6, course7, course8 };
            department1.Students = new List<Student> { student1, student2 };

            department2.Courses = new List<Course> { course1, course5, course6, course7, course8 };
            department2.Students = new List<Student> { student3, student4 };

            department3.Courses = new List<Course> { course3, course5, course6, course7, course8 };
            department3.Students = new List<Student> { student5, student6 };

            department4.Courses = new List<Course> { course4, course5, course6, course7, course8 };
            department4.Students = new List<Student> { student7, student8 };

            Context context = new Context();

            context.Courses.AddRange(course1, course2, course3, course4, course5, course6, course7, course8);
            context.Students.AddRange(student1, student2, student3, student4, student5, student6, student7, student8);
            context.Departments.AddRange(department1, department2, department3, department4);

            context.SaveChanges();
        }
    }
}
