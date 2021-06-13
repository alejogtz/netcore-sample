using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.DatabaseAccess
{
    public interface IPersonasStoredFunctions
    {
        string GetPersonas();
        Guid Create(Personas.DatabaseAccess.PersonaEntity persona);
    }
}
