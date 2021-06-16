using System.ComponentModel;
using Vendedor_Tubflex.ViewModels;
using Xamarin.Forms;

namespace Vendedor_Tubflex.Views
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