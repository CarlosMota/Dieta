using Dieta.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Dieta.DAO
{
    class Arquivo
    {
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
    }
}
