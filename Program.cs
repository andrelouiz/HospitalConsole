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
    class Program
    {
        static void Main(string[] args)
        {
            Login();
        }

        private static void Login()
        {
            Console.WriteLine("HOSPITAL MANAGEMENT SYSTEM LOGIN");
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            ConsoleColor origBG = Console.BackgroundColor; // Store original values
            ConsoleColor origFG = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.Red; // Set the block colour (could be anything)
            Console.ForegroundColor = ConsoleColor.Red;
            string pwd = Console.ReadLine(); // read the password
            Console.BackgroundColor = origBG; // revert back to original
            Console.ForegroundColor = origFG;

            //Deserialization
            XDocument xDoc;
            xDoc = XDocument.Load("users.xml");
            var selected_user = from x in xDoc.Descendants("users").Where
                                (x => (string)x.Element("username") == user)
                                select new 
                                {
                                    UserName = x.Element("username").Value,
                                    Password = x.Element("pwd").Value,
                                    Title = x.Element("role").Value,

                                };

            foreach (var x in selected_user)
            {
                user = x.UserName;
                pwd = x.Password;


                //Login box check
                if (user == x.UserName)
                {
                    if (pwd == x.Password)
                    {
                        Menu();
                    }

                    if (pwd != x.Password || user != x.UserName)
                    {
                        Console.WriteLine("Wrong credentials.");
                        Login();
                    }

                }
            }
        }

        static void Menu()
        { 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hospital Management System");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Employee's list \n 2 - Doctor's Specializations \n 3 - Work Schedule \n 4 - New User \n 5 - Exit  ");


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
                             select new
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

                ReturnKey();
            }

            static void Schedules()
            {
                Console.Clear();
                Console.WriteLine("Schedules for Doctors");
            }

            static void NewUser()
            {
                Console.Clear();
                Console.WriteLine("Add new user");
                var contacts = new Contacts();
                for (int i = 0; i < 1; i++)
                {

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
                    Menu();
                }

            }
        }

    }


}
