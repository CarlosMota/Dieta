using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dieta.Classes;

namespace Dieta.View
{
    public partial class ConfiguracoesTela : PhoneApplicationPage
    {
        public ConfiguracoesTela()
        {
            InitializeComponent();
            Configuracoes configuracoes = new Configuracoes();
            TSwitchAgua.DataContext = configuracoes.IsReminderAguaOn();
            TPickerIntervaloAgua.DataContext = configuracoes.GetIntervaloAgua();
            TPickerComecoAgua.DataContext = configuracoes.GetHorarioInicioAgua();
            TPickerFimAgua.DataContext = configuracoes.GetHorarioFimAgua();
            TSwitchRefeicao.DataContext = configuracoes.IsReminderRefeicaoOn();
            TPickerIntervaloAgua.IsEnabled = configuracoes.IsReminderAguaOn(); 
            TPickerComecoAgua.IsEnabled = configuracoes.IsReminderAguaOn(); 
            TPickerFimAgua.IsEnabled = configuracoes.IsReminderAguaOn(); 
        }

        private void TSwitchAgua_Unchecked(object sender, RoutedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetReminderAguaOn(false);
            NotificadorAgua nAgua = new NotificadorAgua();
            nAgua.ApagarRemindersAgua();
            TPickerIntervaloAgua.IsEnabled = false;
            TPickerComecoAgua.IsEnabled = false;
            TPickerFimAgua.IsEnabled = false;
        }

        private void TSwitchAgua_Checked(object sender, RoutedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetReminderAguaOn(true);
            NotificadorAgua nAgua = new NotificadorAgua();
            nAgua.CriarRemindersAgua((Application.Current as App).Usuario.Peso);
            TPickerIntervaloAgua.IsEnabled = true;
            TPickerComecoAgua.IsEnabled = true;
            TPickerFimAgua.IsEnabled = true;
        }

        private void TPickerIntervaloAgua_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetIntervaloAgua(MetodosTempo.DateTimeToString((DateTime)e.NewDateTime));
            NotificadorAgua nAgua = new NotificadorAgua();
            nAgua.AtualizarRemindersAgua((Application.Current as App).Usuario.Peso);
            Atualizar();
        }

        private void TPickerComecoAgua_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetHorarioInicioAgua(MetodosTempo.DateTimeToString((DateTime)e.NewDateTime));
            NotificadorAgua nAgua = new NotificadorAgua();
            nAgua.AtualizarRemindersAgua((Application.Current as App).Usuario.Peso);
            Atualizar();
        }

        private void TPickerFimAgua_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetHorarioFimAgua(MetodosTempo.DateTimeToString((DateTime)e.NewDateTime));
            NotificadorAgua nAgua = new NotificadorAgua();
            nAgua.AtualizarRemindersAgua((Application.Current as App).Usuario.Peso);
            Atualizar();
        }

        private void TSwitchRefeicao_Checked(object sender, RoutedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetReminderRefeicaoOn(true);
            NotificadorRefeicao nRefeicao = new NotificadorRefeicao();
            nRefeicao.CriarRemindersRefeicao((Application.Current as App).ListaRefeicao);
        }

        private void TSwitchRefeicao_Unchecked(object sender, RoutedEventArgs e)
        {
            Configuracoes configuracoes = new Configuracoes();
            configuracoes.SetReminderRefeicaoOn(false);
            NotificadorRefeicao nRefeicao = new NotificadorRefeicao();
            nRefeicao.ApagarRemindersRefeicao();
        }

        private void Atualizar()
        {
            TSwitchAgua.DataContext = null;
            TPickerIntervaloAgua.DataContext = null;
            TPickerComecoAgua.DataContext = null;
            TPickerFimAgua.DataContext = null;
            TSwitchRefeicao.DataContext = null;
            Configuracoes configuracoes = new Configuracoes();
            TSwitchAgua.DataContext = configuracoes.IsReminderAguaOn();
            TPickerIntervaloAgua.DataContext = configuracoes.GetIntervaloAgua();
            TPickerComecoAgua.DataContext = configuracoes.GetHorarioInicioAgua();
            TPickerFimAgua.DataContext = configuracoes.GetHorarioFimAgua();
            TSwitchRefeicao.DataContext = configuracoes.IsReminderRefeicaoOn();
        }
    }
}