using DBAtsiskaitymas.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas
{
    public static class Menu
    {
        public static void Init(Context dbContext)
        {
            string menu = "";
            while (true)
            {
                Console.Clear();
                DrawMenu();
                Console.Write("Select menu option : ");
                menu = Console.ReadLine();
                DrawSubMenu(menu, dbContext);
            }
        }
        public static void DrawSubMenu(string menu, Context dbContext)
        {
            switch (menu)
            {
                case "1" :
                    Console.WriteLine("Awailable departments : ");
                    DepartmentsFunctions.PrintDepartments(dbContext);
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Awailable courses : ");
                    CoursesFunctions.PrintCourses(dbContext);
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Awailable students : ");
                    StudentsFunctions.PrintStudents(dbContext);
                    Console.ReadKey();
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        public static void DrawMenu()
        {
            Console.WriteLine("[1]Departments [2]Courses [3]Students [Q]Exit");
        }
    }
}
