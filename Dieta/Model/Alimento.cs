using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using Dieta.DAO;


namespace Dieta.Model
{
    [Table(Name="Alimento")]
    public class Alimento 
    {
        private int _id;

        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricaoDoAlimento;

        [Column(Name = "Descricao", CanBeNull = false)]
        public string DescricaoDoAlimento
         {
             get{ return _descricaoDoAlimento;}
             set
             {
                 if(_descricaoDoAlimento != value)
                 {
                     
                     _descricaoDoAlimento = value;
                     
                 }
             }
         }

        [Column(Name = "Desccricao_da_preparacao", CanBeNull = false)]
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

        [Column(Name = "Calorias", CanBeNull = false)]
         private string _calorias;
 
         public string Calorias
         {
             get{ return _calorias;}
             set
             {
                 if(_calorias != value)
                 {
                     
                     _calorias = value;
                     
                 }
             }
         }

         [Column(Name = "Proteinas", CanBeNull = false)]
         private string _proteinas;

         public string Proteinas
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

        [Column(Name = "Gorduras_Totais ", CanBeNull = true)]
        private string _gorduraTotais;

        public string GorduraSaturada 
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

        [Column(Name = "Carboidratos", CanBeNull = true)]
        private string _carboidratos;

        public string Carboidratos
        {
            get { return _carboidratos; }
            set
            { _carboidratos = value; }
        }

        [Column(Name = "Fibra_Alimentar", CanBeNull = true)]
        private string _fibra_Alimentar;

        public string Fibra_Alimentar
        {
            get { return _fibra_Alimentar; }
            set{ _fibra_Alimentar = value; }
        }

        [Column(Name = "Acucar", CanBeNull = true)]
        private string _acucar;

        public string Acucar 
        {
            get { return _acucar;}
            set {_acucar = value; }
        }

        [Column(Name = "Sodio", CanBeNull = true)]
        private string _sodio;

        public string Sodio
        {
            get { return _sodio; }
            set { _sodio = value; }
        }


        [Column(Name = "Deleta", CanBeNull = false)]
        private bool _deleta;

        public bool Deleta
        {
            get { return _deleta; }
            set
            { _deleta = value; }
        }

        private bool _realizada;

        public bool Realizada
        {
            get { return _realizada; }
            set { _realizada = value; }
        }

        public IEnumerable<Alimento> ObtemAlimento()
        {
            DAOAlimento daoTarefa = new DAOAlimento();
            return daoTarefa.ObtemAlimento();
        }

        public bool Gravar()
        {
            DAOAlimento daoTarefa = new DAOAlimento();
            return daoTarefa.Gravar(this);
        }

        public bool Excluir()
        {
            DAOAlimento daoTarefa = new DAOAlimento();
            return daoTarefa.Excluir(this);
        }

        public bool Realizado()
        {
            DAOAlimento daoTarefa = new DAOAlimento();
            return daoTarefa.Realizado(this);
        }

        

    }
}
