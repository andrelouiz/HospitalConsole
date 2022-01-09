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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Title { get; set; }

        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Staff));
                xml.Serialize(stream, this);
            }
        }
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
    class Doctor : MedicalStaff
    {
        public string Specialization { get; set; }
    }

  
}
