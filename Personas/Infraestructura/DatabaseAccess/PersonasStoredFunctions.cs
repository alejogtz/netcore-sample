using FilemanagerDemo.DatabaseAccess;
using FilemanagerDemo.Personas.DatabaseAccess;
using FilemanagerDemo.Shared.Infraestructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Infraestructura.DatabaseAccess
{
    public class PersonasStoredFunctions : DatabaseQueries, IPersonasStoredFunctions
    {
        public PersonasStoredFunctions(IOptions<DatabaseOptions> configuration) : base(configuration) { }

        public Guid Create(PersonaEntity persona)
        {
            string query = @"WITH query AS (
INSERT
	INTO
		ADMIN.personas (guid,
		nombre,
		edad,
		direccion)
	VALUES(@GUID,
	@NOMBRE,
	@EDAD,
	@DIRECCION) RETURNING guid )
SELECT
	GUID
FROM
	query";
            var command = new Npgsql.NpgsqlCommand(query);
            command.Parameters.AddWithValue("GUID", NpgsqlTypes.NpgsqlDbType.Uuid, persona.guid);
            command.Parameters.AddWithValue("NOMBRE", NpgsqlTypes.NpgsqlDbType.Varchar, persona.nombre);
            command.Parameters.AddWithValue("EDAD", NpgsqlTypes.NpgsqlDbType.Integer, persona.edad);
            command.Parameters.AddWithValue("DIRECCION", NpgsqlTypes.NpgsqlDbType.Varchar, persona.direccion);

            return Guid.Parse(DoSelect(command));
        }


        public string GetPersonas()
        {
            string query = @"WITH datos AS (
	SELECT * FROM ADMIN.personas
)
SELECT jsonb_build_object(
	'eror', FALSE,
	'datos', (SELECT json_agg(f) FROM (SELECT * FROM datos)f)
) ";
            var command = new Npgsql.NpgsqlCommand(query);
            return DoSelect(command);
        }
    }
}
