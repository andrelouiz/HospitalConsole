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
    public class Staff
    {   //Properties

        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Pesel")]
        protected string Pesel { get; set; }
        [XmlElement("Title")]
        protected string Title { get; set; }
        [XmlElement("Specialization")]
        public string Specialization { get; set; }

        //Encapsulation
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

        public void Listing() 
        {  
            Console.WriteLine("First Name: {0} \tLast Name: {1} \tPesel: {2} \tTitle: {3}", FirstName, LastName, Pesel, Title);
        }
        public void Specializations() 
        {
            Console.WriteLine("First name: {0} \tLast name: {1} \tTitle: {2} \tSpecialization: {3}", FirstName, LastName, Title, Specialization);
        }

    }
  
    [Serializable]
    public class Schedules : Staff //Inheritance
    {
        [XmlElement("Schedule")]
        public string Schedule { get; set; }

        public void Scheduletable()
        {   
            // Polymorphism
            Console.WriteLine("First Name: {0} \tLast Name: {1} \tTitle: {2} \t Schedule: {3} ", FirstName, LastName, Title, Schedule);
        }
    }



}
