using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class ListModel : ViewModelBase
    {
        private string _value;

        public ListModel(string value)
        {
            Value = value;
        }
        public static ListModel Create(string value)
            => new ListModel(value);

        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
