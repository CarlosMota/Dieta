
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace Dieta.Tabelas
{
    [Table]
    public class AlmocoDAO :INotifyPropertyChanged, INotifyPropertyChanging
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
        private string _lipidios;

        public string Lipidios
        {
            get{ return _lipidios;}
            set
            {
                if(_proteinas != value)
                {
                    this.NotifyPropertyChanging("Lipideos");
                    _lipidios = value;
                    this.NotifyPropertyChanged("Lipideos");
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

    }
}
