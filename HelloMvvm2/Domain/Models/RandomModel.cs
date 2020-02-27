using System;
using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class RandomModel : ViewModelBase
    {
        private Random _rndNumber;

        private int _rndOne;
        private int _rndTwo;
        private int _rndThree;

        private ObservableCollection<int> _listOne;
        private ObservableCollection<int> _listTwo;
        private ObservableCollection<int> _listThree;

        private ObservableCollection<ListModel> _stringListOne;
        private ObservableCollection<ListModel> _stringListTwo;

        public RandomModel(ObservableCollection<ListModel> models)
        {
            StringListOne = models;
        }

        public static RandomModel Create(ObservableCollection<ListModel> models)
            => new RandomModel(models);
        public Random RndNumber
        {
            get => _rndNumber;
            set => SetProperty(ref _rndNumber, value);
        }

        public int RndOne
        {
            get => _rndOne;
            set => SetProperty(ref _rndOne, value);
        }
        public int RndTwo
        {
            get => _rndTwo;
            set => SetProperty(ref _rndTwo, value);
        }
        public int RndThree
        {
            get => _rndThree;
            set => SetProperty(ref _rndThree, value);
        }

        public ObservableCollection<int> ListOne
        {
            get => _listOne;
            set => SetProperty(ref _listOne, value);
        }
        public ObservableCollection<int> ListTwo
        {
            get => _listTwo;
            set => SetProperty(ref _listTwo, value);
        }
        public ObservableCollection<int> ListThree
        {
            get => _listThree;
            set => SetProperty(ref _listThree, value);
        }

        public ObservableCollection<ListModel> StringListOne
        {
            get => _stringListOne;
            set => SetProperty(ref _stringListOne, value);
        }
        public ObservableCollection<ListModel> StringListTwo
        {
            get => _stringListTwo;
            set => SetProperty(ref _stringListTwo, value);
        }
    }
}
