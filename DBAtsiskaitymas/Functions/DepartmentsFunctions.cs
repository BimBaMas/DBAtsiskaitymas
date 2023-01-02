using DBAtsiskaitymas.Entities;
using DBAtsiskaitymas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas.Functions
{
    public static class DepartmentsFunctions
    {
        public static void PrintDepartmentWithStudents(Context dbContext)
        {
            Awailable(dbContext);
            int id = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == id).First();
            Console.WriteLine($"[{department.Id}] {department.Name} students : ");
            if (department.Students.Count > 0)
            {
                foreach (var student in department.Students)
                {
                    Console.WriteLine($"{student.Id} {student.Name} {student.Surname}");
                }
            }
            else
            {
                Console.WriteLine("Department does not have any students.");
            }
        }
        public static void PrintDepartmentWithCourses(Context dbContext)
        {
            Awailable(dbContext);
            int id = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            var department = dbContext.Departments.Include("Courses").Where(x => x.Id == id).First();
            Console.WriteLine($"[{department.Id}] {department.Name} courses : ");
            PrintDepartmentCourses(department);
        }

        public static void PrintDepartmentCourses(Department department)
        {
            if (department.Courses.Count > 0)
            {
                foreach (var course in department.Courses)
                {
                    Console.WriteLine($"{course.Id} {course.Name}");
                }
            }
            else
            {
                Console.WriteLine("Department does not have any courses.");
            }
        }        
        public static void AddDepartment(Context dbContext)
        {
            Console.Write("Enter name for new department : ");
            string name = Console.ReadLine();
            if (name.Length > 0)
            {
                dbContext.Departments.Add(new Department(name));
                dbContext.SaveChanges();
                Console.WriteLine("Department added.");
            }
        }
        public static void DeleteDepartment(Context dbContext)
        {
            Awailable(dbContext);
            Console.Write("Enter department ID which you want to delete : ");
            int id = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == id).First();
            var students = department.Students;
            dbContext.Students.RemoveRange(students);
            dbContext.Departments.Remove(department);
            dbContext.SaveChanges();
            Console.WriteLine("Department deleted.");
        }        
        public static void AddStudent(Context dbContext)
        {
            StudentsFunctions.Awailable(dbContext);            
            int studentId = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            Awailable(dbContext);            
            int departmentId = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == departmentId).First();
            var student = dbContext.Students.Include("Courses").Where(x => x.Id == studentId).First();
            student.DepartmentId = departmentId;
            student.Courses.Clear();
            department.Students.Add(student);
            dbContext.SaveChanges();
            Console.WriteLine("Student added/moved to department.");
        }        
        public static void AddCourse(Context dbContext)
        {
            Awailable(dbContext);
            int departmentId = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            CoursesFunctions.Awailable(dbContext);            
            int courseId = int.Parse(Console.ReadLine());
            Menu.DrawMenu();
            var department = dbContext.Departments.Include("Courses").Where(x => x.Id == departmentId).First();
            var course = dbContext.Courses.Where(x => x.Id == courseId).First();
            department.Courses.Add(course);
            dbContext.SaveChanges();
        }
        public static void Awailable(Context dbContext)
        {
            Console.WriteLine("Awailable departments : ");
            PrintDepartments(dbContext);
            Console.Write("Enter department ID : ");
        }
        public static void PrintDepartments(Context dbContext)
        {
            var departments = dbContext.Departments;
            foreach (var department in departments)
            {
                Console.WriteLine($"[{department.Id}]{department.Name}");
            }
        }
    }
}
