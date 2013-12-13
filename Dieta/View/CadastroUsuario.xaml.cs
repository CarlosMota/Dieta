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
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.IO.IsolatedStorage;

namespace Dieta.View
{
    public partial class CadastroUsuario : PhoneApplicationPage
    {

        string[] Metas;
        string[] NiveisAtividade;
        

        public CadastroUsuario()
        {
            InitializeComponent();
            ConversorNivelAtividade conversorNivel = new ConversorNivelAtividade();
            NiveisAtividade = conversorNivel.VetorStringNiveisDeAtividade();
            this.lPickerAtividade.ItemsSource = NiveisAtividade;
            if ((Application.Current as App).Usuario != null)
                preencher();
            else
                ApplicationBar.Buttons.RemoveAt(1);
        }

        private void preencher()
        {
                Usuario usuario = (Application.Current as App).Usuario;
                tBoxNome.Text = usuario.Nome;
                tBoxIdade.Text = usuario.Idade.ToString();
                tBoxAltura.Text = (usuario.Altura/100.0).ToString();
                tBoxPeso.Text = usuario.Peso.ToString();
                tBoxPesoDesejado.Text = usuario.PesoDesejado.ToString();
                ConversorNivelAtividade convAtivitidade = new ConversorNivelAtividade();
                string nivel = convAtivitidade.NivelDeAtividadeEmString(usuario.NivelDeAtividade);
                lPickerAtividade.SelectedIndex = NiveisAtividade.ToList().IndexOf(nivel);
                if (usuario.Sexo == 'm')
                    rButtonMasculino.IsChecked = true;
                if (usuario.Sexo == 'f')
                    rButtonFeminino.IsChecked = true;
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
            double altura = 100*double.Parse(tBoxAltura.Text);
            ConversorNivelAtividade conversor = new ConversorNivelAtividade();
            NivelDeAtividade nAtividade = conversor.StringEmNivelDeAtividade(lPickerAtividade.SelectedItem.ToString());
            double pDesejado = double.Parse(tBoxPesoDesejado.Text);
            (Application.Current as App).Usuario = new Usuario(nome, idade, sexo, peso, altura, nAtividade, pDesejado);
            if (SalvarXML())
            {
                (Application.Current as App).configuracoes.setLogin("cadastro", "true");
                MessageBox.Show("Dados cadastrados/atualizados com sucesso");
                if (NavigationService.BackStack.Count() > 0)
                    NavigationService.GoBack();
                else
                    NavigationService.Navigate(new Uri("/View/Perfil.xaml", UriKind.Relative));
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
            for (int i = 0; i < tBoxes.Length; i++)
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
            string nome;
            double peso, pDesejado, altura;
            try
            {
                nome = tBoxNome.Text;
                peso = double.Parse(tBoxPeso.Text);
                altura = double.Parse(tBoxAltura.Text);
                pDesejado = double.Parse(tBoxPesoDesejado.Text);
                int idade = int.Parse(tBoxIdade.Text);
                if (nome.Length > 15 || peso < 40 || altura < 1.4 || pDesejado < 40 || idade < 10)
                {
                    MessageBox.Show("Por favor insira valores de acordo com os seguintes intervalos:\n"
                    +"Nome - maximo 15 caracteres\nAltura - mínimo 1,40 m\nIdade - mínimo 10\nPeso e Peso Desejado - mínimo 40 ");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor insira valores numéricos válidos em todos os campos numéricos");
                return false;
            }
            return true;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}