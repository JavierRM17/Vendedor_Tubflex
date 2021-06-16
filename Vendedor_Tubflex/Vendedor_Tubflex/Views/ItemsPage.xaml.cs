using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendedor_Tubflex.Models;
using Vendedor_Tubflex.ViewModels;
using Vendedor_Tubflex.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vendedor_Tubflex.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}