using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPF_DataLayer
{
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _DataCollection;
        private Product _Entity;


        public ProductViewModel()
        {
        //    try
        //    {
        //
            LoadProducts();
        //    }
        //    catch (Exception ex)
        //    {
        //        ConsoleErrorHandler err = new ConsoleErrorHandler();
        //        err.RecordError(this,ex.Message);
        //    }
        }
        public ObservableCollection<Product> DataCollection
        {
            get
            {
                return _DataCollection;
            }
            set
            {
                _DataCollection = value;
                OnPropertyChanged("DataCollection");
            }
        }

        public Product Entity
        {
            get
            {
                return _Entity;
            }
            set
            {
                _Entity = value;
                OnPropertyChanged("Entity");
            }
        }


        public void LoadProducts()
        {
            ProductManager mgr = new ProductManager();

            DataCollection = new ObservableCollection<Product>(mgr.GetProducts());

        }
    }
}
