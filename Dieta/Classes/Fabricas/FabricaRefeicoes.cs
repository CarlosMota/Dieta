using Dieta.Classes.Refeicoes;
using Dieta.Classes.Refeicoes.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.Classes.Fabricas
{
    public class FabricaRefeicoes
    {
        

        public List<Refeicao> criarRefeicoes() 
        {
            List<Refeicao> refeicoes = new List<Refeicao>();
            refeicoes.Add(new Cafe());
            refeicoes.Add(new LancheManha());
            refeicoes.Add(new Almoco());
            refeicoes.Add(new LancheTarde());
            refeicoes.Add(new LancheTarde());
            refeicoes.Add(new Janta());
            refeicoes.Add(new Dieta.Classes.Refeicoes.classes.Ceia());

            return refeicoes;
        }
    }
}
