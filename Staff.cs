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
    {
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
    class Logon : Staff
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }
        [XmlElement("Password")]
        public string Password { get; set; }
    }
    [Serializable]
    public class Schedules : Staff
    {
        [XmlElement("Schedule")]
        public string Schedule { get; set; }
        [XmlElement("AddShift")]
        public string AddShift { get; set; }
    }
    [Serializable]
    class Doctor : Schedules
    {
        [XmlElement("Specialization")]
        public string Specialization { get; set; }
    }

  
}
