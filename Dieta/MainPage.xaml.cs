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

namespace Dieta 
 
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
        }


        private void CadastrarAlimento_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CadastroAlimentos.xaml", UriKind.RelativeOrAbsolute));
        }

        // Load data for the ViewModel Items
        
    }
}