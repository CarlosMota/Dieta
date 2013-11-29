using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Dieta.DAO
{
    class DataBaseContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/Main.sdf";

        private Table<Alimento> _alimentos;

        public Table<Alimento> Alimentos
        {
            get
            {
                if (_alimentos == null)
                    _alimentos = GetTable<Alimento>();

                return _alimentos;
            }
        }

        public DataBaseContext(string connectionString)
            : base(connectionString)
        {
            if (!this.DatabaseExists())
                this.CreateDatabase();
        }
    }
}
