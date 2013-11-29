using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Dieta.Classes.Refeicoes
{
    public class Refeicao
    {
        public string Nome { set; get; }
        public string QuantidadeCalorica { set; get; }
        public string Horario { set; get; }
        public List<Alimento> ListaAlimentos { set; get; }
    }
}
