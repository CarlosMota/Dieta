using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Dieta.Classes;
using Dieta.ClassesAuxiliares;

namespace Dieta
{
    public partial class TelaCadastro : PhoneApplicationPage
    {
        string[] Metas;
        string[] NiveisAtividade;
  
        public TelaCadastro()
        {
            InitializeComponent();
            ConversorNivelAtividade conversorNivel = new ConversorNivelAtividade();
            NiveisAtividade = conversorNivel.VetorStringNiveisDeAtividade();
            ConversorMeta conversorMeta = new ConversorMeta();
            Metas = conversorMeta.VetorStringMeta();
            this.lPickerAtividade.ItemsSource = NiveisAtividade;
            this.lPickerMeta.ItemsSource = Metas;
        }
    
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (!ChecarPreenchimento() || !ChecarValidade())
            {
                return;
            }
            string nome = tBoxNome.Text;
            char sexo = 'f';
            if (rButtonMasculino.IsChecked == true)
                sexo = 'm';
            int idade = int.Parse(tBoxIdade.Text);
            double peso = double.Parse(tBoxPeso.Text);
            double altura = double.Parse(tBoxAltura.Text);
            ConversorNivelAtividade conversor = new ConversorNivelAtividade();
            NivelDeAtividade nAtividade = conversor.StringEmNivelDeAtividade(lPickerAtividade.SelectedItem.ToString());
            double pDesejado = double.Parse(tBoxPesoDesejado.Text);
            ConversorMeta conversorMeta = new ConversorMeta();
            Meta meta = conversorMeta.StringEmMeta(lPickerMeta.SelectedItem.ToString());
            (Application.Current as App).Usuario = new Usuario(nome, idade, sexo, peso, altura, nAtividade, pDesejado, meta);
            if (SalvarXML())
            {
                MessageBox.Show("Cadastro realizado com sucesso");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

       
        private bool SalvarXML()
        {
            try
            {
                using (IsolatedStorageFile myISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myISF.OpenFile(App.ARQUIVO_USUARIO, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Usuario));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream))
                        {
                            serializer.Serialize(xmlWriter, (Application.Current as App).Usuario);
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Erro durante o cadastro!");
                return false;
            }
            return true;
        }

        private bool ChecarPreenchimento()
        {
            TextBox[] tBoxes = { tBoxNome, tBoxIdade, tBoxPeso, tBoxPesoDesejado, tBoxAltura };
            for(int i =0; i<tBoxes.Length;i++)
            {     
                if (tBoxes[i].Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Por favor preencha todos os campos");
                    return false;
                }
            }
            if (rButtonMasculino.IsChecked != true && rButtonFeminino.IsChecked != true)
            {
                MessageBox.Show("Por favor marque um valor para sexo");
                return false;
            }
            return true;
        }

        private bool ChecarValidade()
        {
            double peso, pDesejado, altura;
            try
            {
                peso = double.Parse(tBoxPeso.Text);
                altura = double.Parse(tBoxAltura.Text);
                pDesejado = double.Parse(tBoxPesoDesejado.Text);
                int idade = int.Parse(tBoxIdade.Text);
                if (peso <= 0 || altura <= 0 || pDesejado <= 0 || idade <= 0)
                {
                    MessageBox.Show("Por favor insira valores maiores que zero em todos os campos numéricos");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor insira valores maiores que zero em todos os campos numéricos");
                return false;
            }
            return true;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string i;
            if (NavigationContext.QueryString.TryGetValue("primeiraVez", out i))
            {
                NavigationService.RemoveBackEntry();
                return;
            }
            Usuario usuario = (Application.Current as App).Usuario;
            tBoxNome.Text = usuario.Nome;
            if (usuario.Sexo == 'm')
                rButtonMasculino.IsChecked = true;
            else
                rButtonFeminino.IsChecked = true;
            tBoxIdade.Text = usuario.Idade.ToString();
            tBoxAltura.Text = usuario.Altura.ToString();
            tBoxPeso.Text = usuario.Peso.ToString();
            ConversorNivelAtividade conversorNivel = new ConversorNivelAtividade();
            string stringNAtividade = conversorNivel.NivelDeAtividadeEmString(usuario.NivelDeAtividade);
            List<string> listNiveis = NiveisAtividade.ToList();
            lPickerAtividade.SelectedIndex = listNiveis.IndexOf(stringNAtividade);
            tBoxPesoDesejado.Text = usuario.PesoDesejado.ToString();
            ConversorMeta conversorMeta = new ConversorMeta();
            string stringMeta = conversorMeta.MetaEmString(usuario.Meta);
            List<string> listMetas = Metas.ToList();
            lPickerMeta.SelectedIndex = listMetas.IndexOf(stringMeta);
        }
    }
}