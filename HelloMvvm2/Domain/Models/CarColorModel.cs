using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class CarColorModel : ViewModelBase
    {
        private string _color;

        public CarColorModel(string color)
        {
            Color = color;
        }

        public static CarColorModel Create(string color) 
            => new CarColorModel(color);

        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
    }
}