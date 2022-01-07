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
            Menu();

        }
        static void Menu() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hospital Management System");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Employee's list \n 2 - Doctor's Specializations \n 3 - Work Schedule \n ");


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
