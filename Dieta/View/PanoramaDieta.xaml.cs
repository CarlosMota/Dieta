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
    public partial class PanoramaDieta : PhoneApplicationPage
    {
        List<Refeicao> ListaRefeicao;

        public PanoramaDieta()
        {
            InitializeComponent();
            ListaRefeicao = (Application.Current as App).ListaRefeicao;
            this.ItemCafe.DataContext = ListaRefeicao.ElementAt(0);
            this.itemLanche.DataContext = ListaRefeicao.ElementAt(1);
            this.itemAlmoco.DataContext = ListaRefeicao.ElementAt(2);
            this.itemLancheTarde.DataContext = ListaRefeicao.ElementAt(3);
            this.itemJanta.DataContext = ListaRefeicao.ElementAt(4);
            this.itemCeia.DataContext = ListaRefeicao.ElementAt(5);
            lerRefeicoes();
        }

        private void lerRefeicoes()
        {
            ListaCafe.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(0).NomeDoArquivo, ListaRefeicao.ElementAt(0));
            ListaLanche.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(1).NomeDoArquivo, ListaRefeicao.ElementAt(1));
            ListaAlmoco.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(2).NomeDoArquivo, ListaRefeicao.ElementAt(2));
            ListaLancheTarde.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(3).NomeDoArquivo, ListaRefeicao.ElementAt(3));
            ListaJanta.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(4).NomeDoArquivo, ListaRefeicao.ElementAt(4));
            ListaCeia.ItemsSource = Arquivo.LerRefeicaoXML(ListaRefeicao.ElementAt(5).NomeDoArquivo, ListaRefeicao.ElementAt(5));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string index;
            int i = panoramaDieta.SelectedIndex;
            if (NavigationContext.QueryString.TryGetValue("idRefeicao", out index)&&i==-1)
            {
                panoramaDieta.DefaultItem = panoramaDieta.Items[int.Parse(index)];
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AdicionarAlimento.xaml?item="+this.panoramaDieta.SelectedIndex, UriKind.RelativeOrAbsolute));
        }
    }

}