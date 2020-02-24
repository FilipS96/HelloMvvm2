using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class CarModel : ViewModelBase
    {
        private string _name;

        public CarModel()
        {

        }

        public CarModel(string name)
        {
            Name = name;
        }

        public static CarModel Create(string name)
            => new CarModel(name);

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
