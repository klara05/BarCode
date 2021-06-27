using BarCode.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BarCode.Views
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