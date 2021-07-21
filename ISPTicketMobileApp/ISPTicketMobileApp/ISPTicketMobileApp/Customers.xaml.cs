using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Realms;
using Realms.Sync;

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
            //try
            //{
                App.realm_partition = "PUBLIC";
                App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
                App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);
                allCustomers = App.realm_realm.All<Models.Customer>();
                _customers = new ObservableCollection<Models.Customer>(allCustomers.ToList());
                lv.ItemsSource = _customers;

            //} 
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Error Fetching Customers", ex.Message, "OK");
                
            //}
            base.OnAppearing();
        }
    }
}