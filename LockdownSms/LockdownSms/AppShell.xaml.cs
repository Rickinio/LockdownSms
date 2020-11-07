using System;
using System.Collections.Generic;
using System.Linq;
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

            Routing.RegisterRoute(nameof(AddUserDetails), typeof(AddUserDetails));
            Routing.RegisterRoute(nameof(SmsOptions), typeof(SmsOptions));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var users = await App.Database.GetItemsAsync();
            var user = users.FirstOrDefault();

            await Shell.Current.GoToAsync($"//AddUserDetails?UserId={user.Id}");
        }        
    }
}
