using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;
using System.Threading.Tasks;
using Xamarin101_CoffeeApp.Models;

namespace Xamarin101_CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }
        public AsyncCommand RefreshCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadCoffees();

            RefreshCommand = new AsyncCommand(Refresh);
        }

        void LoadCoffees()
        {
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable 2", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege Gold", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege Original", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster.Equals("Blue Bottle"))));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster.Equals("Yes Plz"))));
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }
    }
}
