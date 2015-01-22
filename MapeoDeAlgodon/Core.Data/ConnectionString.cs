using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace Data
{
    public  class ConnectionString
    {
        public static void AddUser(Usuario usuario)
        {
            stringConnection =
                    @"Data Source=TELEMETRIA\WINCC;Initial Catalog=AGRICULTURA;User ID=" + usuario.Nombre + ";Password=" + usuario.Pasword;
        }
        private static string stringConnection = string.Empty;
        public static string GetString()
        {
            return stringConnection;
        }
    }
}