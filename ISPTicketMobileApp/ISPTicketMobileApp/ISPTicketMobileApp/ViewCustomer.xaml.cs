using System;
using System.Collections.Generic;
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
    public partial class ViewCustomer : ContentPage
    {
        private MongoDB.Bson.ObjectId _id;
        public ViewCustomer(MongoDB.Bson.ObjectId id)
        {
            InitializeComponent();
            _id = id;
            
        }

        protected override async void OnAppearing()
        {
            try
            {
                App.realm_partition = "PUBLIC";
                App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
                App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);
                Models.Customer c = App.realm_realm.All<Models.Customer>().Where(cus => cus.Id == _id).FirstOrDefault();

                txt_fullname.Text = c.Name;
                txt_notes.Text = c.Notes;
                txt_phone.Text = c.Phone;
                txt_acct.Text = c.AccountNumber.ToString();
                txt_addr.Text = c.Address;
                txt_bd.Text = c.Birthday.ToString("dd/MM/yyyy");
                txt_email.Text = c.Email;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Profile", ex.Message, "OK");

            }
            base.OnAppearing();
        }
    }
}