using System;
using System.Collections.ObjectModel;
using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class RandomModel : ViewModelBase
    {
        private ListModel _myListModel;

        private Random _rndNumber;

        private string _listNameString;
        private int _rndOne;
        private int _rndTwo;
        private int _rndThree;

        private ObservableCollection<int> _listOne;
        private ObservableCollection<int> _listTwo;
        private ObservableCollection<int> _listThree;
        private ObservableCollection<ListModel> _myListModels;

        public RandomModel()
        {
        }

        public RandomModel(string listNameString, ObservableCollection<ListModel> myListModels)
        {
            ListNameString = listNameString;
            MyListModels = myListModels;
        }

        public static RandomModel Create(string listNameString, ObservableCollection<ListModel> myListModels)
            => new RandomModel(listNameString, myListModels);

        public ListModel MyListModel
        {
            get => _myListModel;
            set => SetProperty(ref _myListModel, value);
        }

        public Random RndNumber
        {
            get => _rndNumber;
            set => SetProperty(ref _rndNumber, value);
        }

        public string ListNameString
        {
            get => _listNameString;
            set => SetProperty(ref _listNameString, value);
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
        public ObservableCollection<ListModel> MyListModels
        {
            get => _myListModels;
            set => SetProperty(ref _myListModels, value);
        }
    }
}
