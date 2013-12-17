using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Scheduler;

namespace Dieta.Classes
{
    class NotificadorAgua
    {
        public void CriarRemindersAgua(double peso)
        {
            if (RemindersAguaConfigurados())
                return;
            Configuracoes configuracoes = new Configuracoes();
            DateTime dateTime = MetodosTempo.StringToDateTime(configuracoes.GetHorarioInicioAgua());
            string nome = "agua";
            int horaMax = MetodosTempo.Hora(configuracoes.GetHorarioFimAgua());
            int minutoMax = MetodosTempo.Minuto(configuracoes.GetHorarioFimAgua());
            int qtdeIntervalos = MetodosTempo.QtdeIntervalos(configuracoes.GetHorarioInicioAgua(), configuracoes.GetHorarioFimAgua(), configuracoes.GetIntervaloAgua());
            qtdeIntervalos++;
            for (int i = 0; (dateTime.Hour < horaMax) || ((dateTime.Hour == horaMax) && (dateTime.Minute <= minutoMax)); i++)
            {
                Reminder reminder = new Reminder(nome + i.ToString());
                reminder.Title = "Beber " + Math.Ceiling(Calculo.calculoConsumoAgua(peso) / qtdeIntervalos) + "ml de água";
                reminder.Content = MetodosTempo.DateTimeToString(dateTime);
                if (DateTime.Compare(DateTime.Now, dateTime) > 0)
                    reminder.BeginTime = dateTime.AddDays(1);
                else
                    reminder.BeginTime = dateTime;
                reminder.ExpirationTime = dateTime.AddYears(10);
                reminder.RecurrenceType = RecurrenceInterval.Daily;
                dateTime = dateTime.AddHours(MetodosTempo.Hora(configuracoes.GetIntervaloAgua()));
                dateTime = dateTime.AddMinutes(MetodosTempo.Minuto(configuracoes.GetIntervaloAgua()));
                reminder.NavigationUri = new Uri("/View/Perfil.xaml", UriKind.Relative);
                ScheduledActionService.Add(reminder);
            }
        }

        public void AtualizarRemindersAgua(double peso)
        {
            if (!RemindersAguaConfigurados())
                return;
            Configuracoes configuracoes = new Configuracoes();
            DateTime dateTime = MetodosTempo.StringToDateTime(configuracoes.GetHorarioInicioAgua());
            string nome = "agua";
            int horaMax = MetodosTempo.Hora(configuracoes.GetHorarioFimAgua());
            int minutoMax = MetodosTempo.Minuto(configuracoes.GetHorarioFimAgua());
            int qtdeIntervalos = MetodosTempo.QtdeIntervalos(configuracoes.GetHorarioInicioAgua(), configuracoes.GetHorarioFimAgua(), configuracoes.GetIntervaloAgua());
            qtdeIntervalos++;
            for (int i = 0; (dateTime.Hour < horaMax) || ((dateTime.Hour == horaMax) && (dateTime.Minute <= minutoMax)); i++)
            {
                Reminder reminder = (Reminder)ScheduledActionService.Find(nome + i.ToString());
                reminder.Title = "Beber " + Math.Ceiling(Calculo.calculoConsumoAgua(peso) / qtdeIntervalos) + "ml de água";
                reminder.Content = MetodosTempo.DateTimeToString(dateTime);
                if (DateTime.Compare(DateTime.Now, dateTime) > 0)
                    reminder.BeginTime = dateTime.AddDays(1);
                else
                    reminder.BeginTime = dateTime;
                reminder.ExpirationTime = dateTime.AddYears(10);
                reminder.RecurrenceType = RecurrenceInterval.Daily;
                dateTime = dateTime.AddHours(MetodosTempo.Hora(configuracoes.GetIntervaloAgua()));
                dateTime = dateTime.AddMinutes(MetodosTempo.Minuto(configuracoes.GetIntervaloAgua()));
                reminder.NavigationUri = new Uri("/View/Perfil.xaml", UriKind.Relative);
                ScheduledActionService.Replace(reminder);
            }
        }

        public void ApagarRemindersAgua()
        {
            if (!RemindersAguaConfigurados())
                return;
            string nome = "agua";
            for (int i = 0; ScheduledActionService.Find(nome + i.ToString()) != null; i++)
            {
                ScheduledActionService.Remove(nome + i.ToString());
            }
        }

        public bool RemindersAguaConfigurados()
        {
            string nome = "agua";
            return ScheduledActionService.Find(nome + 0.ToString()) != null;
        }
     
    }
}
