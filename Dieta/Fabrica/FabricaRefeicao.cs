using Dieta.Classes;
using Dieta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.Fabrica
{
    public class FabricaRefeicao
    {

        public static List<Refeicao> criarRefeicoes(double QuantidadeCaloricaTotal) 
        {
            List<Refeicao> ListaRefeicoes = new List<Refeicao>();

            ListaRefeicoes.Add(criarRefeicao("Café","06:30","/Imagens/Refeicoes/1.png",QuantidadeCaloricaTotal,0));
            ListaRefeicoes.Add(criarRefeicao("Lanche da Manhã","09:30","/Imagens/Refeicoes/2.png",QuantidadeCaloricaTotal,1));
            ListaRefeicoes.Add(criarRefeicao("Almoço","12:30","/Imagens/Refeicoes/3.png",QuantidadeCaloricaTotal,2));
            ListaRefeicoes.Add(criarRefeicao("Lanche da Tarde","15:30","/Imagens/Refeicoes/4.png",QuantidadeCaloricaTotal,3));
            ListaRefeicoes.Add(criarRefeicao("Janta","18:30","/Imagens/Refeicoes/5.png",QuantidadeCaloricaTotal,4));
            ListaRefeicoes.Add(criarRefeicao("Ceia","21:30","/Imagens/Refeicoes/6.png",QuantidadeCaloricaTotal,5));

            return ListaRefeicoes;
        }

        public static Refeicao criarRefeicao(string nome, string horario, string caminhoImagem, double QuantidadeCaloricaTotal, int IdRefeicao) 
        {
            Refeicao refe = new Refeicao();
            refe.Nome = nome;
            refe.Horario = horario;
            refe.Imagem = new System.Windows.Media.Imaging.BitmapImage(new Uri(caminhoImagem,UriKind.RelativeOrAbsolute));
            refe.QuantidadeCaloricaDaRefeicaoTotal = Calculo.calculoQuantidadeCaloricaPorRefeicao(IdRefeicao, QuantidadeCaloricaTotal);
            refe.IdRefeicao = IdRefeicao;
            return refe;
        }
    }
}
