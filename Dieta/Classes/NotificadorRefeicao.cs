using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Scheduler;
using Dieta.Model;

namespace Dieta.Classes
{
    class NotificadorRefeicao
    {
        public void CriarRemindersRefeicao(List<Refeicao> listaRefeicao)
        {
            if (RemindersRefeicaoConfigurados())
                return;
            IEnumerable<ScheduledNotification> notifications = ScheduledActionService.GetActions<ScheduledNotification>();
            Configuracoes configuracoes = new Configuracoes();
            for (int i = 0; i < listaRefeicao.Count(); i++)
            {
                Refeicao refeicao = listaRefeicao.ElementAt(i);
                Reminder reminder = new Reminder(i.ToString());
                reminder.Title = refeicao.Nome;
                reminder.Content = refeicao.Horario;
                DateTime tempo = MetodosTempo.StringToDateTime(refeicao.Horario);
                if (DateTime.Compare(DateTime.Now, tempo) > 0)
                    reminder.BeginTime = tempo.AddDays(1);
                else
                    reminder.BeginTime = tempo;
                reminder.ExpirationTime = tempo.AddYears(10);
                reminder.NavigationUri = new Uri("/View/PanoramaDieta.xaml?idRefeicao=" + i, UriKind.Relative);
                ScheduledActionService.Add(reminder);
            }
        }

        public void AtualizarRemindersRefeicao(List<Refeicao> listaRefeicao)
        {
            if (!RemindersRefeicaoConfigurados())
                return;
            for (int i = 0; i < listaRefeicao.Count(); i++)
            {
                Refeicao refeicao = listaRefeicao.ElementAt(i);
                Reminder reminder = (Reminder)ScheduledActionService.Find(i.ToString());
                DateTime tempo = MetodosTempo.StringToDateTime(refeicao.Horario);
                if (DateTime.Compare(DateTime.Now, tempo) > 0)
                    reminder.BeginTime = tempo.AddDays(1);
                else
                    reminder.BeginTime = tempo;
                reminder.Content = listaRefeicao.ElementAt(i).Horario;
                ScheduledActionService.Replace(reminder);
            }
        }

        public void ApagarRemindersRefeicao()
        {
            if (!RemindersRefeicaoConfigurados())
                return;
            for (int i = 0; ScheduledActionService.Find(i.ToString()) != null; i++)
            {
                ScheduledActionService.Remove(i.ToString());
            }
        }

        public bool RemindersRefeicaoConfigurados()
        {
            return ScheduledActionService.Find(0.ToString()) != null;
        }
    }
}
