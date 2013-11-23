using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dieta.Classes
{
    public class Usuario
    {
        public Usuario(string nome, int idade, char sexo, double peso, double altura,
            NivelDeAtividade nAtividade, double pesoDesejado, Meta meta)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Peso = peso;
            Altura = altura;
            NivelDeAtividade = nAtividade;
            PesoDesejado = pesoDesejado;
            Meta = meta;
        }

        public Usuario()
        {
        }
        public string Nome { set; get; }

        public int Idade { set; get; }

        public char Sexo { set; get; }

        public double Peso { set; get; }

        public double Altura { set; get; }

        public NivelDeAtividade NivelDeAtividade { set; get; }

        public double PesoDesejado { set; get; }

        public Meta Meta { set; get; }

    }
}
