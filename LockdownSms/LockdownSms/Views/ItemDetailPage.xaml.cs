using System.ComponentModel;
using Xamarin.Forms;
using LockdownSms.ViewModels;

namespace LockdownSms.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}