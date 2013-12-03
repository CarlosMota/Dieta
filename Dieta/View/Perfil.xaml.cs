using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Dieta.Classes;
using Dieta.Model;

namespace Dieta.View
{
    public partial class Perfil : PhoneApplicationPage
    {
        double CaloriasTotais;

        public Perfil()
        {
            InitializeComponent();
            TxtAltura.Text = ""+(Application.Current as App).Usuario.Altura;
            txtPesoInicial.Text = "" + (Application.Current as App).Usuario.Peso;
            TxtObjetivo.Text = "" + (Application.Current as App).Usuario.PesoDesejado;
            TxtIMC.Text = "" + Calculo.CalcularIMC((Application.Current as App).Usuario.Altura, (Application.Current as App).Usuario.Peso);
            CaloriasTotais =  Calculo.caluloCalorias((Application.Current as App).Usuario.Sexo,(Application.Current as App).Usuario.Altura,(Application.Current as App).Usuario.Peso,(Application.Current as App).Usuario.Idade,(Application.Current as App).Usuario.NivelDeAtividade);
            txtCalorias.Text = "" + CaloriasTotais;
            txtCaloriaTotal.Text = ""+CaloriasTotais;
            txtQuantidadeAgua.Text = "" + Calculo.calculoConsumoAgua((Application.Current as App).Usuario.Peso,CaloriasTotais);
            (Application.Current as App).ListaRefeicao = Fabrica.FabricaRefeicao.criarRefeicoes(CaloriasTotais);
            this.Loaded += Perfil_Loaded;
        }

        void Perfil_Loaded(object sender, RoutedEventArgs e)
        {
            ListaRefeicoes.ItemsSource = (Application.Current as App).ListaRefeicao;
        }

        private void ListaRefeicoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaRefeicoes.SelectedIndex == -1)
                return;

            (Application.Current as App).refeicaoSelecionada =
                (ListaRefeicoes.Items[ListaRefeicoes.SelectedIndex] as Refeicao);
           
            NavigationService.Navigate(new Uri("/View/PanoramaDieta.xaml?idRefeicao=" + (Application.Current as App).refeicaoSelecionada.IdRefeicao,
                UriKind.Relative));
            ListaRefeicoes.SelectedIndex = -1;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Sair do aplicativo?", "Logout", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //Faça alguma coisa aqui...
                base.OnBackKeyPress(e);
            }
            else
                e.Cancel = true;
        }

    }
}