using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Archivos.Core
{
    public class PropertiesDocument
    {
        public string Reason { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string image { get; set; }
        public int Page { get; set; }

        public int? X { get; set; }
        public int? Y { get; set; }
    }
}
