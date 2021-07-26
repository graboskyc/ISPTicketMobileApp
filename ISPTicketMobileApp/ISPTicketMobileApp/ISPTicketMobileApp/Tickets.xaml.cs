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
    public partial class Tickets : ContentPage
    {
        private IQueryable<Models.Ticket> allTickets = null;
        private ObservableCollection<Models.Ticket> _tickets = new ObservableCollection<Models.Ticket>();

        public Tickets()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
            App.realm_partition = App.realm_user.Id;
            App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
            App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);
            allTickets = App.realm_realm.All<Models.Ticket>();
            _tickets = new ObservableCollection<Models.Ticket>(allTickets.ToList());
            lv.ItemsSource = _tickets;

            } 
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Tickets", ex.Message, "OK");

            }
            base.OnAppearing();
        }

        private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            Models.Ticket t = (Models.Ticket)lv.SelectedItem;

            // assuiming Club has an Id property
            await Navigation.PushAsync(new ViewTicket(t.Id));
        }
    }
}