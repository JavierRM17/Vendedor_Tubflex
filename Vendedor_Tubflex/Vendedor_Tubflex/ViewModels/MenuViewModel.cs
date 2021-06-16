using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vendedor_Tubflex.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            Title = "Menu";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
