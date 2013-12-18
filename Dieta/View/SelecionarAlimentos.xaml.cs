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
using Dieta.Model;
using Dieta.DAO;

namespace Dieta.View
{
    public partial class SelecionarAlimentos : PhoneApplicationPage
    {
        string index;
        List<Alimento> listaAlimento;
        List<Alimento> alimentosSelecionados;
        

        public SelecionarAlimentos()
        {
            InitializeComponent();
            alimentosSelecionados = new List<Alimento>();
            this.Loaded += SelecionarAlimentos_Loaded;          
        }

        void SelecionarAlimentos_Loaded(object sender, RoutedEventArgs e)
        {
            carregarAlimentos();
        }

        private void carregarAlimentos()
        {
            listaAlimento = (Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index)).Alimentos;
            int quantidade = (Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index)).Alimentos.Count;
            ListaAlimentos.ItemsSource = listaAlimento;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("item", out this.index);    
        }

        private void ApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            foreach (Alimento alimento in alimentosSelecionados) 
            {
                listaAlimento.Remove(alimento);
                (Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index)).Alimentos = listaAlimento;
            }
            Arquivo.SalvarXML((Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index)).NomeDoArquivo,
                    (Application.Current as App).ListaRefeicao.ElementAt(int.Parse(index)));
            NavigationService.Navigate(new Uri("/View/PanoramaDieta.xaml?idRefeicao=" + index, UriKind.RelativeOrAbsolute));
            //NavigationService.GoBack();
        }

        private void Apagar(DependencyObject targetElement) 
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;

            if (check != null) 
            {
                Alimento alimento = check.DataContext as Alimento;
                if(listaAlimento.Contains(alimento))
                {
                    alimentosSelecionados.Add(alimento);
                }
                
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;

            if (check != null)
            {
                Alimento alimento = check.DataContext as Alimento;
                if (listaAlimento.Contains(alimento))
                {
                    alimentosSelecionados.Remove(alimento);
                }

            }
        }
    }
}