using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LockdownSms.Services;
using LockdownSms.Views;
using System.IO;
using System.Linq;

namespace LockdownSms
{
    public partial class App : Application
    {
        static UserDatabase database;

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData)
                            , "Users.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockUserDataStore>();
            //DependencyService.Register<UserDatabase>();

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddUserDetails), typeof(AddUserDetails));
            Routing.RegisterRoute(nameof(SmsOptions), typeof(SmsOptions));

            MainPage = new SmsOptions();



        }

        protected override async void OnStart()
        {
            var users = await Database.GetItemsAsync();

            if (users.Count() > 0)
            {
                MainPage = new SmsOptions();
            }
            else
            {
                MainPage = new AddUserDetails();
            }

            MessagingCenter.Subscribe<string>(this, "Change", (sender) =>
            {
                MainPage = new SmsOptions();
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
