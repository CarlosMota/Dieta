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
    class Arquivo
    {
        public static List<Alimento> LerRefeicaoXML(string NomeArquivo, Refeicao refeicao)
        {

            try
            {

                List<Alimento> listaAlimentos;

                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myISF.OpenFile(NomeArquivo, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Alimento>));
                        stream.Position = 0;
                        listaAlimentos = (List<Alimento>)serializer.Deserialize(stream);
                        refeicao.Alimentos = listaAlimentos;
                    }
                }

                return listaAlimentos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static  bool SalvarXML(string NomeArquivo, Refeicao refeicao)
        {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myISF.OpenFile(NomeArquivo, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Alimento>));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream))
                        {
                            serializer.Serialize(xmlWriter, refeicao.Alimentos);
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                
                return false;
            }
            return true;
        }

    }
}
