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
        private const string REMINDER_REFEICAO = "ReminderRefeicao";
        private const string REMINDER_AGUA = "ReminderAgua";
        private const string INTERVALO_AGUA = "IntervaloAgua";
        private const string INICIO_AGUA = "InicioAgua";
        private const string FIM_AGUA = "FimAgua";
        
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

        public void SetReminderRefeicaoOn(bool on)
        {
            string key = REMINDER_REFEICAO;
            if (!isoStore.Contains(key))
                isoStore.Add(key, on);
            else
                isoStore[key] = on;
            isoStore.Save();
        }

        public bool IsReminderRefeicaoOn()
        {
            string key = REMINDER_REFEICAO;
            bool b;
            isoStore.TryGetValue<bool>(key, out b);
            return b;
        }

        public void SetReminderAguaOn(bool on)
        {
            string key = REMINDER_AGUA;
            if (!isoStore.Contains(key))
                isoStore.Add(key, on);
            else
                isoStore[key] = on;
            isoStore.Save();
        }

        public bool IsReminderAguaOn()
        {
            string key = REMINDER_AGUA;
            bool b;
            isoStore.TryGetValue<bool>(key, out b);
            return b;
        }

        public void SetHorarioReminderRefeicao(string nome, string horario)
        {
            string key = nome;
            if (!isoStore.Contains(key))
                isoStore.Add(key, horario);
            else
                isoStore[key] = horario;
            isoStore.Save();
        }

        public string GetHorarioReminderRefeicao(string nome)
        {
            string key = nome;
            if (isoStore.Contains(key))
                return isoStore[key].ToString();
            else
                return null;
        }

        public string GetIntervaloAgua()
        {
            string key = INTERVALO_AGUA;
            if (isoStore.Contains(key))
                return isoStore[key].ToString();
            else
                return null;
        }

        public void SetIntervaloAgua(string horario)
        {
            string key = INTERVALO_AGUA;
            if (!isoStore.Contains(key))
                isoStore.Add(key, horario);
            else
                isoStore[key] = horario;
            isoStore.Save();
        }

        public void SetHorarioInicioAgua(string horario)
        {
            string key = INICIO_AGUA;
            if (!isoStore.Contains(key))
                isoStore.Add(key, horario);
            else
                isoStore[key] = horario;
            isoStore.Save();
        }

        public string GetHorarioInicioAgua()
        {
            string key = INICIO_AGUA;
            if (isoStore.Contains(key))
                return isoStore[key].ToString();
            else
                return null;
        }

        public void SetHorarioFimAgua(string horario)
        {
            string key = FIM_AGUA;
            if (!isoStore.Contains(key))
                isoStore.Add(key, horario);
            else
                isoStore[key] = horario;
            isoStore.Save();
        }

        public string GetHorarioFimAgua()
        {
            string key = FIM_AGUA;
            if (isoStore.Contains(key))
                return isoStore[key].ToString();
            else
                return null;
        }

    }
}
