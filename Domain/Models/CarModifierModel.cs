using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class CarModifierModel : ViewModelBase
    {
        private int _carYear;
        
        private ObservableCollection<CarColorModel> _carColorModels;

        public CarModifierModel(int carYear, ObservableCollection<CarColorModel> carColorModels)
        {
            CarYear = carYear;
            CarColorModels = carColorModels;
        }

        public static CarModifierModel Create(int carYear, ObservableCollection<CarColorModel> carYearModels)
            => new CarModifierModel(carYear, carYearModels);

        public int CarYear
        {
            get => _carYear;
            set => SetProperty(ref _carYear, value);
        }

        public ObservableCollection<CarColorModel> CarColorModels
        {
            get => _carColorModels;
            set => SetProperty(ref _carColorModels, value);
        }


    }
}
