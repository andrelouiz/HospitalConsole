using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hospital
{
    public class MainMenu
    {
        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hospital Management System \n Logged in as user");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Employee's list \n 2 - Doctor's Specializations \n 3 - Work Schedule \n 4 - Exit  ");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        EmployeeList();
                        break;
                    case "2":
                        Roles();
                        break;
                    case "3":
                        Schedules();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }

            static void EmployeeList()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hospital Employee's List");

                List<Staff> employees = new List<Staff>();
                XmlSerializer xml = new XmlSerializer(typeof(List<Staff>));
                using (FileStream load = File.Open(@"Employees.xml", FileMode.Open))
                    employees = (List<Staff>)xml.Deserialize(load);
                foreach (var staff in employees)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    staff.Listing();
                }

                ReturnKey();
            }
            static void Roles()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor's Specializations");

                List<Staff> roles = new List<Staff>();
                XmlSerializer xml = new XmlSerializer(typeof(List<Staff>));
                using (FileStream load = File.Open(@"Employees.xml", FileMode.Open))
                    roles = (List<Staff>)xml.Deserialize(load);

                foreach (var docs in roles)
                {
                    if (docs.Title.Equals("Doctor"))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        docs.Specializations();
                    }
                }

                ReturnKey();
            }

            static void Schedules()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor's Schedules");

                List<Schedules> timesheet = new List<Schedules>();
                XmlSerializer xml = new XmlSerializer(typeof(List<Schedules>));
                using (FileStream load = File.Open(@"Schedule.xml", FileMode.Open))
                    timesheet = (List<Schedules>)xml.Deserialize(load);

                foreach (var sched in timesheet)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    sched.Scheduletable();
                }
                ReturnKey();
            }
        }

        static void ReturnKey()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press 'Enter' to return to Menu.");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                MainMenu.Menu();
            }
        }
    }
}
