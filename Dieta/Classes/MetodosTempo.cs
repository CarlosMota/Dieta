using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dieta.Classes
{
    class MetodosTempo
    {
        public static DateTime StringToDateTime(String s)
        {
            string[] horaMinuto = Regex.Split(s, ":");
            DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, int.Parse(horaMinuto[0]), int.Parse(horaMinuto[1]), 0);
            return dateTime;
        }

        public static string DateTimeToString(DateTime d)
        {
            return String.Format("{0:D2}:{1:D2}", d.Hour, d.Minute);
        }

        public static int Hora(String s)
        {
            string[] horaMinuto = Regex.Split(s, ":");
            return int.Parse(horaMinuto[0]);
        }

        public static int Minuto(String s)
        {
            string[] horaMinuto = Regex.Split(s, ":");
            return int.Parse(horaMinuto[1]);
        }

        public static DateTime TentarAnteciparParaHoje(DateTime d)
        {
            if (d.Hour < DateTime.Now.Hour || (d.Hour == DateTime.Now.Hour && d.Minute <= DateTime.Now.Minute))
                return d;
            else
            {
                d = d.AddDays(DateTime.Today.Day - d.Day);
                return d;
            }
        }

        public static int QtdeIntervalos(string horaMnutoInicial, string horaMinutoFinal, string intervalo)
        {
            int horasDuracao = Hora(horaMinutoFinal) - Hora(horaMnutoInicial);
            int minutosDuracao = Minuto(horaMinutoFinal) - Minuto(horaMnutoInicial);
            int segundosDuracao = horasDuracao * 3600 + minutosDuracao * 60;
            int segundosIntervalo = Hora(intervalo) * 3600 + Minuto(intervalo) * 60;
            int qtdeIntervalos = segundosDuracao / segundosIntervalo;
            return qtdeIntervalos;
        }
    }
}
