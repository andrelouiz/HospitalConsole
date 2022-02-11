using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hospital
{   
    [Serializable]
    public abstract class Database
    {   
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Pesel")]
        public string Pesel { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Specialization")]
        public string Specialization { get; set; }

        [XmlElement("Password")]
        private string password; 
        public string Password 
        {
            get { return password; }
            set { password = value; }
        }
        [XmlElement("Username")]
        private string username; 
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName} \tLast Name: {this.LastName} \tPesel: {this.Pesel} \tTitle: {this.Title}"; 
        }
    }
    public class Staff : Database
    {

    }

    public class Specializations : Staff
    {
        public override string ToString()
        {
            return $"First name: {this.FirstName} \tLast name: {this.LastName} \tTitle: {this.Title} \tSpecialization: {this.Specialization}";
        }
    }

    [Serializable]
    public class Schedules : Staff //Inheritance
    {
        [XmlElement("Schedule")]
        public string Schedule { get; set; }

        public void Scheduletable()
        {   
            Console.WriteLine("First Name: {0} \tLast Name: {1} \tTitle: {2} \t Schedule: {3} ", FirstName, LastName, Title, Schedule);
        }

    }

}
