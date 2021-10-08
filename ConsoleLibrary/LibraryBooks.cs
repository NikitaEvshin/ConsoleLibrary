using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class LibraryBook
    {
        public string Author;
        public string NameBook;
        public bool IsTaked;
        public string StudentName;

        public LibraryBook()
        {
        }
        public override string ToString()
        {
            return $"\t {Author} \t {NameBook} \t {IsTaked} \t {StudentName}";
        }
    }
}
