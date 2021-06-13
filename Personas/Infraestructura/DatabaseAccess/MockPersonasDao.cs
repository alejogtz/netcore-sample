using FilemanagerDemo.DatabaseAccess;
using FilemanagerDemo.Personas.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Infraestructura.DatabaseAccess
{
    public class MockPersonasDao : IPersonasStoredFunctions
    {
        public Guid Create(PersonaEntity persona)
        {
            throw new NotImplementedException();
        }

        public string GetPersonas()
        {
            List<object> personas = new List<object>();
            personas.Add(new { guid = Guid.NewGuid().ToString(), nombre = "Alejo Gutierrez", edad = 25, direccion = "CALLE DE LA AMARGURA" });
            personas.Add(new { guid = Guid.NewGuid().ToString(), nombre = "Santy Gutierrez", edad = 25, direccion = "CALLE DE LA AMARGURA" });
            personas.Add(new { guid = Guid.NewGuid().ToString(), nombre = "Iker Gutierrez", edad = 25, direccion = "CALLE DE LA AMARGURA" });

            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                error = false,
                datos = personas
            });
        }
    }
}
