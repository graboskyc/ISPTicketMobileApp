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
    public partial class Profile : ContentPage
    {

        public Profile()
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
                Models.Technician me = App.realm_realm.All<Models.Technician>().FirstOrDefault();
                txt_phone.Text = me.Phone;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Fetching Profile", ex.Message, "OK");

            }
            base.OnAppearing();
        }
    }
}