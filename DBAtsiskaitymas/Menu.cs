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
                DrawMenu();                
                menu = Console.ReadKey().KeyChar.ToString();
                Console.CursorLeft = 0;
                Console.Write(" ");
                DrawSubMenu(menu, dbContext);                
            }
        }
        public static void SetCursor(int left)
        {
            Console.CursorLeft = left;
        }
        public static void DrawSubMenu(string menu, Context dbContext)
        {
            string subMenu = "";
            SetColor();
            switch (menu)
            {
                case "1" :
                    SetCursor(4); Console.WriteLine("| [1]Department students       |");
                    SetCursor(4); Console.WriteLine("| [2]Department courses        |");
                    SetCursor(4); Console.WriteLine("| [3]Create department         |");
                    SetCursor(4); Console.WriteLine("| [4]Delete department         |");
                    SetCursor(4); Console.WriteLine("| [5]Add student to department |");
                    SetCursor(4); Console.WriteLine("| [6]Add course to department  |"); 
                    Console.ResetColor();
                    subMenu = Console.ReadKey().KeyChar.ToString();
                    if (!subMenu.Equals("/u001b"))
                        SelectFunction(menu + subMenu, dbContext);                    
                    break;
                case "2":
                    SetCursor(23); Console.WriteLine("| [1]Create new course |");
                    SetCursor(23); Console.WriteLine("| [2]Delete course     |");
                    Console.ResetColor();
                    subMenu = Console.ReadKey().KeyChar.ToString();
                    if (!subMenu.Equals("/u001b"))
                        SelectFunction(menu + subMenu, dbContext);                    
                    break;
                case "3":
                    SetCursor(42); Console.WriteLine("| [1]Student courses            |");
                    SetCursor(42); Console.WriteLine("| [2]Create new student         |");
                    SetCursor(42); Console.WriteLine("| [3]Change students department |");
                    SetCursor(42); Console.WriteLine("| [4]Add courses for student    |");
                    Console.ResetColor();
                    subMenu = Console.ReadKey().KeyChar.ToString();
                    if (!subMenu.Equals("/u001b"))
                        SelectFunction(menu + subMenu, dbContext);
                    break;
                case "Q":
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                case "q":
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        public static void SelectFunction(string key, Context dbContext)
        {
            Console.Clear();
            DrawMenu();
            switch (key)
            {
                case "11" :
                    DepartmentsFunctions.PrintDepartmentWithStudents(dbContext);
                    Console.ReadKey();
                    break;
                case "12":
                    DepartmentsFunctions.PrintDepartmentWithCourses(dbContext);
                    Console.ReadKey();
                    break;
                case "13":
                    DepartmentsFunctions.AddDepartment(dbContext);
                    Console.ReadKey();
                    break;
                case "14":
                    DepartmentsFunctions.DeleteDepartment(dbContext);
                    Console.ReadKey();
                    break;
                case "15":
                    DepartmentsFunctions.AddStudent(dbContext);
                    Console.ReadKey();
                    break;
                case "16":
                    DepartmentsFunctions.AddCourse(dbContext);
                    Console.ReadKey();
                    break;
                case "21":
                    CoursesFunctions.CreateNewCourseAndAddToDepartment(dbContext);
                    Console.ReadKey();
                    break;
                case "22":
                    CoursesFunctions.DeleteCourse(dbContext);
                    Console.ReadKey();
                    break;
                case "31":
                    StudentsFunctions.PrintStudentWithCourses(dbContext);
                    Console.ReadKey();
                    break;
                case "32":
                    StudentsFunctions.CreateStudent(dbContext);
                    Console.ReadKey();
                    break;
                case "33":
                    StudentsFunctions.ChangeDepartment(dbContext);
                    Console.ReadKey();
                    break;
                case "34":
                    StudentsFunctions.AddCoursesForStudent(dbContext);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        // /u001b
        public static void DrawMenu()
        {
            Console.Clear();
            SetColor();
            Console.Write("| [1]Departments |");
            Console.ResetColor(); Console.Write(" "); SetColor();
            Console.Write("| [2]Courses     |");
            Console.ResetColor(); Console.Write(" "); SetColor();
            Console.Write("| [3]Students    |");
            Console.ResetColor(); Console.Write(" "); SetColor();
            Console.WriteLine("| [Q]Exit        |");
            Console.ResetColor();
            Console.WriteLine("");
        }
        public static void SetColor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
        }
    }
}
