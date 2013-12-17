using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.Classes
{
    class Calculo
    {
        public static double CalcularIMC(double altura, double peso) 
        {
            var imc = ((peso) / ((altura/100 * altura/100)));
            return imc;
        }

        private static double CalcularTBM(char sexo, double altura, double peso, int idade) 
        {
            double tbm = 0;
            
            switch (sexo) 
            {
                case 'f':
                   tbm =  655.1 + 9.5 * peso + 1.8 * altura - 4.7 * idade;
                   break;
                case 'm':
                   tbm = 55.1 + 13.8 * peso + 5 * altura - 6.8 * idade;
                   break;
            }

            return tbm;
        }

        public static double caluloCalorias(char sexo, double altura, double peso, double pesoDesejado, int idade, NivelDeAtividade nivelAtividade) 
        {
            double quantidadeCalorica = 0;
            if (pesoDesejado > peso)
                quantidadeCalorica = 500;
            if (pesoDesejado < peso)
                quantidadeCalorica = -500;
            switch (nivelAtividade.ToString()) 
            {
                case "MUITO_ATIVO":
                    quantidadeCalorica += 1.725*CalcularTBM(sexo,altura,peso,idade);
                    break;
                case "ATIVO":
                    quantidadeCalorica += 1.65*CalcularTBM(sexo,altura,peso,idade);
                    break;
                case "MODERADO":
                    quantidadeCalorica += 1.375*CalcularTBM(sexo,altura,peso,idade);
                    break;
                case "SEDENTARIO":
                    quantidadeCalorica += 1.2 * CalcularTBM(sexo,altura,peso,idade);
                    break;
            }

            return quantidadeCalorica;
            
        }

        public static double calculoConsumoAgua(double peso) 
        {
            return 33*peso;
        }

        public static double calculoQuantidadeCaloricaPorRefeicao(int refeicao,double quantidadeCaloricaTotal) 
        {
            double quantidadeCalorica=0;
            switch (refeicao) 
            {
                case 0:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.2;
                    break;
                case 1:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.05;
                    break;
                case 2:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.3;
                    break;
                case 3:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.15;
                    break;
                case 4:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.25;
                    break;
                case 5:
                    quantidadeCalorica = quantidadeCaloricaTotal * 0.05;
                    break;
            }

            return quantidadeCalorica;
        }

        public static double calculoSemanas(double peso, double pesoDesejado)
        {
            return Math.Ceiling(Math.Abs((pesoDesejado - peso) * 2));
        }

    }
}
