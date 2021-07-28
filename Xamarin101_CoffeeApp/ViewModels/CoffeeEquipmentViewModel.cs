using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin101_CoffeeApp.Models;
using Command = MvvmHelpers.Commands.Command;

namespace Xamarin101_CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavouriteCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadCoffees();

            RefreshCommand = new AsyncCommand(Refresh);
            FavouriteCommand = new AsyncCommand<Coffee>(Favourite);

            LoadMoreCommand = new Command(LoadCoffees);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            ClearCommand = new Command(Clear);
        }

        void LoadCoffees()
        {
            if (Coffee.Count >= 20)
            {
                return;
            }


            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable 2", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege Gold", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege Original", Image = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster.Equals("Blue Bottle"))));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster.Equals("Yes Plz"))));
        }

        Coffee previousCoffee;
        Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected Coffee", value.Name, "Ok");
                    previousCoffee = value;
                    value = null;
                }

                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();
            LoadCoffees();

            IsBusy = false;
        }

        async Task Favourite(Coffee coffee)
        {
            if (coffee == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Fovourite Coffee", coffee.Name, "Ok");
            previousCoffee = coffee;
        }

        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
            {
                return;
            }

            LoadCoffees();
        }

        void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }
    }
}
