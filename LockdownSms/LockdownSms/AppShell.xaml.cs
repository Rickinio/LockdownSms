using System;
using System.Collections.Generic;
using LockdownSms.ViewModels;
using LockdownSms.Views;
using Xamarin.Forms;

namespace LockdownSms
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //Routing.RegisterRoute(nameof(AddUserDetails), typeof(AddUserDetails));
            //Routing.RegisterRoute(nameof(SmsOptions), typeof(SmsOptions));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
