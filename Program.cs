using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {   //instatiating the object login
            Login login = new Login();
            login.LoginScreen();

        }
    }
}
