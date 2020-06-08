using System;
using System.Collections.Generic;
using System.Text;

namespace Postgres_H3_Maalpinde
{
    public class Values_json
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public override string ToString()
        {
            return string.Format("Server={0}; Port={1}; Username={2}; Password={3}; Database={4}", Server, Port, Username, Password, Database);
        }
    }
}
