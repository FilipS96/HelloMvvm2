using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.CarView
{
    public class CarViewModel : ViewModelBase, ICarViewModel
    {
        private string _enteredModel;
        private string _enteredCar;

        private string _mySelectedModel;
        private string _mySelectedCar;

        private Car _selectedCar;
        private CarModel _selectedModel;

        private ObservableCollection<CarModel> _carModels;
        private ObservableCollection<Car> _cars;

        [DesignOnly(true)]
        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                Car.Create("Audi",
                    new ObservableCollection<CarModel>()
                    {
                        CarModel.Create("A1"),
                        CarModel.Create("A2"),
                        CarModel.Create("A3"),
                        CarModel.Create("A4"),
                        CarModel.Create("A5")
                    }),
                Car.Create("Mercedes",
                    new ObservableCollection<CarModel>()
                    {
                        CarModel.Create("A-Class"),
                        CarModel.Create("B-Class"),
                        CarModel.Create("C-Class"),
                        CarModel.Create("E-Class"),
                        CarModel.Create("S-Class")
                    }),
                Car.Create("BMW",
                    new ObservableCollection<CarModel>()
                    {
                        CarModel.Create("1-Serie"),
                        CarModel.Create("2-Serie"),
                        CarModel.Create("3-Serie"),
                        CarModel.Create("4-Serie"),
                        CarModel.Create("5-Serie")
                    }),
                Car.Create("Volkswagen",
                    new ObservableCollection<CarModel>()
                    {
                        CarModel.Create("Golf"),
                        CarModel.Create("Passat"),
                        CarModel.Create("Arteon"),
                        CarModel.Create("T-Cross"),
                        CarModel.Create("Up!")
                    }),
                Car.Create("Volvo",
                    new ObservableCollection<CarModel>()
                    {
                        CarModel.Create("V60"),
                        CarModel.Create("V70"),
                        CarModel.Create("XC60"),
                        CarModel.Create("XC90"),
                        CarModel.Create("S90")
                    }),
            };
            DeleteModelCommand = new DelegateCommand(DeleteModelExecuted, DeleteModelCanExecute);
            DeleteCarCommand = new DelegateCommand(DeleteCarExecuted, DeleteCarCanExecute);

            AddCarCommand = new DelegateCommand(AddCarExecuted, AddCarCanExecute);
            AddModelCommand = new DelegateCommand(AddModelExecuted, AddModelCanExecute);

        }

        public DelegateCommand DeleteModelCommand { get; set; }

        public DelegateCommand DeleteCarCommand { get; set; }

        public DelegateCommand AddCarCommand { get; set; }

        public DelegateCommand AddModelCommand { get; set; }

        public string EnteredModel
        {
            get => _enteredModel;
            set => SetProperty(ref _enteredModel, value);
        }

        public string EnteredCar
        {
            get => _enteredCar;
            set => SetProperty(ref _enteredCar, value);
        }

        public string MySelectedModel
        {
            get => _mySelectedModel;
            set => SetProperty(ref _mySelectedModel, value);
        }

        public string MySelectedCar
        {
            get => _mySelectedCar;
            set => SetProperty(ref _mySelectedCar, value);
        }

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                SetProperty(ref _selectedCar, value);
                MySelectedCar = SelectedCar.Name;
            }
        }

        public CarModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                SetProperty(ref _selectedModel, value);
                MySelectedModel = SelectedModel.Name;
            }
        }

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }

        public ObservableCollection<CarModel> CarModels
        {
            get => _carModels;
            set => SetProperty(ref _carModels, value);
        }

        private void DeleteCarExecuted(object model)
        {
            if (ValidateDeleteCar())
            {
                Cars.Remove(SelectedCar);
            }
        }

        private bool DeleteCarCanExecute(object model)
        {
            return true;
        }

        private bool ValidateDeleteCar()
        {
            if (SelectedCar.Name.Any())
            {
                return true;
            }
            return false;
        }

        private void DeleteModelExecuted(object model)
        {
            if (ValidateDeleteModel())
            {
                SelectedCar.Models.Remove(SelectedModel);
            }
        }

        private bool DeleteModelCanExecute(object model)
        {
            return true;
        }

        private bool ValidateDeleteModel()
        {
            if (SelectedModel.Name.Any())
            {
                return true;
            }
            return false;
        }

        private void AddCarExecuted(object model)
        {
            if (ValidateAddCar())
            {
                Cars.Add(Car.Create(EnteredCar));
            }
        }
         
        private bool AddCarCanExecute(object model)
        {
            return true;
        }

        private bool ValidateAddCar()
        {
            return EnteredCar.Any();
        }

        private void AddModelExecuted(object model)
        {
            if (SelectedCar.Models == null && ValidateAddModel())
            {
                SelectedCar.Models = new ObservableCollection<CarModel>
                {
                    CarModel.Create(EnteredModel)
                };
            }
            else
            {
                if (ValidateAddModel())
                {
                    SelectedCar.Models.Add(CarModel.Create(EnteredModel));
                }
            }
        }

        private bool AddModelCanExecute(object model)
        {
            return true;
        }

        private bool ValidateAddModel()
        {
            if (EnteredModel.Any())
            {
                return true;
            }
            return false;
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
