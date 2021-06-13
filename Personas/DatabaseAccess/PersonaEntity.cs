using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Personas.DatabaseAccess
{
    public class PersonaEntity
    {
        public Guid guid { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }

        public static PersonaEntity Create(string nombre, int edad, string direccion)
        {
            return new PersonaEntity
            {
                guid = Guid.NewGuid(),
                nombre = nombre,
                edad = edad,
                direccion = direccion
            };
        }
    }
}
