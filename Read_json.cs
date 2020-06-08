using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Npgsql;
using Newtonsoft.Json;
using NpgsqlTypes;

namespace Postgres_H3_Maalpinde
{
    class Read_json
    {
        // NpgsqlDbType is an enum that contains (almost) all PostgreSQL types supported by Npgsql

        public void read_json()
        {
            // ---------- Get access to connection string ---------- \\

            string json_path = $@"C:\Users\EriaS\source\repos\H3_Maalpinde_Info.json";

            TextReader reader = new StreamReader(json_path);
            string read_json = reader.ReadToEnd();
            Values_json info = JsonConvert.DeserializeObject<Values_json>(read_json);
            
            // ---------- Connect to database with connection string ---------- \\

            NpgsqlConnection H3_Maalpinde = new NpgsqlConnection(Convert.ToString(info));
            H3_Maalpinde.Open();

            // ---------- Simple INSERT INTO to test if it works ---------- \\

            // @p = parameter placeholder
            // Npgsql will expect to find a parameter with that name in the command's parameter list, and will send it along with the query

            using (NpgsqlCommand insert = new NpgsqlCommand("INSERT INTO public.kingdoms (kingdom_name) VALUES (@p)", H3_Maalpinde))
            {
                insert.Parameters.AddWithValue("p", "Aserai");
                insert.ExecuteNonQuery();
            }

            using (NpgsqlCommand select_func = new NpgsqlCommand("SELECT my_func(1, 2)", H3_Maalpinde))
            using (var reader1 = select_func.ExecuteReader()) { }

            using (NpgsqlCommand func = new NpgsqlCommand("my_func", H3_Maalpinde))
            {
                func.CommandType = System.Data.CommandType.StoredProcedure;
                func.Parameters.AddWithValue("p1", "some_value");
                using (var reader2 = func.ExecuteReader()) { }
            }
        }
    }
}
