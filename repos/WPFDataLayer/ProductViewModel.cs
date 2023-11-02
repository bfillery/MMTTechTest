using System.Collections.ObjectModel;


namespace WPFDataLayer
{
    public class ProductViewModel : ViewModelBase
    {

        private ObservableCollection<Product> _DataCollection;
        private Product _Entity;
        private bool _IsSaveEnabled;
        private bool _IsCancelEnabled;

        //public ProductViewModel()
        //{
        //    try
        //    {
        //        LoadProducts();
        //    }
        //    catch (Exception ex)
        //    {
        //        ConsoleErrorHandler err = new ConsoleErrorHandler();
        //        err.RecordError(this,ex.Message);
        //    }
        //}
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

        public bool IsSaveEnabled {
            get
            {
                return _IsSaveEnabled;
            }
            set
            {
                _IsSaveEnabled = value;
                OnPropertyChanged("IsSaveEnabled");
            }
        }

        public bool IsCancelEnabled
        {
            get
            {
                return _IsCancelEnabled;
            }
            set
            {
                _IsCancelEnabled = value;
                OnPropertyChanged("IsCancelEnabled");
            }
        }

        public void LoadProducts()
        {
            ProductManager mgr = new ProductManager();

            DataCollection = new ObservableCollection <Product>(mgr.GetProducts());

        }
    }
}
