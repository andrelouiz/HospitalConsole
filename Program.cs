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

                }
            }

            static void EmployeeList()
            {
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
                    Console.WriteLine("First name: {0}, Last name: {1}, Pesel: {2}, Title: {3}", emp.FirstName, emp.LastName, emp.Pesel, emp.Title);
                }
                Console.ReadKey();


            }
            static void Roles()
            {
                Console.Clear();
                Console.WriteLine("Doctor's Specializations");
                XDocument xDoc;
                xDoc = XDocument.Load("Employees.xml");

                var result = from q in xDoc.Descendants("Employee")
                             select new Doctor
                             {
                                 FirstName = q.Element("FirstName").Value,
                                 LastName = q.Element("LastName").Value,
                                 Specialization = q.Element("Specialization").Value,
                             };

                foreach (var emp in result)
                {
                    Console.WriteLine("First name: {0}, Last name: {1}, Pesel: {2}, Title: {3} Specialization: {3}", emp.FirstName, emp.LastName, emp.Specialization);
                }
                Console.ReadKey();

            }

            static void Schedules()
            {
                Console.WriteLine("Schedules");
            }

            static void NewUser()
            {



            }
        }


    }

}
