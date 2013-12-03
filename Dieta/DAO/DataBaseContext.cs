using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Dieta.DAO
{
    public class DataBaseContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/MainDieta.sdf";

        private Table<Alimento> _alimento;

        public Table<Alimento> Alimentos
        {
            get
            {
                if (_alimento == null)
                    _alimento = GetTable<Alimento>();

                return _alimento;
            }
        }

        private Table<Refeicao> _refeicao;

        public Table<Refeicao> Refeicoes 
        {
            get 
            {
                if (_refeicao == null) 
                {
                    _refeicao = GetTable<Refeicao>();

                   
                }

                return _refeicao;
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
