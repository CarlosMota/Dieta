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

namespace Dieta.View
{
    public partial class PanoramaDieta : PhoneApplicationPage
    {
        public PanoramaDieta()
        {
            InitializeComponent();
            List<Refeicao> ListaRefeicao = (Application.Current as App).ListaRefeicao;
            this.ItemCafe.DataContext = ListaRefeicao.ElementAt(0);
            this.itemLanche.DataContext = ListaRefeicao.ElementAt(1);
            this.itemAlmoco.DataContext = ListaRefeicao.ElementAt(2);
            this.itemLancheTarde.DataContext = ListaRefeicao.ElementAt(3);
            this.itemJanta.DataContext = ListaRefeicao.ElementAt(4);
            this.itemCeia.DataContext = ListaRefeicao.ElementAt(5);
            
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