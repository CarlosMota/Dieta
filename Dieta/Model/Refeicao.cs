using Dieta.DAO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Dieta.Model
{
    //[Table(Name = "Refeicao")]
    public class Refeicao
    {

        public Refeicao()
        {
            //this._alimento = new EntitySet<Alimento>(new Action<Alimento>(Anexar_Alimento), new Action<Alimento>(Tirar_Alimento));
        }

        //[Column(Name = "IdRefeicao", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int IdRefeicao { set; get; }

        //[Column(Name = "Nome")]
        public string Nome { set; get; }

        //[Column(Name = "Quantidade_Calorica")]
        public double QuantidadeCaloricaDaRefeicaoTotal { set; get; }

        public double QuantidadeCaloricaConsumida { get; set; }

        //[Column(Name = "Horario")]
        public string Horario { set; get; }

        private bool _realizada;

        //[Column(Name = "Realizada", CanBeNull = false)]
        public bool Realizada
        {
            get { return _realizada; }
            set { _realizada = value; }
        }

        private BitmapImage _imagem;

        public BitmapImage Imagem { get; set; }

        /*public IEnumerable<Refeicao> ObtemRefeicoes()
        {
            DAORefeicao daoRefeicao = new DAORefeicao();
            return daoRefeicao.ObtemRefeicao();
        }*/

        /*public bool Gravar()
        {
            DAORefeicao daoRefeicao = new DAORefeicao();
            return daoRefeicao.Gravar(this);
        }

        public bool Excluir()
        {
            DAORefeicao daoRefeicao = new DAORefeicao();
            return daoRefeicao.Excluir(this);
        }

        public bool Realizado()
        {
            DAORefeicao daoRefeicao = new DAORefeicao();
            return daoRefeicao.Realizado(this);
        }

        /*private void Anexar_Alimento(Alimento obj)
        {
            obj._Refeicao = this;
        }

        private void Tirar_Alimento(Alimento obj)
        {
            obj._Refeicao = null;
        }

        private EntitySet<Alimento> _alimento;

        [Association(Name = "Fk_ListaAlimentos", Storage = "_alimento", ThisKey = "IdRefeicao", OtherKey = "IdAlimento")]
        public EntitySet<Alimento> Alimentos
        {
            get { return _alimento; }
            set { _alimento.Assign(value); }
        }*/



    }
}
