using DBAtsiskaitymas.Entities;
using Microsoft.EntityFrameworkCore;
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
            DepartmentsFunctions.Awailable(dbContext);
            Console.Write("(You can enter more departmens separating ID's by space) : ");
            string departments = Console.ReadLine();
            List<int> departmentsId = departments.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            foreach (int departmentId in departmentsId)
            {
                course.Departments.Add(dbContext.Departments.Where(x => x.Id == departmentId).First());
            }
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            Console.WriteLine("Course added.");
        }
        public static void DeleteCourse(Context dbContext)
        {
            Awailable(dbContext);
            int id = int.Parse(Console.ReadLine());
            var course = dbContext.Courses.Where(x => x.Id == id).First();
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            Console.WriteLine("Course removed.");
        }
        public static void Awailable(Context dbContext)
        {
            Console.WriteLine("Awailable courses : ");
            PrintCourses(dbContext.Courses.ToList());
            Console.Write("Enter course ID : ");
        }
        public static void Awailable(int departamentId, Context dbContext)
        {
            var courses = dbContext.Departments.Include("Courses").Where(x => x.Id == departamentId).First().Courses.ToList();
            Console.WriteLine("Awailable courses : ");
            PrintCourses(courses);
            Console.Write("Enter course ID : ");
        }
        public static void PrintCourses(List<Course> courses)
        {            
            foreach (var course in courses)
            {
                Console.WriteLine($"[{course.Id}]{course.Name}");
            }
        }        
    }
}
