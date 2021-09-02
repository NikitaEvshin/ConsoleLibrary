using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Userregistration
    {
        public string Login;
        public string Password;

        public override string ToString()
        {
            return $"\t {Login}  \t {Password}";
        }
    }
}
