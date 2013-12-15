using Dieta.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        public Refeicao LerRefeicaoXML(string NomeArquivo, Refeicao refeicao)
        {

            try
            {

                Refeicao refe;

                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myISF.OpenFile(NomeArquivo, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Refeicao));
                        stream.Position = 0;
                        refe = (Refeicao)serializer.Deserialize(stream);
                    }
                }

                return refe;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool SalvarXML(string NomeArquivo, Refeicao refeicao)
        {
            try
            {
                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myISF.OpenFile(NomeArquivo, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Refeicao));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream))
                        {
                            serializer.Serialize(xmlWriter, (App.Current as App).Refeicao);
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                //MessageBox.Show("Erro durante o cadastro!");
                return false;
            }
            return true;
        }

    }
}
