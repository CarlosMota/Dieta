using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dieta.Model;
using Dieta.DAO;

namespace Dieta.View
{
    public partial class TabelaNutricional : PhoneApplicationPage
    {
        string index;
        double calorias;
        double proteinas;
        double gorduraTotal;
        double carboidratos;
        double fibras;
        double sodio;
        double gorduraSaturada;
        double gorduraTrans;
        double valorPadrao = 100;
        Alimento alimento;

        public TabelaNutricional()
        {
            InitializeComponent();
            this.Loaded += TabelaNutricional_Loaded;
            alimento = (Application.Current as App).alimentoSelecionado;
            calorias = alimento.Calorias;
            proteinas = alimento.Proteinas;
            gorduraTotal = alimento.GorduraTotais;
            carboidratos = alimento.Carboidratos;
            fibras = alimento.Fibra_Alimentar;
            sodio = alimento.Sodio;
            gorduraSaturada = alimento.GorduraSaturada;
            gorduraTrans = alimento.GorduraTrans;
        }

        void TabelaNutricional_Loaded(object sender, RoutedEventArgs e)
        {
            nomeDoAlimento.Text = alimento.DescricaoDoAlimento;
            if (!alimento.DescricaoPreparacao.Equals("NAO SE APLICA"))
                nomeDoAlimento.Text += " " + alimento.DescricaoPreparacao;
            ValorEnergetico.Text = ""+calorias;
            Proteinas.Text = ""+proteinas;
            GordurasTotais.Text = "" + gorduraTotal;
            Carboidratos.Text = "" + carboidratos;
            FibraAlimentar.Text = "" + fibras;
            Sodio.Text = "" + sodio;
            GordurasSaturadas.Text = "" + gorduraSaturada;
            GorduraTrans.Text = "" + gorduraTrans;
        }

        public void calcularQuantidade(double gramas) 
        {
            calorias = RegraDeTres(valorPadrao, alimento.Calorias, gramas);
            proteinas = RegraDeTres(valorPadrao, alimento.Proteinas, gramas);
            gorduraTotal = RegraDeTres(valorPadrao, alimento.GorduraTotais, gramas);
            carboidratos = RegraDeTres(valorPadrao, alimento.Carboidratos, gramas);
            fibras = RegraDeTres(valorPadrao, alimento.Fibra_Alimentar, gramas);
            sodio = RegraDeTres(valorPadrao, alimento.Sodio, gramas);
            gorduraSaturada = RegraDeTres(valorPadrao, alimento.GorduraSaturada, gramas);
            gorduraTrans = RegraDeTres(valorPadrao, alimento.GorduraTrans, gramas);
        }

        public double RegraDeTres(double valorPadrao, double ValorPropriedade, double valorEmGramas) 
        {
            return ((ValorPropriedade * valorEmGramas) / valorPadrao);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("item", out this.index);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (!ChecarPreenchimento())
                return;
            calcularQuantidade(double.Parse(tBoxGramas.Text));
            Alimento novoAlimento = new Alimento();
            Refeicao refe = (Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index));
            novoAlimento.DescricaoDoAlimento = alimento.DescricaoDoAlimento;
            novoAlimento.DescricaoPreparacao = alimento.DescricaoPreparacao;
            novoAlimento.Calorias = calorias;
            novoAlimento.Proteinas = proteinas;
            novoAlimento.GorduraTotais = gorduraTotal;
            novoAlimento.Carboidratos = carboidratos;
            novoAlimento.Fibra_Alimentar = fibras;
            novoAlimento.Sodio = sodio;
            novoAlimento.GorduraSaturada = gorduraSaturada;
            novoAlimento.GorduraTrans = gorduraTrans;
            refe.Alimentos.Add(novoAlimento);
            refe.QuantidadeCaloricaConsumida += novoAlimento.Calorias;
            (Application.Current as App).CaloriasTotaisConsumidas += novoAlimento.Calorias;
            Arquivo.SalvarXML(refe.NomeDoArquivo, refe);
            NavigationService.Navigate(new Uri("/View/PanoramaDieta.xaml?idRefeicao="+index, UriKind.RelativeOrAbsolute));
        }

        private bool ChecarPreenchimento()
        {
                if (tBoxGramas.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Por favor insira um valor para gramas");
                    return false;
                }
                try
                {
                    double.Parse(tBoxGramas.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor insira um valor numérico válido em gramas");
                    return false;
                }
                return true;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}