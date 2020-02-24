using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class CarModel : ViewModelBase
    {
        private string _name;

        private CarModel(string name)
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
