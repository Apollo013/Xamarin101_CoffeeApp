using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin101_CoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {


        public CoffeeEquipmentPage()
        {
            InitializeComponent();
            
            //BindingContext = this;
            //ButtonClick.Clicked += ButtonClick_Clicked;
        }

        

        /*
        private void ButtonClick_Clicked(object sender, EventArgs e)
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
        */
    }
}