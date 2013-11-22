using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace Dieta.Tabelas
{
    public class Alimento : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanged(string propertyName) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyPropertyChanging(string propertyName) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        private int _id;
        [Column(IsPrimaryKey=true, IsDbGenerated=true,DbType="INT NOT NULL Identity", CanBeNull=false,AutoSync=AutoSync.OnInsert)]
        public int Id
        {
            get {return _id;}
            set
            {
                if(_id != value)
                {
                    this.NotifyPropertyChanging("ID");
                    _id = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }

        [Column]
        private string _descricaoDoAlimento;

        public string descricaoDoAlimento
        {
            get{ return _descricaoDoAlimento;}
            set
            {
                if(_descricaoDoAlimento != value)
                {
                    this.NotifyPropertyChanging("descricao do Alimento");
                    _descricaoDoAlimento = value;
                    this.NotifyPropertyChanged("descricao do Alimento");
                }
            }
        }

        [Column]
        private string _calorias;

        public string Calorias
        {
            get{ return _descricaoDoAlimento;}
            set
            {
                if(_calorias != value)
                {
                    this.NotifyPropertyChanging("Calorias");
                    _calorias = value;
                    this.NotifyPropertyChanged("Calorias");
                }
            }
        }

        [Column]
        private string _proteinas;

        public string Proteinas
        {
            get{ return _proteinas;}
            set
            {
                if(_proteinas != value)
                {
                    this.NotifyPropertyChanging("Proteinas");
                    _proteinas = value;
                    this.NotifyPropertyChanged("Proteinas");
                }
            }
        }

        

        [Column]
        private string _sodio;

        public string Sodio
        {
            get{ return _sodio;}
            set
            {
                if(_sodio != value)
                {
                    this.NotifyPropertyChanging("Sodio");
                    _sodio = value;
                    this.NotifyPropertyChanged("Sodio");
                }
            }
        }

        [Column]
        private string _carboidratos;

        public string Carboidratos
        {
            get{ return _carboidratos;}
            set
            {
                if(_carboidratos != value)
                {
                    this.NotifyPropertyChanging("Carboidratos");
                    _carboidratos = value;
                    this.NotifyPropertyChanged("Carboidratos");
                }
            }
        }

        [Column]
        private string _gramas;

        public string Gramas
        {
            get { return _gramas; }
            set
            {
                if (_gramas != value)
                {
                    this.NotifyPropertyChanging("Gramas");
                    _gramas = value;
                    this.NotifyPropertyChanged("Gramas");
                }
            }
        }

        [Column]
        private string _porcao;

        public string Porcao
        {
            get { return _porcao; }
            set
            {
                if (_porcao != value)
                {
                    this.NotifyPropertyChanging("Porção");
                    _porcao = value;
                    this.NotifyPropertyChanged("Porção");
                }
            }
        }

        [Column]
        private string _gordurasTotais;

        public string GordurasTotais
        {
            get { return _gordurasTotais; }
            set
            {
                if (_gordurasTotais != value)
                {
                    this.NotifyPropertyChanging("Gorduras Totais");
                    _gordurasTotais = value;
                    this.NotifyPropertyChanged("Gorduras Totais");
                }
            }
        }

        [Column]
        private string _gorduraSaturada;

        public string GorduraSaturadas
        {
            get { return _gorduraSaturada; }
            set
            {
                if (_gorduraSaturada != value)
                {
                    this.NotifyPropertyChanging("Gordura Saturada");
                    _gorduraSaturada = value;
                    this.NotifyPropertyChanged("Gordura Saturada");
                }
            }
        }

        [Column]
        private string _gorduraTrans;

        public string GorduraSaturada 
        {
        
            get { return _gorduraTrans; }
            set
            {
                if (_gorduraTrans != value)
                {
                    this.NotifyPropertyChanging("Gorduras Trans");
                    _gorduraTrans = value;
                    this.NotifyPropertyChanged("Gorduras trans");
                }
            }
        }

        [Column]
        private string _fibras;

        public string Fibra
        {

            get { return _fibras; }
            set
            {
                if (_fibras != value)
                {
                    this.NotifyPropertyChanging("Fibras");
                    _fibras = value;
                    this.NotifyPropertyChanged("Fibras");
                }
            }
        }

        [Column]
        private string _acucar;

        public string Acucar
        {

            get { return _acucar; }
            set
            {
                if (_acucar != value)
                {
                    this.NotifyPropertyChanging("Açúcar");
                    _acucar = value;
                    this.NotifyPropertyChanged("Açúcar");
                }
            }
        }



        [Column]
        private string _tipoRefeicao;

        public string TipoRefeicao
        {
            get{ return _tipoRefeicao;}
            set
            {
                if(_tipoRefeicao != value)
                {
                    this.NotifyPropertyChanging("Tipo de refeições");
                    _tipoRefeicao = value;
                    this.NotifyPropertyChanged("Tipo de refeições");
                }
            }
        }

        [Column]
        private bool _deleta;

        public bool Deleta
        {
            get { return _deleta; }
            set
            {
                if (_deleta != value)
                {
                    this.NotifyPropertyChanging("Deleta");
                    _deleta = value;
                    this.NotifyPropertyChanged("Deleta");
                }
            }
        }

    }
}
