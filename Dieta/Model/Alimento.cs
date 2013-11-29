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

        [Column(Name = "Gordura Saturada", CanBeNull = true)]
        private double _gorduraSaturada;

        public double GorduraSaturada 
        {
            get { return _gorduraSaturada; }
            set
            {
                if (_gorduraSaturada != value) 
                {
                    _gorduraSaturada = value;
                }
            }
        }

        [Column(Name = "Gordura Trans", CanBeNull = true)]
        private double _gorduraTrans;

        public double GorduraTrans
        {
            get { return _gorduraTrans; }
            set
            { _gorduraTrans = value;}
        }

        [Column(Name = "Sodio", CanBeNull = true)]
        private double _sodio;

        public double Sodio 
        {
            get { return _sodio;}
        }

        [Column(Name = "Carboidratos", CanBeNull = true)]
        private double _carboidratos;

        public double Carboidratos
        {
            get { return _carboidratos; }
            set
            {_carboidratos = value;}
        }

        [Column(Name = "Tipo refeicao", CanBeNull = false)]
        private double _tipoReifacao;

        public double TipoRefeicao
        {
            get { return _tipoReifacao; }
            set
            { _tipoReifacao = value; }
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
