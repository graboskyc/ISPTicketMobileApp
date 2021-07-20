using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Realms.Sync;

namespace ISPTicketMobileApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = await App.realm_RealmApp.LogInAsync(Credentials.EmailPassword(txt_email.Text, txt_password.Text));
                if (user != null)
                {
                    App.realm_RealmUser = user;
                    await Navigation.PushAsync(new TabbedMenu());
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", ex.Message, "OK");
            }
            
        }
    }
}
