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
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    [Serializable]
    class MedicalStaff : Staff
    {
   
        public string Schedule { get; set; }
        public string AddShift { get; set; }

    }
    [Serializable]
    class Doctor : Staff
    {
        public string Specialization { get; set; }

    }


}
