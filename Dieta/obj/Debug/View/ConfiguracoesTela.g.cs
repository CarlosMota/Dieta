﻿#pragma checksum "C:\Users\Fabio\Documents\Visual Studio 2012\Projects\Dieta\Dieta\View\ConfiguracoesTela.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAE8F79C64CA1C3E7DD189AFE5AAF011"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
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
    
    
    public partial class ConfiguracoesTela : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel ContentPanel;
        
        internal Microsoft.Phone.Controls.ToggleSwitch TSwitchAgua;
        
        internal Microsoft.Phone.Controls.TimePicker TPickerIntervaloAgua;
        
        internal Microsoft.Phone.Controls.TimePicker TPickerComecoAgua;
        
        internal Microsoft.Phone.Controls.TimePicker TPickerFimAgua;
        
        internal Microsoft.Phone.Controls.ToggleSwitch TSwitchRefeicao;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Dieta;component/View/ConfiguracoesTela.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentPanel")));
            this.TSwitchAgua = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("TSwitchAgua")));
            this.TPickerIntervaloAgua = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("TPickerIntervaloAgua")));
            this.TPickerComecoAgua = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("TPickerComecoAgua")));
            this.TPickerFimAgua = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("TPickerFimAgua")));
            this.TSwitchRefeicao = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("TSwitchRefeicao")));
        }
    }
}

