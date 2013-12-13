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

namespace Dieta.View
{
    public partial class AdicionarAlimento : PhoneApplicationPage
    {
        Alimento objAlimento;
        string index;

        public AdicionarAlimento()
        {
            InitializeComponent();
            AtualizarAlimento();
            
        }

        private void AtualizarAlimento()
        {
            objAlimento = new Alimento();
            this.ListaDeAlimentos.ItemsSource = objAlimento.ObtemAlimento();
            
        }

        private void PhoneTextBox_ActionIconTapped(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (objAlimento != null) 
            {
                this.ListaDeAlimentos.ItemsSource = objAlimento.ObtemAlimento().Where(w => w.DescricaoDoAlimento.ToUpper().Contains(txtSearch.Text.ToUpper()));
            }
        }

        private void ListaDeAlimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaDeAlimentos.SelectedIndex == -1)
                return;

            (Application.Current as App).alimentoSelecionado =
                (ListaDeAlimentos.Items[ListaDeAlimentos.SelectedIndex] as Alimento);

            NavigationService.Navigate(new Uri("/View/TabelaNutricional.xaml?item="+index,
                UriKind.Relative));
            ListaDeAlimentos.SelectedIndex = -1;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("item", out this.index);
        }

        
    }
}