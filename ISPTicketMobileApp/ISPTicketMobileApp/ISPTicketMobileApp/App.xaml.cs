using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Realms.Sync;
using Realms;

namespace ISPTicketMobileApp
{
    public partial class App : Application
    {
        private const string realm_AppID = "techtickets-aafwk";
        public static Realms.Sync.App realm_RealmApp;
        public static Realms.Sync.User realm_RealmUser { get; set; }
        public static Realms.Sync.SyncConfiguration realm_RealmSyncConfig { get; set; }
        public static Realm realm_Realm { get; set; }
        public static string realm_pk { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            realm_RealmApp = Realms.Sync.App.Create(realm_AppID);
            //if (App.realm_RealmApp.CurrentUser == null)
            //{
                MainPage = new NavigationPage(new LoginPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new TabbedMenu());
            //}
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
