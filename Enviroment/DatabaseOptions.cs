using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo
{
    public class DatabaseOptions
    {
        public string DatabaseConnectionString { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Schema { get; set; }
        public string PostgresUser { get; set; }
        public string Password { get; set; }

        public string GetConnectionString()
        {
            if (!String.IsNullOrEmpty(this.DatabaseConnectionString))
                return this.DatabaseConnectionString;
            else
                return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", Host, Port, PostgresUser, Password, Database);
        }
    }

}
