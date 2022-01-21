using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hospital
{
    public class Login
    {
        public void LoginScreen()
        {
            Console.WriteLine("HOSPITAL MANAGEMENT SYSTEM - LOGIN");

            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pwd = Console.ReadLine();

            List<Staff> employees = new List<Staff>();
            XmlSerializer xml = new XmlSerializer(typeof(List<Staff>));
            using (FileStream load = File.Open(@"Employees.xml", FileMode.Open))
            employees = (List<Staff>)xml.Deserialize(load);

            foreach (var staff in employees)
            {
                if (user.Equals(staff.Username) && pwd.Equals(staff.Password))
                {
                    if (staff.Title.Equals("Admin"))
                    {
                        AdminMenu admin = new AdminMenu();
                        admin.AdminsMenu();
                    }
                    else if (staff.Title.Equals("Doctor") || staff.Title.Equals("Nurse"))
                    {
                        MainMenu menu = new MainMenu();
                        menu.Menu();
                    }
                    else if (pwd != staff.Password || user != staff.Username)
                    {
                        Console.WriteLine("WRONG CREDENTIALS!");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
