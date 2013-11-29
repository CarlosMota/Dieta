using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dieta.Classes.Fabricas;

namespace Dieta.Classes.Refeicoes
{
    public class Dieta
    {
        FabricaRefeicoes fabrica;
        public List<Refeicao> ListaRefeicoes { set; get; }

        public Dieta(FabricaRefeicoes fabrica) 
        {
            this.fabrica = fabrica;
        }

        public List<Refeicao> organizaRefeicoes() 
        {
            ListaRefeicoes = fabrica.criarRefeicoes();
            return ListaRefeicoes;
        }

    }
}
