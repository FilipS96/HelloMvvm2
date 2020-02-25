using System;
using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class RandomModel : ViewModelBase
    {
        private Random _rndNumber;

        public RandomModel()
        {

        }


        public Random RndNumber
        {
            get => _rndNumber;
            set => SetProperty(ref _rndNumber, value);
        }
    }
}
