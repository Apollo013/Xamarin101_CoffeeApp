using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin101_CoffeeApp.Models;

namespace Xamarin101_CoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffee = ((ListView)sender).SelectedItem as Coffee;
            
            if (coffee == null)
            {
                return;
            }

            await DisplayAlert("Coffee Selected", coffee.Name, "Ok");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var coffee = ((MenuItem)sender).BindingContext as Coffee;

            if (coffee == null)
            {
                return;
            }

            await DisplayAlert("Coffee Fovourite", coffee.Name, "Ok");
        }
    }
}