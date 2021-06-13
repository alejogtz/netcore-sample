using FilemanagerDemo.DatabaseAccess;
using FilemanagerDemo.Personas.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Infraestructura.DatabaseAccess
{
    public class CachePersonasDao : IPersonasStoredFunctions
    {
        public IPersonasStoredFunctions dao;
        public CachePersonasDao(IPersonasStoredFunctions xd)
        {
            this.dao = xd;
        }

        public Guid Create(PersonaEntity persona)
        {
            throw new NotImplementedException();
        }

        public string GetPersonas()
        {
            // Check in files if exist
            var filename = "../../../.cache/personas/all-personas.json";

            if (!Directory.Exists("../../../.cache/personas")) Directory.CreateDirectory("../../../.cache/personas");

            if (File.Exists(filename))
            {
                return File.ReadAllText(filename);
            }

            var personas = dao.GetPersonas();

            File.WriteAllText(filename, personas);

            return personas;
        }
    }
}
