﻿#pragma checksum "C:\Users\Carlos\Documents\GitHub\Dieta\Dieta\View\CadastroUsuario.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F2A49975AA5CB2D51D139B7099EA6AB5"
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
    
    
    public partial class CadastroUsuario : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.DataTemplate itemlPickerTemplate;
        
        internal System.Windows.DataTemplate itemLPickerTemplateModoCheio;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ScrollViewer ContentPanel;
        
        internal System.Windows.Controls.TextBox tBoxNome;
        
        internal System.Windows.Controls.RadioButton rButtonMasculino;
        
        internal System.Windows.Controls.RadioButton rButtonFeminino;
        
        internal System.Windows.Controls.TextBox tBoxIdade;
        
        internal System.Windows.Controls.TextBox tBoxPeso;
        
        internal System.Windows.Controls.TextBox tBoxAltura;
        
        internal System.Windows.Controls.StackPanel sPanelLPickerAtividade;
        
        internal Microsoft.Phone.Controls.ListPicker lPickerAtividade;
        
        internal System.Windows.Controls.TextBox tBoxPesoDesejado;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Dieta;component/View/CadastroUsuario.xaml", System.UriKind.Relative));
            this.itemlPickerTemplate = ((System.Windows.DataTemplate)(this.FindName("itemlPickerTemplate")));
            this.itemLPickerTemplateModoCheio = ((System.Windows.DataTemplate)(this.FindName("itemLPickerTemplateModoCheio")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.ScrollViewer)(this.FindName("ContentPanel")));
            this.tBoxNome = ((System.Windows.Controls.TextBox)(this.FindName("tBoxNome")));
            this.rButtonMasculino = ((System.Windows.Controls.RadioButton)(this.FindName("rButtonMasculino")));
            this.rButtonFeminino = ((System.Windows.Controls.RadioButton)(this.FindName("rButtonFeminino")));
            this.tBoxIdade = ((System.Windows.Controls.TextBox)(this.FindName("tBoxIdade")));
            this.tBoxPeso = ((System.Windows.Controls.TextBox)(this.FindName("tBoxPeso")));
            this.tBoxAltura = ((System.Windows.Controls.TextBox)(this.FindName("tBoxAltura")));
            this.sPanelLPickerAtividade = ((System.Windows.Controls.StackPanel)(this.FindName("sPanelLPickerAtividade")));
            this.lPickerAtividade = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lPickerAtividade")));
            this.tBoxPesoDesejado = ((System.Windows.Controls.TextBox)(this.FindName("tBoxPesoDesejado")));
        }
    }
}

