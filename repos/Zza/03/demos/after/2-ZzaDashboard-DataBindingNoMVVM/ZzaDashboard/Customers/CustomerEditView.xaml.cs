using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public partial class CustomerEditView : UserControl
    {
        private ICustomersRepository _repository = new CustomersRepository();
        private Customer _customer = null;

        public CustomerEditView()
        {
            InitializeComponent();
        }

        public Guid CustomerId
        {
            get { return (Guid)GetValue(CustomerIdProperty); }
            set { SetValue(CustomerIdProperty, value); }
        }

        public static readonly DependencyProperty CustomerIdProperty =
            DependencyProperty.Register("CustomerId", typeof(Guid),
            typeof(CustomerEditView), new PropertyMetadata(Guid.Empty));

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            _customer = await _repository.GetCustomerAsync(CustomerId);
            DataContext = _customer;
        }

        private async void OnSave(object sender, RoutedEventArgs e)
        {
            await _repository.UpdateCustomerAsync(_customer);
        }
    }
}
