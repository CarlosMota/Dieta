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
            ListaRefeicoes.ItemsSource = (Application.Current as App).ListaRefeicao;
            carregarFotos();
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
            if (Pivot_Main.SelectedIndex == 0)
            {
                ApplicationBar = (Microsoft.Phone.Shell.ApplicationBar)Resources["appbar1"];
            }
            else if (Pivot_Main.SelectedIndex == 2)
            {
                ApplicationBar = (Microsoft.Phone.Shell.ApplicationBar)Resources["appbar2"];
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
           
        }

        private void carregaPerfil()
        {
            TxtAltura.Text = "" + (Application.Current as App).Usuario.Altura;
            txtPesoInicial.Text = "" + (Application.Current as App).Usuario.Peso;
            TxtObjetivo.Text = "" + (Application.Current as App).Usuario.PesoDesejado;
            TxtIMC.Text = "" + Calculo.CalcularIMC((Application.Current as App).Usuario.Altura, (Application.Current as App).Usuario.Peso);
            CaloriasTotais = Calculo.caluloCalorias((Application.Current as App).Usuario.Sexo, (Application.Current as App).Usuario.Altura, (Application.Current as App).Usuario.Peso, (Application.Current as App).Usuario.Idade, (Application.Current as App).Usuario.NivelDeAtividade);
            txtCalorias.Text = "" + CaloriasTotais;
            txtCaloriaTotal.Text = "" + CaloriasTotais;
            txtQuantidadeAgua.Text = "" + Calculo.calculoConsumoAgua((Application.Current as App).Usuario.Peso, CaloriasTotais);
            (Application.Current as App).ListaRefeicao = Fabrica.FabricaRefeicao.criarRefeicoes(CaloriasTotais);

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
            NavigationService.RemoveBackEntry();
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



    }
}