﻿using System;
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
        private IQueryable<Models.TicketStatus> allStatuses;
        //private ObservableCollection<Models.TicketStatus> _ts = new ObservableCollection<Models.TicketStatus>();

        public ViewTicket(MongoDB.Bson.ObjectId id)
        {
            InitializeComponent();
            _id = id;
        }

        protected override async void OnAppearing()
        {
            try
            {
                // Get ticket raw details yet
                App.realm_partition = App.realm_user.Id;
                App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
                App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);

                Models.Ticket t = App.realm_realm.All<Models.Ticket>().Where(tix => tix.Id == _id).FirstOrDefault();
                Models.Technician me = App.realm_realm.All<Models.Technician>().FirstOrDefault();

                // Realms for Custmer and Status are GLOBAL so we need another instance
                App.realm_partition = "PUBLIC";
                App.realm_config = new Realms.Sync.SyncConfiguration(App.realm_partition, App.realm_user);
                App.realm_realm = await Realm.GetInstanceAsync(App.realm_config);

                // Statuses
                allStatuses = App.realm_realm.All<Models.TicketStatus>();

                // Customer
                Models.Customer c = App.realm_realm.All<Models.Customer>().Where(cus => cus.Id == t.Customer).FirstOrDefault();

                txt_ticketNum.Text = "Ticket #" + t.TicketNumber.ToString();
                txt_comment.Text = t.Comment;
                txt_status.Text = t.Status;
                txt_tech.Text = me.Name;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Ticket Details", ex.Message, "OK");

            }
            base.OnAppearing();
        }
    }
}