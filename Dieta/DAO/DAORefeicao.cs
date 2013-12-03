using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.DAO
{
    public class DAORefeicao
    {
        public IEnumerable<Refeicao> ObtemRefeicao()
        {
            List<Refeicao> dados = new List<Refeicao>();
            using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                dados = (from refeicao in db.Refeicoes orderby refeicao.Nome select refeicao).ToList();
            }
            return dados;
        }

        public bool Gravar(Refeicao novaRefeicao)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    //db.Tarefas.InsertOnSubmit(novaTarefa);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Excluir(Refeicao refeicao)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    var excluir = db.Refeicoes.Where(refe => refe.IdRefeicao == refe.IdRefeicao).First();
                    db.Refeicoes.DeleteOnSubmit(excluir);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Realizado(Refeicao refeicao)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Refeicao update = (from refe in db.Refeicoes
                                       where refe.IdRefeicao == refeicao.IdRefeicao
                                       select refe).First();
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
