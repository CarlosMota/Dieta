using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using Dieta.DAO;
using System.Data.Linq;

namespace Dieta.Model
{
    [Table(Name = "Alimento")]
    public class Alimento
    {

        public Alimento()
        {
            //this._refeicao = default(EntityRef<Refeicao>);
        }

        private int _idAlimento;

        [Column(Name = "IdAlimento", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int IdAlimento
        {

            get { return _idAlimento; }
            set { _idAlimento = value; }
        }

        [Column(Name = "IdRefeicao")]
        public int IdRefeicao { get; set; }

        private string _descricaoDoAlimento;

        [Column(Name = "Descricao_do_Alimento")]
        public string DescricaoDoAlimento
        {
            get { return _descricaoDoAlimento; }
            set
            {
                if (_descricaoDoAlimento != value)
                {

                    _descricaoDoAlimento = value;

                }
            }
        }

        [Column(Name = "Desccricao_da_preparacao")]
        private string _descricaoPreparacao;

        public string DescricaoPreparacao
        {
            get { return _descricaoPreparacao; }
            set
            {
                if (_descricaoPreparacao != value)
                {

                    _descricaoPreparacao = value;

                }
            }
        }

        [Column(Name = "Calorias")]
        private double _calorias;

        public double Calorias
        {
            get { return _calorias; }
            set
            {
                if (_calorias != value)
                {

                    _calorias = value;

                }
            }
        }

        [Column(Name = "Proteinas")]
        private double _proteinas;

        public double Proteinas
        {
            get { return _proteinas; }
            set
            {
                if (_proteinas != value)
                {
                    _proteinas = value;
                }
            }
        }

        [Column(Name = "Gorduras_Totais ")]
        private double _gorduraTotais;

        public double GorduraTotais
        {
            get { return _gorduraTotais; }
            set
            {
                if (_gorduraTotais != value)
                {
                    _gorduraTotais = value;
                }
            }
        }

        [Column(Name = "Carboidratos")]
        private double _carboidratos;

        public double Carboidratos
        {
            get { return _carboidratos; }
            set
            { _carboidratos = value; }
        }

        [Column(Name = "Fibra_Alimentar")]
        private double _fibra_Alimentar;

        public double Fibra_Alimentar
        {
            get { return _fibra_Alimentar; }
            set { _fibra_Alimentar = value; }
        }

        [Column(Name = "Acucar")]
        private double _acucar;

        public double Acucar
        {
            get { return _acucar; }
            set { _acucar = value; }
        }

        [Column(Name = "Sodio")]
        private double _sodio;

        public double Sodio
        {
            get { return _sodio; }
            set { _sodio = value; }
        }


        [Column(Name = "Editavel")]
        private bool _editavel;

        public bool Editavel
        {
            get { return _editavel; }
            set
            { _editavel = value; }
        }

        private bool _realizada;

        [Column(Name = "Realizada", CanBeNull = false)]
        public bool Realizada
        {
            get { return _realizada; }
            set { _realizada = value; }
        }


        public bool Selecionada { get; set; }

        /*private EntityRef<Refeicao> _refeicao;

        [Association(Name = "Fk_ListaAlimentos", Storage = "_refeicao", ThisKey = "IdRefeicao", OtherKey = "IdAlimento", IsForeignKey = true)]

        public Refeicao _Refeicao
        {
            get { return _refeicao.Entity; }
            set
            {
                Refeicao previousValue = this._refeicao.Entity;
                if (((previousValue != value) || (this._refeicao.HasLoadedOrAssignedValue == false)))
                {
                    if ((previousValue != null))
                    {
                        this._refeicao.Entity = null;
                        previousValue.Alimentos.Remove(this);
                    }
                    this._refeicao.Entity = value;
                    if ((value != null))
                    {
                        value.Alimentos.Add(this);
                        IdRefeicao = value.IdRefeicao;
                    }
                    else
                    {
                        IdRefeicao = default(int);
                    }
                }
            }
        }*/



        public IEnumerable<Alimento> ObtemAlimento()
        {
            DAOAlimento daoAlimento = new DAOAlimento();
            return daoAlimento.ObtemAlimento();
        }

        public bool Gravar()
        {
            DAOAlimento daoAlimento = new DAOAlimento();
            return daoAlimento.Gravar(this);
        }

        public bool Excluir()
        {
            DAOAlimento daoAlimento = new DAOAlimento();
            return daoAlimento.Excluir(this);
        }

        public bool Realizado()
        {
            DAOAlimento daoAlimento = new DAOAlimento();
            return daoAlimento.Realizado(this);
        }

    }
}
