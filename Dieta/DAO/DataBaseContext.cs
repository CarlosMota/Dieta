using Dieta.Classes;
using Dieta.Classes.Refeicoes;
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
        

        private Table<Alimento> _alimentos;
        private Table<Refeicao> _refeicao;
        private Table<Usuario> _usuario;
        private Table<Dieta.Classes.Foto> _foto;


        public Table<Alimento> TAlimentos
        {
            get
            {
                if (_alimentos == null)
                    _alimentos = GetTable<Alimento>();

                return _alimentos;
            }
        }

        public Table<Refeicao> TRefeicao
        {
            get
            {
                if (_refeicao == null)
                    _refeicao = GetTable<Refeicao>();

                return _refeicao;
            }
        }

        public Table<Usuario> TUsuario
        {
            get
            {
                if (_usuario == null)
                    _usuario = GetTable<Usuario>();

                return _usuario;
            }
        }

        public Table<Foto> TFoto
        {
            get
            {
                if (_foto == null)
                    _foto = GetTable<Foto>();

                return _foto;
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
