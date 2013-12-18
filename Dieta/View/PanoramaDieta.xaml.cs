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
using Microsoft.Phone.Scheduler;
using Dieta.Classes;

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

            ListaCafe.ItemsSource = ListaRefeicao.ElementAt(0).Alimentos;
            ListaLanche.ItemsSource = ListaRefeicao.ElementAt(1).Alimentos;
            ListaAlmoco.ItemsSource = ListaRefeicao.ElementAt(2).Alimentos;
            ListaLancheTarde.ItemsSource = ListaRefeicao.ElementAt(3).Alimentos;
            ListaJanta.ItemsSource = ListaRefeicao.ElementAt(4).Alimentos;
            ListaCeia.ItemsSource = ListaRefeicao.ElementAt(5).Alimentos;
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
            while (NavigationService.BackStack.Count() > 1)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AdicionarAlimento.xaml?item="+this.panoramaDieta.SelectedIndex, UriKind.RelativeOrAbsolute));
        }

        private void ttp_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            ListaRefeicao.ElementAt(panoramaDieta.SelectedIndex).Horario = MetodosTempo.DateTimeToString((DateTime)e.NewDateTime);
            Configuracoes configuracoes = new Configuracoes();
            if (configuracoes.IsReminderRefeicaoOn())
                ProgramarReminders((DateTime)e.NewDateTime);
            configuracoes.SetHorarioReminderRefeicao(ListaRefeicao.ElementAt(panoramaDieta.SelectedIndex).Nome, ListaRefeicao.ElementAt(panoramaDieta.SelectedIndex).Horario);
            AtualizarPanorama();
        }

        private void ProgramarReminders(DateTime newDateTime)
        {
            NotificadorRefeicao nRefeicao = new NotificadorRefeicao();
            nRefeicao.AtualizarRemindersRefeicao(ListaRefeicao);
        }

        private void AtualizarPanorama()
        {
            PanoramaItem[] items = { ItemCafe, itemLanche, itemAlmoco, itemLancheTarde, itemJanta, itemCeia };
            for (int i = 0; i < items.Length; i++)
            {
                items[i].DataContext = null;
                items[i].DataContext = ListaRefeicao.ElementAt(i);
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SelecionarAlimentos.xaml?item=" + this.panoramaDieta.SelectedIndex, UriKind.RelativeOrAbsolute));
        }
    }

}