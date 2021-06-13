using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Shared.Infraestructure
{
    public class DatabaseQueries
    {
        private readonly DatabaseOptions Configuration;
        public DatabaseQueries(IOptions<DatabaseOptions> configuration)
        {
            Configuration = configuration.Value ?? throw new ArgumentException();
        }

        protected string DoSelect(string query)
        {
            string response = "";
            using (var connection = new NpgsqlConnection(Configuration.GetConnectionString()))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            response = reader.GetValue(0).ToString();
                    }
                }
            }
            return response;
        }
        protected string DoSelect(NpgsqlCommand command)
        {
            var response = "";
            using (var connection = new NpgsqlConnection(Configuration.GetConnectionString()))
            {
                connection.Open();
                using (command)
                {
                    command.Connection = connection;
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            response = reader.GetValue(0).ToString();
                    }
                }
            }
            return response;
        }
    }
}
