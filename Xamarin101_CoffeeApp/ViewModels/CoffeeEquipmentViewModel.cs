using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin101_CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            callServerCommand = new AsyncCommand(CallServer);
            Coffee = new ObservableRangeCollection<string>();
            Title = "Coffee Equipment";
        }

        public ObservableRangeCollection<string> Coffee { get; }

        public ICommand callServerCommand { get; }

        async Task CallServer()
        {
            // Demonstraiting MVVM Helpers AsyncCommand
            Coffee.Add("Mocha");
            Coffee.Add("Cappochino");
            Coffee.AddRange(new List<string> { "Americano", "Black" }); // ObservableRangeCollection only
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
            set => SetProperty(ref countDisplay, value);
        }
    }
}
