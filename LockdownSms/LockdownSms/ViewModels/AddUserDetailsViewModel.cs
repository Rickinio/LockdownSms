using LockdownSms.Models;
using LockdownSms.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LockdownSms.ViewModels
{
    public class AddUserDetailsViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string address;

        public AddUserDetailsViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(lastName)
                && !String.IsNullOrWhiteSpace(address);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync(nameof(SmsOptions));

            MessagingCenter.Send<string>("AddUserDetailsViewModel", "Change");
        }

        private async void OnSave()
        {
            await App.Database.AddItemAsync(new User { 
                Id = Guid.NewGuid().ToString(),
                FirstName = FirstName,
                LastName = LastName,
                Address = Address
            });

            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync(nameof(SmsOptions));

            MessagingCenter.Send<string>("AddUserDetailsViewModel", "Change");
        }
    }
}