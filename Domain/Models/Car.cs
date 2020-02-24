using System.Collections.ObjectModel;
using System.Configuration;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class Car : ViewModelBase
    {
        private string _name;
        private ObservableCollection<CarModel> _models;

        public Car()
        {

        }
        public Car(string name, ObservableCollection<CarModel> models)
        {
            Name = name;
            Models = models;
        }

        public Car(string name)
        {
            Name = name;
        }

        public static Car Create(string name, ObservableCollection<CarModel> models)
            => new Car(name, models);
        
        public static Car Create(string name)
            => new Car(name);

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<CarModel> Models
        {
            get => _models;
            set => SetProperty(ref _models, value);
        }
    }
}
