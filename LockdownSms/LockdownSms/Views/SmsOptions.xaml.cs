using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockdownSms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmsOptions : ContentPage
    {
        public SmsOptions()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            
            var users = await App.Database.GetItemsAsync();

            if (users.Count() > 0)
            {
                base.OnAppearing();
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(AddUserDetails));
            }
        }
    }
}