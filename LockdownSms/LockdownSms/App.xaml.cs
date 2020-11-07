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

            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
