using DBAtsiskaitymas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas.Functions
{
    public static class CoursesFunctions
    {
        public static void CreateNewCourseAndAddToDepartment(Context dbContext)
        {
            Console.Write("Enter name for new course : ");
            string name = Console.ReadLine();
            Course course = new Course(name);
            Console.Write("Enter department ID's for this course separated by space : ");
            string departments = Console.ReadLine();
            List<int> departmentsId = departments.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            foreach (int departmentId in departmentsId)
            {
                course.Departments.Add(dbContext.Departments.Where(x => x.Id == departmentId).First());
            }
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
        }
        public static void Awailable(Context dbContext)
        {
            Console.WriteLine("Awailable courses : ");
            PrintCourses(dbContext);
            Console.Write("Enter course ID : ");
        }
        public static void PrintCourses(Context dbContext)
        {
            var courses = dbContext.Courses;
            foreach (var course in courses)
            {
                Console.WriteLine($"[{course.Id}]{course.Name}");
            }
        }
    }
}
