using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models
{
    internal class MyRegexException : Exception
    {
        MyRegexException() { }
        public MyRegexException(string message) : base(message) { }
    }
}
