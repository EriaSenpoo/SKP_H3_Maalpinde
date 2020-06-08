using System;
using System.IO;
using Npgsql;

namespace Postgres_H3_Maalpinde
{
    class Program
    {


        static void Main(string[] args)
        {
            Read_json json = new Read_json();
            json.read_json();

            Console.ReadLine();
        }
    }
}
