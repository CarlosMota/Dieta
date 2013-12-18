using Dieta.Classes;
using Dieta.Model;
using Dieta.Model.Refeicoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Scheduler;
using Dieta.DAO;

namespace Dieta.Fabrica
{
    public class FabricaRefeicao
    {

        public static List<Refeicao> criarRefeicoes(double QuantidadeCaloricaTotal)
        {
            List<Refeicao> ListaRefeicoes = new List<Refeicao>();
            string[] horarios = { "06:30", "09:30", "12:30", "15:30", "18:30", "21:30" };
            string[] nomes = {"Café", "Lanche da Manhã", "Almoço", "Lanche da Tarde", "Janta", "Ceia"};
            Configuracoes configuracoes = new Configuracoes();
            if (configuracoes.GetHorarioReminderRefeicao(nomes[0]) != null)
            {
                horarios = new string[6];
                for (int i = 0; i < 6; i++)
                    horarios[i] = configuracoes.GetHorarioReminderRefeicao(nomes[i]);
            }
            else
            {
                for (int i = 0; i < 6; i++)
                    configuracoes.SetHorarioReminderRefeicao(nomes[i], horarios[i]);
            }
            ListaRefeicoes.Add(criarRefeicao(nomes[0], horarios[0], "/Imagens/Refeicoes/1.png", QuantidadeCaloricaTotal, 0));
            ListaRefeicoes.Add(criarRefeicao(nomes[1], horarios[1], "/Imagens/Refeicoes/2.png", QuantidadeCaloricaTotal, 1));
            ListaRefeicoes.Add(criarRefeicao(nomes[2], horarios[2], "/Imagens/Refeicoes/3.png", QuantidadeCaloricaTotal, 2));
            ListaRefeicoes.Add(criarRefeicao(nomes[3], horarios[3], "/Imagens/Refeicoes/4.png", QuantidadeCaloricaTotal, 3));
            ListaRefeicoes.Add(criarRefeicao(nomes[4], horarios[4], "/Imagens/Refeicoes/5.png", QuantidadeCaloricaTotal, 4));
            ListaRefeicoes.Add(criarRefeicao(nomes[5], horarios[5], "/Imagens/Refeicoes/6.png", QuantidadeCaloricaTotal, 5));
            return ListaRefeicoes;
        }

        public static Refeicao criarRefeicao(string nome, string horario, string caminhoImagem, double QuantidadeCaloricaTotal, int IdRefeicao)
        {
            Refeicao refe = escolherRefeicao(IdRefeicao);
            refe.Nome = nome;
            refe.Horario = horario;
            refe.Imagem = new System.Windows.Media.Imaging.BitmapImage(new Uri(caminhoImagem, UriKind.RelativeOrAbsolute));
            refe.QuantidadeCaloricaDaRefeicaoTotal = Calculo.calculoQuantidadeCaloricaPorRefeicao(IdRefeicao, QuantidadeCaloricaTotal);
            refe.QuantidadeCaloricaConsumida = 0;
            refe.NomeDoArquivo = refe.Nome + ".xml";
            refe.IdRefeicao = IdRefeicao;
            refe.Alimentos = Arquivo.LerRefeicaoXML(refe.NomeDoArquivo, refe);
            if (refe.Alimentos != null)
            {
                for (int j = 0; j < refe.Alimentos.Count; j++)
                    refe.QuantidadeCaloricaConsumida += refe.Alimentos.ElementAt(j).Calorias;
            }
            else
            {
                refe.Alimentos = new List<Alimento>();
            }
            return refe;
        }

        private static Refeicao escolherRefeicao(int IdRefeicao)
        {
            Refeicao refeicao = null;
            switch (IdRefeicao)
            {
                case 0:
                    refeicao = new Cafe();
                    break;
                case 1:
                    refeicao = new LancheManha();
                    break;
                case 2:
                    refeicao = new Almoco();
                    break;
                case 3:
                    refeicao = new LancheTarde();
                    break;
                case 4:
                    refeicao = new Janta();
                    break;
                case 5:
                    refeicao = new Ceia();
                    break;
            }

            return refeicao;

        }
    }
}
