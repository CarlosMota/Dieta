﻿using System;
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
using Dieta.Classes;
using Dieta.Model;
using Microsoft.Phone.Tasks;
using Microsoft.Phone;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;

namespace Dieta.View
{
    public partial class Perfil : PhoneApplicationPage
    {
        double CaloriasTotais;
        PhotoChooserTask camera;
        List<Foto> ListaBytesImagens;
        List<BitmapImage> ListaImagens;
       
        public Perfil()
        {
            InitializeComponent();
            carregaPerfil();
            camera = new PhotoChooserTask();
            ListaBytesImagens = new List<Foto>();
            ListaImagens = new List<BitmapImage>();
            this.Loaded += Perfil_Loaded;
            camera.Completed += camera_Completed;
            criarAlbum(); 
        }

        void Perfil_Loaded(object sender, RoutedEventArgs e)
        {
            AtualizarPivotDieta();
            carregarFotos();
            AlterarVisibilidadeTxtAdicionarFotos();
        }

        private void AlterarVisibilidadeTxtAdicionarFotos()
        {
            if (SavedPhotosList.Items.Count <= 0)
                txtAdicionarFotos.Visibility = System.Windows.Visibility.Visible;
            else
                txtAdicionarFotos.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ListaRefeicoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaRefeicoes.SelectedIndex == -1)
                return;

            (Application.Current as App).refeicaoSelecionada =
                (ListaRefeicoes.Items[ListaRefeicoes.SelectedIndex] as Refeicao);
           
            NavigationService.Navigate(new Uri("/View/PanoramaDieta.xaml?idRefeicao=" + (Application.Current as App).refeicaoSelecionada.IdRefeicao,
                UriKind.Relative));
            ListaRefeicoes.SelectedIndex = -1;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Sair do aplicativo?", "Logout", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //Faça alguma coisa aqui...
                base.OnBackKeyPress(e);
            }
            else
                e.Cancel = true;
        }

        private void ApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/View/CadastroUsuario.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Pivot_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationBarMenuItem itemConfiguracoes = new ApplicationBarMenuItem("configurações");
            itemConfiguracoes.Click += ApplicationBarMenuItem_Click;
            if (Pivot_Main.SelectedIndex == 0)
            {
                ApplicationBar = ThemeManager.CreateApplicationBar();
                ApplicationBarIconButton botaoEditar = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.edit.rest.png", UriKind.Relative));
                botaoEditar.Text = "editar";
                botaoEditar.Click += ApplicationBarIconButton_Click;
                ApplicationBar.Buttons.Add(botaoEditar);
                ApplicationBar.MenuItems.Add(itemConfiguracoes);
            }
            else if (Pivot_Main.SelectedIndex == 2)
            {
                ApplicationBar = ThemeManager.CreateApplicationBar();
                ApplicationBarIconButton botaoFoto = new ApplicationBarIconButton(new Uri("/Imagens/appbar.feature.camera.rest.png", UriKind.Relative));
                botaoFoto.Text = "foto";
                botaoFoto.Click += ApplicationBarIconButton_Click_1;
                ApplicationBar.Buttons.Add(botaoFoto);
                ApplicationBar.MenuItems.Add(itemConfiguracoes);
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            camera.ShowCamera = true;
            camera.Show(); 
        }

        private void criarAlbum() 
        {

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists("Dieta"))
                {
                    store.CreateDirectory("Dieta");
                }
            }
        }

        private void SavedPhotosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int indice = SavedPhotosList.SelectedIndex;
            try
            {
                if (SavedPhotosList.SelectedIndex == -1)
                return;
                MessageBoxResult resultado = MessageBox.Show("Deseja excluir foto?", "Atenção", MessageBoxButton.OKCancel);
                if (resultado.Equals(MessageBoxResult.OK))
                {
                    ListaBytesImagens.Remove(ListaBytesImagens.ElementAt
                    (SavedPhotosList.SelectedIndex));
                    ListaImagens.Remove(ListaImagens.ElementAt
                    (SavedPhotosList.SelectedIndex));
                    SavedPhotosList.SelectedIndex = -1;
                    SalvarFoto();
                    atualizarLBox();
                    AlterarVisibilidadeTxtAdicionarFotos();
                }
            }
            catch (Exception)
            {
               
            }

        }
        private void carregaPerfil()
        {
            TxtAltura.Text = "" + (Application.Current as App).Usuario.Altura;
            txtPesoInicial.Text = "" + (Application.Current as App).Usuario.Peso;
            TxtObjetivo.Text = "" + (Application.Current as App).Usuario.PesoDesejado;
            TxtIMC.Text = "" + Calculo.CalcularIMC((Application.Current as App).Usuario.Altura, (Application.Current as App).Usuario.Peso);
            CaloriasTotais = (Application.Current as App).CaloriasTotais;
            txtCalorias.Text = "" + CaloriasTotais;
            txtCaloriaTotal.Text = "" + CaloriasTotais;
            txtQuantidadeAgua.Text = "" + Calculo.calculoConsumoAgua((Application.Current as App).Usuario.Peso);
            txtSemanas.Text = (Calculo.calculoSemanas((Application.Current as App).Usuario.Peso, (Application.Current as App).Usuario.PesoDesejado)).ToString() + " semanas";
        }

        void camera_Completed(object sender, PhotoResult e)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                MemoryStream ms = new MemoryStream();
                WriteableBitmap wb = new WriteableBitmap(image);
                wb.SaveJpeg(ms, image.PixelWidth, image.PixelHeight, 0, 100);
                byte[] imageBytes = ms.ToArray();
                Foto foto = new Foto();
                foto.imagem = imageBytes;
                ListaBytesImagens.Add(foto);
                ListaImagens.Add(image);
                atualizarLBox();
                SalvarFoto();
            }
            catch (Exception)
            {

            }
            AlterarVisibilidadeTxtAdicionarFotos();
        }

        private void SalvarFoto()
        {
            string nome = "" + System.DateTime.Now;

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = store.OpenFile("Fotos.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Foto>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream))
                    {
                        serializer.Serialize(xmlWriter, ListaBytesImagens);
                    }
                } 
            }
        }

        private void carregarFotos() 
        {
            ListaImagens.Clear();
            try 
            {
                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream =
                        myISF.OpenFile("Fotos.xml", FileMode.OpenOrCreate))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Foto>));
                        ListaBytesImagens = (List<Foto>)serializer.Deserialize(stream);
                    }
                }
                foreach (Foto foto in ListaBytesImagens)
                {
                    MemoryStream ms = new MemoryStream(foto.imagem);
                    BitmapImage bi = new BitmapImage();
                    bi.SetSource(ms);
                    ListaImagens.Add(bi);
                }
                SavedPhotosList.ItemsSource = ListaImagens;
            }catch(Exception)
            {
            
            }     
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            while (NavigationService.BackStack.Count() > 0)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private ObservableCollection<Foto> _pics = new ObservableCollection<Foto>();

        public IEnumerable<Foto> Pics
        {
            get { return _pics; }
        }

        private void atualizarLBox()
        {
            SavedPhotosList.ItemsSource = null;
            SavedPhotosList.ItemsSource = ListaImagens;
            
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ConfiguracoesTela.xaml", UriKind.Relative));
        }

        private void AtualizarPivotDieta()
        {
            txtCaloriaUsuario.DataContext = null;
            ListaRefeicoes.ItemsSource = null;
            ListaRefeicoes.ItemsSource = (Application.Current as App).ListaRefeicao;
            txtCaloriaUsuario.DataContext = (Application.Current as App).CaloriasTotaisConsumidas;
        }

    }
}