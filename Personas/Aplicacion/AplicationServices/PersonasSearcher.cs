using FilemanagerDemo.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Aplicacion.AplicationServices
{
    public class PersonasSearcher
    {
        private IPersonasStoredFunctions storedFunctions;
        public PersonasSearcher(IPersonasStoredFunctions fn)
        {
            this.storedFunctions = fn;
        }

        public string GetAll()
        {
            return this.storedFunctions.GetPersonas();
        }
    }
}
