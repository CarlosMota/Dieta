﻿#pragma checksum "C:\Users\Carlos\Documents\Visual Studio 2012\Dieta\Dieta\View\Perfil.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "001D386D31CFB85B9569DDAB780FFDB8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Dieta.View {
    
    
    public partial class Perfil : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PivotItem PivotPerfil;
        
        internal System.Windows.Controls.TextBlock TxtAltura;
        
        internal System.Windows.Controls.TextBlock txtPesoInicial;
        
        internal System.Windows.Controls.TextBlock TxtObjetivo;
        
        internal System.Windows.Controls.TextBlock TxtIMC;
        
        internal System.Windows.Documents.Run txtCalorias;
        
        internal Microsoft.Phone.Controls.PivotItem PivotDieta;
        
        internal System.Windows.Controls.TextBlock txtCaloriaUsuario;
        
        internal System.Windows.Controls.TextBlock txtCaloriaTotal;
        
        internal System.Windows.Controls.TextBlock txtQuantidadeAgua;
        
        internal System.Windows.Controls.ListBox ListaRefeicoes;
        
        internal Microsoft.Phone.Controls.PivotItem PivotEvolucao;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Dieta;component/View/Perfil.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PivotPerfil = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotPerfil")));
            this.TxtAltura = ((System.Windows.Controls.TextBlock)(this.FindName("TxtAltura")));
            this.txtPesoInicial = ((System.Windows.Controls.TextBlock)(this.FindName("txtPesoInicial")));
            this.TxtObjetivo = ((System.Windows.Controls.TextBlock)(this.FindName("TxtObjetivo")));
            this.TxtIMC = ((System.Windows.Controls.TextBlock)(this.FindName("TxtIMC")));
            this.txtCalorias = ((System.Windows.Documents.Run)(this.FindName("txtCalorias")));
            this.PivotDieta = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotDieta")));
            this.txtCaloriaUsuario = ((System.Windows.Controls.TextBlock)(this.FindName("txtCaloriaUsuario")));
            this.txtCaloriaTotal = ((System.Windows.Controls.TextBlock)(this.FindName("txtCaloriaTotal")));
            this.txtQuantidadeAgua = ((System.Windows.Controls.TextBlock)(this.FindName("txtQuantidadeAgua")));
            this.ListaRefeicoes = ((System.Windows.Controls.ListBox)(this.FindName("ListaRefeicoes")));
            this.PivotEvolucao = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotEvolucao")));
        }
    }
}
