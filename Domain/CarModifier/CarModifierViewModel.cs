using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.CarView;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.CarModifier
{
    public class CarModifierViewModel : ViewModelBase, ICarModifierViewModel
    {
        private string _previouslySelectedCar;
        private string _previouslySelectedModel;

        private Car _car;
        private CarModel _carModel;
        private CarColorModel _selectedColor;
        private CarModifierModel _selectedYear;
        private CarViewModel _carViewModelClass;

        private ObservableCollection<CarModifierModel> _modifierModels;


    

        [DesignOnly(true)]
        public CarModifierViewModel()
        {
            CarModifierModels = new ObservableCollection<CarModifierModel>
            {
               CarModifierModel.Create(2000, new ObservableCollection<CarColorModel>()
               {
                   CarColorModel.Create("Silver"),
                   CarColorModel.Create("Black")
               }),
               CarModifierModel.Create(2005, new ObservableCollection<CarColorModel>()
               {
                   CarColorModel.Create("Silver"),
                   CarColorModel.Create("Black"),
                   CarColorModel.Create("White")
               }),
               CarModifierModel.Create(2010, new ObservableCollection<CarColorModel>()
               {
                   CarColorModel.Create("Silver"),
                   CarColorModel.Create("Black"),
                   CarColorModel.Create("White"),
                   CarColorModel.Create("Blue")
               }),
               CarModifierModel.Create(2015, new ObservableCollection<CarColorModel>()
               {
                   CarColorModel.Create("Silver"),
                   CarColorModel.Create("Black"),
                   CarColorModel.Create("White"),
                   CarColorModel.Create("Blue"),
                   CarColorModel.Create("Red")
               }),
               CarModifierModel.Create(2020, new ObservableCollection<CarColorModel>()
               {
                   CarColorModel.Create("Silver"),
                   CarColorModel.Create("Black"),
                   CarColorModel.Create("White"),
                   CarColorModel.Create("Blue"),
                   CarColorModel.Create("Red"),
                   CarColorModel.Create("Purple")
               })
            };

        }
        public string PreviouslySelectedCar
        {
            get => _previouslySelectedCar;
            set => SetProperty(ref _previouslySelectedCar, value);
        }

        public string PreviouslySelectedModel
        {
            get => _previouslySelectedModel;
            set => SetProperty(ref _previouslySelectedModel, value);
        }

        public Car CarClass
        {
            get => _car;
            set => SetProperty(ref _car, value);
        }

        public CarModel CarModelClass
        {
            get => _carModel;
            set => SetProperty(ref _carModel, value);
        }

        public CarColorModel SelectedColor
        {
            get => _selectedColor;
            set => SetProperty(ref _selectedColor, value);
        }

        public CarModifierModel SelectedYear
        {
            get => _selectedYear;
            set
            {
                SetProperty(ref _selectedYear, value);
                LoadCarAndModel();
            }
        }

        public CarViewModel CarViewModelClass
        {
            get => _carViewModelClass;
            set => SetProperty(ref _carViewModelClass, value);
        }

        public ObservableCollection<CarModifierModel> CarModifierModels
        {
            get => _modifierModels;
            set => SetProperty(ref _modifierModels, value);
        }
        
        public void LoadCarAndModel()
        {
            CarViewModelClass = new CarViewModel();
            CarViewModelClass.SelectedCar = new Car();
            CarViewModelClass.SelectedCar.Name = new string(CarViewModelClass.SelectedCar.Name);

            PreviouslySelectedCar = CarViewModelClass?.SelectedCar?.Name;
            PreviouslySelectedModel = CarViewModelClass.SelectedModel.Name;

        }

        public Task Loaded()
        {
            throw new NotImplementedException();
        }

        public Task Unloaded()
        {
            throw new NotImplementedException();
        }
    }
}
