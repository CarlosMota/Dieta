using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.DAO
{
    

    class DataHelper
    {
        private readonly DataBaseContext _dataBaseContentex;

        public DataHelper() 
        {
            _dataBaseContentex = (App.Current as App).DataBaseContext;
        }


        public IEnumerable<Alimento> GetAlimentos() 
        {
            return _dataBaseContentex.TAlimentos.ToList();
        }

        public Alimento GetList(int AlimentoId) 
        {
            var list = 
        }

        public bool AddList(string Descricao, string descricao_de_preparo, string calorias, string proteinas, string gordurasTotais,
            string carboidratos,string fibra_alimentar, string acucar, string sodio, bool editavel)
        {
            try
            {
                Alimento alimento = new Alimento();
                alimento.DescricaoDoAlimento = Descricao;
                alimento.DescricaoPreparacao = descricao_de_preparo;
                alimento.Calorias = calorias;
                alimento.Acucar = acucar;
                alimento.Sodio = sodio;
                alimento.Deleta = editavel;
                    /*Id = _rnd.Next(),
                    Name = name,
                    DateCreated = DateTime.Now*/

                _dataBaseContentex.TAlimentos.InsertOnSubmit(alimento);
                _dataBaseContentex.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditAlimentos(int AlimentoId, string name)
        {
            try
            {
                Alimento alimento = GetList(listId);
                alimento.DescricaoDoAlimento = name;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}
