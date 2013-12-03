using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace Dieta.Classes
{
    public class Configuracoes 
    {
        IsolatedStorageSettings isoStore = IsolatedStorageSettings.ApplicationSettings;

        public void setLogin(string key, string value) 
        {
            if (!isoStore.Contains(key))
            {
                isoStore.Add(key, value);
            }

            isoStore.Save();

        }

        public bool existeCadastro(string key) 
        {
            var login = isoStore.Contains(key);
            return login;
        }

        public string getCadastro(string key) 
        {
            string cadastro = string.Empty;
            isoStore.TryGetValue<string>("cadastro", out cadastro);
            return cadastro;
        }

    }
}
