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
    class Staff
    {
        public Staff(string firstName, string lastName, string pesel, string title)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Title = title;
        }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Pesel")]
        public string Pesel { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }

    }


    [Serializable]
    class Administrator
    {
        public Administrator(string password, string username)
        {
            this.UserName = username;
            this.Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
    [Serializable]
    class MedicalStaff
    {
        public MedicalStaff(string schedule, string addshift)
        {
            this.AddShift = addshift;
            this.Schedule = schedule;
        }
        public string Schedule { get; set; }
        public string AddShift { get; set; }

    }
    [Serializable]
    class Doctor : Staff
    {
        public Doctor( string specialization, string firstName, string lastName, string pesel, string title) : base (firstName,lastName, pesel, title)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Specialization = specialization;
        }

        public string Specialization { get; set; }

        public override string ToString()
        {
            return "First name: " + FirstName + "Last Name: "+ LastName + "Job Title: " + Title + "\tSpecialization: " + Specialization;
        } 

    }


}
