using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            await Navigation.PushAsync(new TabbedPage1());
        }
    }
}
