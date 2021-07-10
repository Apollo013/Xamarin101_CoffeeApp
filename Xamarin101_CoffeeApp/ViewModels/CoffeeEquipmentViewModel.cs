using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin101_CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        int count = 0;
        string countDisplay = "Click The Button";

        private void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }

        public ICommand IncreaseCount { get; }

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay)
                {
                    return;
                }

                countDisplay = value;
                OnPropertyChanged(nameof(CountDisplay)); // or just OnPropertyChanged();
            }
        }
    }
}
