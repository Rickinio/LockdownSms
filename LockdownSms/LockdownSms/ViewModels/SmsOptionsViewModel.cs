using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace LockdownSms.ViewModels
{
    public class SmsOptionsViewModel : BaseViewModel
    {
        public SmsOptionsViewModel()
        {
            SendSmsCommand = new Command<string>(async (s) => await SendSms(s));
        }

        public Command<string> SendSmsCommand { get; private set; }
        private async Task SendSms(string option)
        {
            try
            {
                var users = (await App.Database.GetItemsAsync()).FirstOrDefault();

                //if (users == null)
                //{
                //    await Shell.Current.GoToAsync($"AddUserDetails");
                //}

                var smsText = $"{option} {users.FirstName} {users.LastName} {users.Address}";

                var message = new SmsMessage(smsText, new[] { "13033" });

                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
