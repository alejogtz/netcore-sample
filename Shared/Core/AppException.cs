using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Core
{
    public class AppException : Exception
    {
        public AppException(string mensaje):base(mensaje)
        {

        }
    }
}
