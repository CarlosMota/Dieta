using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Dieta.Tabelas
{
    public class WPDataContext : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/WP.sdf";

        public WPDataContext(string connectionString) : base(connectionString) 
        { }

        public Table<Alimento> Alimentos;

    }
}
