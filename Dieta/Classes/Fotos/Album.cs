using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;


namespace Dieta.Classes.Fotos
{
    class Album
    {
        private static int CRIOU =1;
        private static int EXISTE = 2;
        private static int ERRO = 0;

        public int CriarAlbum(string Nome) 
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists(Nome))
                {
                    store.CreateDirectory(Nome);
                    return CRIOU;
                }
                else
                    return EXISTE;
            }
            return ERRO;
        }



    }
}
