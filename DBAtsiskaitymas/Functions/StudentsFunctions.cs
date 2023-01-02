using DBAtsiskaitymas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas.Functions
{
    public static class StudentsFunctions
    {
        public static void PrintStudentWithCourses(Context dbContext)
        {
            Console.Write("Enter student ID : ");
            int id = int.Parse(Console.ReadLine());
            var student = dbContext.Students.Include("Courses").Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                Console.WriteLine($"Student ID : {student.Id} Name, surname : {student.Name} {student.Surname}");
                if (student.Courses.Count > 0)
                {
                    Console.WriteLine("Student courses : ");
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine($"{course.Id} {course.Name}");
                    }
                }
                else 
                {
                    Console.WriteLine("This student does not have any courses.");
                }
            }
            else
            {
                Console.WriteLine("Student does not exist!");            }

        }

        public static void CreateStudent(Context dbContext)
        {
            Console.Write("Enter students name : ");
            string name = Console.ReadLine();
            Console.Write("Enter students surname : ");
            string surname = Console.ReadLine();
            Console.Write("Enter department ID : ");
            int departmentId = int.Parse(Console.ReadLine());
            Student student = new Student(name, surname, departmentId);
            AddCourses(student, dbContext);
            dbContext.Departments.Where(x => x.Id == departmentId).First().Students.Add(student);
            dbContext.SaveChanges();
        }
        public static void ChangeDepartment(Context dbContext)
        {
            Console.Write("Enter students ID : ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter department ID : ");
            int departmentId = int.Parse(Console.ReadLine());
            var student = dbContext.Students.Where(x => x.Id == studentId).First();
            student.DepartmentId = departmentId;
            AddCourses(student, dbContext);
            student.Courses.Clear();
            dbContext.SaveChanges();
        }
        public static void AddCourses(Student student, Context dbContext)
        {
            Console.WriteLine("Enter students course ID's separated by space : ");
            string courses = Console.ReadLine();
            List<int> coursesId = courses.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            foreach (int courseId in coursesId)
            {
                student.Courses.Add(dbContext.Courses.Where(x => x.Id == courseId).First());
            }
        }
        public static void PrintStudents(Context dbContext)
        {
            var students = dbContext.Students;
            foreach (var student in students)
                Console.WriteLine($"[{student.Id}]{student.Name} {student.Surname}");
        }
    }
}
