using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class CarModifierModel : ViewModelBase
    {
        private int _carYear;
        
        private ObservableCollection<CarColorModel> _carColorModels;

        public CarColorModel CarColor { get; set; }

        public Car Car { get; set; }

        public CarModel CarModel { get; set; }

        public CarModifierModel(int carYear, ObservableCollection<CarColorModel> carColorModels)
        {
            CarYear = carYear;
            CarColorModels = carColorModels;
        }

        public static CarModifierModel Create(int carYear, ObservableCollection<CarColorModel> carColorModels)
           => new CarModifierModel(carYear, carColorModels);

        public CarModifierModel(int carYear, CarColorModel carColor, Car car, CarModel carModel)
        {
            CarYear = carYear;
            CarColor = carColor;
            Car = car;
            CarModel = carModel;
        }

        public static CarModifierModel Create(int carYear, CarColorModel carColorModels, Car car, CarModel carModel)
            => new CarModifierModel(carYear, carColorModels, car, carModel);

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