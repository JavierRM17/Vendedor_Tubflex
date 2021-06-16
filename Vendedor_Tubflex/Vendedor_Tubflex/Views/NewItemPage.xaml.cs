using System;
using System.Collections.Generic;
using System.ComponentModel;
using Vendedor_Tubflex.Models;
using Vendedor_Tubflex.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vendedor_Tubflex.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}