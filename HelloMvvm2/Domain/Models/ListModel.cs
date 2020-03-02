using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class ListModel : ViewModelBase
    {
        private int _value;

        public ListModel()
        {
        }
        public ListModel(int value)
        {
            Value = value;
        }
        public static ListModel Create(int value)
            => new ListModel(value);

        public int Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
