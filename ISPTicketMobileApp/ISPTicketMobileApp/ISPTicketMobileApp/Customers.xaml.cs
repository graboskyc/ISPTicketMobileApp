using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISPTicketMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customers : ContentPage
    {
        private IQueryable<Models.Customer> allCustomers = null;
        private ObservableCollection<Models.Customer> _customers = new ObservableCollection<Models.Customer>();

        public Customers()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                allCustomers = App.realm_Realm.All<Models.Customer>();
                _customers = new ObservableCollection<Models.Customer>(allCustomers.ToList());
                lv_customers.ItemsSource = _customers;

            } 
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Customers", ex.Message, "OK");
                
            }
            base.OnAppearing();
        }
    }
}