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
            Console.WriteLine("Awailable departments : ");
            PrintDepartments(dbContext);
            Console.Write("Enter department ID : ");
            int id = int.Parse(Console.ReadLine());
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == id).First();
            Console.WriteLine($"Department ID : {department.Id} Department : {department.Name}");
                Console.WriteLine("Department students : ");
                foreach (var student in department.Students)
                {
                    Console.WriteLine($"{student.Id} {student.Name} {student.Surname}");
                }            
        }
        public static void PrintDepartmentWithCourses(Context dbContext)
        {
            Console.Write("Enter department ID : ");
            int id = int.Parse(Console.ReadLine());
            var department = dbContext.Departments.Include("Courses").Where(x => x.Id == id).First();
            Console.WriteLine($"Department ID : {department.Id} Department : {department.Name}");
            PrintDepartmentCourses(department);
        }

        public static void PrintDepartmentCourses(Department department)
        {
            Console.WriteLine("Department courses : ");
            foreach (var course in department.Courses)
            {
                Console.WriteLine($"{course.Id} {course.Name}");
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
            }
        }
        public static void DeleteDepartment(Context dbContext)
        {
            Console.WriteLine("Enter department ID which you want to delete : ");
            int id = int.Parse(Console.ReadLine());
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == id).First();
            var students = department.Students;
            dbContext.Students.RemoveRange(students);
            dbContext.Departments.Remove(department);
            dbContext.SaveChanges();
        }
        public static void AddStudent(Context dbContext)
        {
            Console.Write("Enter student ID : ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter department ID : ");
            int departmentId = int.Parse(Console.ReadLine());
            var department = dbContext.Departments.Include("Students").Where(x => x.Id == departmentId).First();
            var student = dbContext.Students.Where(x => x.Id == studentId).First();
            student.DepartmentId = departmentId;
            student.Courses.Clear();
            department.Students.Add(student);
            dbContext.SaveChanges();
        }
        public static void AddCourse(Context dbContext)
        {
            Console.Write("Enter course ID : ");
            int courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter department ID : ");
            int departmentId = int.Parse(Console.ReadLine());
            var department = dbContext.Departments.Include("Courses").Where(x => x.Id == departmentId).First();
            var course = dbContext.Courses.Where(x => x.Id == courseId).First();            
            department.Courses.Add(course);
            dbContext.SaveChanges();
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
