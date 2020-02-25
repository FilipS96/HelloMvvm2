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

        private Car _c;
        private CarModel _cm;
        private CarViewModel _cvm;
        private ObservableCollection<CarModifierModel> _cmms;

        private CarColorModel _selectedColor;
        private CarModifierModel _selectedYear;

        [DesignOnly(true)]
        public CarModifierViewModel()
        {
            Cmms = new ObservableCollection<CarModifierModel>
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

            AddCompleteCarCommand = new DelegateCommand(AddCompleteCarExecuted, AddCompleteCarCanExecute);


            Cvm = new CarViewModel
            {
                SelectedCar = new Car(),
                SelectedModel = new CarModel()
            };
            Cvm.MySelectedCar = new string(Cvm.SelectedCar.Name);
            Cvm.MySelectedModel = new string(Cvm.SelectedModel.Name);
        }

        public DelegateCommand AddCompleteCarCommand { get; set; }

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

        public CarViewModel Cvm
        {
            get => _cvm;
            set => SetProperty(ref _cvm, value);
        }

        public ObservableCollection<CarModifierModel> Cmms
        {
            get => _cmms;
            set => SetProperty(ref _cmms, value);
        }

        public void LoadCarAndModel()
        {
            //var car = new Car
            //{
            //    Name = new string(Cvm.MySelectedCar)
            //};
            //var carModel = new CarModel
            //{
            //    Name = new string(Cvm.MySelectedModel)
            //};

            //Cvm.MySelectedCar = new string(Cvm.SelectedCar.Name);
            //Cvm.MySelectedModel = new string(Cvm.SelectedModel.Name);

            PreviouslySelectedCar = Cvm.SelectedCar.Name;
            PreviouslySelectedModel = Cvm.SelectedModel.Name;
        }

        private void AddCompleteCarExecuted(object model)
        {
            if (AddCompleteCarCanExecute(true))
            {
                CarModifierModel.Create(SelectedYear.CarYear, SelectedColor, Cvm.SelectedCar, Cvm.SelectedModel); //CarClass & CarModelClass ska ta in det valda objektet från tillverkare och model.
            }
        }

        private bool AddCompleteCarCanExecute(object model)
        {
            return true;
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