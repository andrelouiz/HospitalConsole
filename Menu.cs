using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hospital
{
    class Menu
    {
        public void Login()
        {
            Console.WriteLine("HOSPITAL MANAGEMENT SYSTEM - LOGIN");
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pwd = Console.ReadLine();
   
            XDocument xDoc;
            xDoc = XDocument.Load("users.xml");
            var userSelection = from x in xDoc.Descendants("users").Where
                                (x => (string)x.Element("username") == user)
                                select new Logon
                                {
                                    Password = x.Element("pwd").Value,
                                    Title = x.Element("role").Value,
                                };

            foreach (var x in userSelection)
            {
                user = x.UserName;
                pwd = x.Password;
                //Login box check
                if (user == x.UserName && pwd == x.Password)
                {
                    if (x.Title == "Admin")
                    {
                        AdminMenu();
                    }
                    else if (x.Title == "Doctor" || x.Title == "Nurse")
                    {
                        MainMenu();
                    }
                    else if (pwd != x.Password || user != x.UserName)
                    {
                        Console.WriteLine("Wrong credentials.");
                        Login();
                    }
                }
            }
        }
        public static void AdminMenu()
        {
            Console.Clear();
            Staff staff = new Staff();
            staff.Title = "Admin";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hospital Management System \nLogged in as: " + staff.Title + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Employee's list \n 2 - Doctor's Specializations \n 3 - Work Schedule \n 4 - Add New User \n 5 - Add New Schedule \n 6 - Exit  ");

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
                        NewUser();
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
                XDocument xDoc;
                xDoc = XDocument.Load("Employees.xml");

                var result = from q in xDoc.Descendants("Staff")
                             select new Staff
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Pesel = q.Element("Pesel").Value,
                                 Title = q.Element("Title").Value,
                             };
                foreach (var staff in result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("First name: {0} \tLast name: {1} \tPesel: {2} Title: {3}", staff.FirstName, staff.LastName, staff.Pesel, staff.Title);
                }

                Console.WriteLine("Press 'Enter' to return to the Main menu.");

                ReturnKeyAdm();
            }
            static void Roles()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor's Specializations");
                XDocument xDoc;
                xDoc = XDocument.Load("Doctors.xml");

                var result = from q in xDoc.Descendants("Employee")
                             select new
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Specialization = q.Element("Specialization").Value,
                             };

                foreach (var emp in result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("First name: {0} \tLast name: {1} \tSpecialization: {2}", emp.FirstName, emp.LastName, emp.Specialization);
                }
                ReturnKeyAdm();

            }
            static void Schedules()
            {
                Console.Clear();
                XDocument xDoc;
                xDoc = XDocument.Load("Schedule.xml");

                var result = from q in xDoc.Descendants("Schedules")
                             select new Schedules
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Title = q.Element("Title").Value,
                                 Schedule = q.Element("Schedule").Value,
                             };
                foreach (var sched in result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("First name: {0} \tLast name: {1} \tTitle: {2} \t Schedule: {3} ", sched.FirstName, sched.LastName, sched.Title, sched.Schedule);
                }

                ReturnKeyAdm();
            }

            static void NewUser()
            {   
                Console.WriteLine("Create a new user \n");
                Staff newStaff = new Staff();
                    Console.Write("First Name: ");
                    newStaff.FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    newStaff.LastName = Console.ReadLine();
                    Console.Write("Pesel Number: ");
                    newStaff.Pesel = Console.ReadLine();
                    Console.Write("Job Title: ");
                    newStaff.Title = Console.ReadLine();

                string path = Path.Combine(Environment.CurrentDirectory, "Employees.xml");
                XmlSerializer xs = new XmlSerializer(typeof(Staff));
                using(FileStream stream = File.Create(path))
                {
                    xs.Serialize(stream, newStaff);
                }
                Console.WriteLine("Employee added sucessfuly!");

                ReturnKeyAdm();
            }

            static void NewSchedule()
            {
                Console.WriteLine("Schedule Management");
                Schedules schedule = new Schedules();
                Console.WriteLine("First Name of the employee");
                schedule.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name of the employee");
                schedule.LastName = Console.ReadLine();
                Console.WriteLine("Job title of the employee");
                schedule.Title = Console.ReadLine();
                Console.WriteLine("Please enter the date you would like to add a new shift (e.g. 12/31/2021 16:00)");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                schedule.Schedule = dateTime.ToString();

                string path = Path.Combine(Environment.CurrentDirectory, "Schedules.xml");
                XmlSerializer xs = new XmlSerializer(typeof(Schedules));
                using (FileStream stream = File.Create(path))
                {
                    xs.Serialize(stream, schedule);
                }
                Console.WriteLine("Shift added sucessfully.");
                ReturnKeyAdm();
            }
        }
        static void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hospital Management System");
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
                XDocument xDoc;
                xDoc = XDocument.Load("Employees.xml");

                var result = from q in xDoc.Descendants("Employee")
                             select new Staff
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Pesel = q.Element("Pesel").Value,
                                 Title = q.Element("Title").Value,
                             };
                foreach (var emp in result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("First name: {0} \tLast name: {1} \tPesel: {2} Title: {3}", emp.FirstName, emp.LastName, emp.Pesel, emp.Title);
                }
                ReturnKey();
            }
            static void Roles()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor's Specializations");
                XDocument xDoc;
                xDoc = XDocument.Load("Doctors.xml");

                var result = from q in xDoc.Descendants("Employee")
                             select new Doctor
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Specialization = q.Element("Specialization").Value,
                             };

                foreach (var emp in result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("First name: {0} \tLast name: {1} \tSpecialization: {2}", emp.FirstName, emp.LastName, emp.Specialization);
                }
                ReturnKey();
            }

            static void Schedules()
            {
                Console.Clear();
                Console.WriteLine("Schedules for Doctors");
                ReturnKey();
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
                AdminMenu();
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
                MainMenu();
            }

        }

    }
}
