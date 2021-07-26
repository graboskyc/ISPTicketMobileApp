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
    public partial class ViewTicket : ContentPage
    {
        private MongoDB.Bson.ObjectId _id;

        public ViewTicket(MongoDB.Bson.ObjectId id)
        {
            InitializeComponent();
            _id = id;
        }

        protected override async void OnAppearing()
        {
            try
            {
                App.realm_partition = App.realm_user.Id;
                App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
                App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);
                Models.Ticket t = App.realm_realm.All<Models.Ticket>().FirstOrDefault();

                txt_ticketNum.Text = "Ticket #" + t.TicketNumber.ToString();
                txt_comment.Text = t.Comment;
                txt_status.Text = t.Status.Option;
                txt_tech.Text = t.Technician.Name;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Ticket Details", ex.Message, "OK");

            }
            base.OnAppearing();
        }
    }
}