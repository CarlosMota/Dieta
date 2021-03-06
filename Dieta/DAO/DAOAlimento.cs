﻿using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.DAO
{
    public class DAOAlimento
    {
        public IEnumerable<Alimento> ObtemAlimento()
        {
            List<Alimento> dados = new List<Alimento>();
            using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                dados = (from alimento in db.Alimentos orderby alimento.DescricaoDoAlimento select alimento).ToList();
            }
            return dados;
        }

        public bool Gravar(Alimento novoAliemento)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    db.Alimentos.InsertOnSubmit(novoAliemento);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Excluir(Alimento alimento)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    var excluir = db.Alimentos.Where(a => a.IdAlimento == alimento.IdAlimento).First();
                    db.Alimentos.DeleteOnSubmit(excluir);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Realizado(Alimento alimento)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Alimento update = (from amt in db.Alimentos
                                     where amt.IdAlimento ==alimento.IdAlimento
                                     select amt).First();
                    update.Realizada = !update.Realizada;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
