using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dieta.Classes
{
    class ConverterHorario
    {
        public static DateTime converter(String s)
        {
            string[] horaMinuto = Regex.Split(s, ":");
            DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, int.Parse(horaMinuto[0]), int.Parse(horaMinuto[1]), 0);
            return dateTime;
        }

        public static string converter(DateTime d)
        {
            return String.Format("{0:D2}:{1:D2}", d.Hour, d.Minute);
        }

    }
}
