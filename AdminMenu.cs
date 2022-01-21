using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hospital
{
    class AdminMenu 
    {
        public static void AdminsMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hospital Management System \nLogged in as: Admin\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Employee's list \n 2 - Doctor's Specializations \n 3 - Work Schedule \n 4 - Add New Employee \n 5 - Add New Schedule \n 6 - Exit  ");

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
                        NewEmployee();
                        break;
                    case "5":
                        NewSchedule();
                        break;
                    case "6":
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
                ReturnKeyAdm();
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
                    if (docs.Title.Equals("Doctor"))//node title = doctor
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        docs.Specializations();
                    }
                }
                ReturnKeyAdm();
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
                ReturnKeyAdm();
            }

            static void NewEmployee() 
            {
                Console.Clear();
                List<Staff> staffs = new List<Staff>();
                XmlSerializer xml = new XmlSerializer(typeof(List<Staff>));
                using (FileStream load = File.Open(@"Employees.xml", FileMode.Open))
                staffs = (List<Staff>)xml.Deserialize(load);

                Staff newStaff = new Staff();
                Console.WriteLine("Create a new user \n");
                Console.Write("First Name: ");
                newStaff.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                newStaff.LastName = Console.ReadLine();
                Console.Write("Pesel Number: ");
                newStaff.Pesel = Console.ReadLine();
                Console.Write("Job Title: ");
                newStaff.Title = Console.ReadLine();
                Console.Write("Specialization: ");
                newStaff.Specialization = Console.ReadLine();
                Console.Write("Username: ");
                newStaff.Username = Console.ReadLine();
                Console.Write("Password: ");
                newStaff.Password = Console.ReadLine();

                staffs.Add(newStaff);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Staff>));
                StreamWriter sw = new StreamWriter("Employees.xml");
                xmlSerializer.Serialize(sw, staffs);
                sw.Close();

                Console.WriteLine("Employee added sucessfuly!");
                ReturnKeyAdm();
            }

            static void NewSchedule()
            {
                Console.Clear();
                List<Schedules> timesheet = new List<Schedules>();
                XmlSerializer xml = new XmlSerializer(typeof(List<Schedules>));
                using (FileStream load = File.Open(@"Schedule.xml", FileMode.Open))
                timesheet = (List<Schedules>)xml.Deserialize(load);

                Console.WriteLine("Schedule Management");
                Schedules schedule = new Schedules();
                Console.Write("First Name of the employee: ");
                schedule.FirstName = Console.ReadLine();
                Console.Write("Last Name of the employee: ");
                schedule.LastName = Console.ReadLine();
                Console.Write("Job title of the employee: ");
                schedule.Title = Console.ReadLine();
                Console.Write("Please enter the date you would like to add a new shift (e.g. 12/31/2021 16:00): ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                schedule.Schedule = dateTime.ToString();
                timesheet.Add(schedule);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Schedules>));
                StreamWriter sw = new StreamWriter("Schedule.xml");
                xmlSerializer.Serialize(sw, timesheet);
                sw.Close();
                Console.WriteLine("Shift added sucessfully.");
                ReturnKeyAdm();
            }
        }
        static void ReturnKeyAdm()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press 'Enter' to return to Menu.");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                AdminMenu.AdminsMenu();
            }
        }
    }
}
