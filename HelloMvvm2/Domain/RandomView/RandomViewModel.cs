using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomView
{
    public class RandomViewModel : ViewModelBase, IRandomViewModel
    {
        private int _rndNumber;

        private DispatcherTimer _timer;

        private ListModel _selectedListModel;
        private RandomModel _selectedRandomModel;

        private ObservableCollection<ListModel> _myListModels;
        private ObservableCollection<RandomModel> _myRandomModels;

        private RandomModel _rndModel;

        [DesignOnly(true)]
        public RandomViewModel()
        {
            SelectedRandomModel = new RandomModel()
            {   //Rnd one, two & three kan vara en Rnd, Men då behöver man sätta .next i varje AddToList innan man lägger det i listan. Se exempel nedan.
                RndNumber = new Random(),
                RndOne = new int(),
                RndTwo = new int(),
                RndThree = new int(),
                ListOne = new ObservableCollection<int>(),
                ListTwo = new ObservableCollection<int>(),
                ListThree = new ObservableCollection<int>(),
            };
            SelectedListModel = new ListModel();

            RandomizeNumber = new DelegateCommand(RandomizeNumberExecuted, RandomizeNumberCanExecute);
            AddRandomCmd = new DelegateCommand(AddRandomCmdExecuted, AddRandomCmdCanExecute);
            ClearRandomCmd = new DelegateCommand(ClearRandomCmdExecuted, ClearRandomCmdCanExecute);

            FillListsWithData();
        }

        public DelegateCommand RandomizeNumber { get; set; }
        public DelegateCommand AddRandomCmd { get; set; }
        public DelegateCommand ClearRandomCmd { get; set; }

        public int RndNumber
        {
            get => _rndNumber;
            set => SetProperty(ref _rndNumber, value);
        }

        public ListModel SelectedListModel
        {
            get => _selectedListModel;
            set => SetProperty(ref _selectedListModel, value);
        }
        public RandomModel SelectedRandomModel
        {
            get => _selectedRandomModel;
            set => SetProperty(ref _selectedRandomModel, value);
        }
        public RandomModel RndModel
        {
            get => _rndModel;
            set => SetProperty(ref _rndModel, value);
        }

        public ObservableCollection<ListModel> MyListModels
        {
            get => _myListModels;
            set => SetProperty(ref _myListModels, value);
        }
        public ObservableCollection<RandomModel> MyRandomModels
        {
            get => _myRandomModels;
            set => SetProperty(ref _myRandomModels, value);
        }

        private async Task LoadRandomsAndStartTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            _timer.Tick -= LoadRandomNumbers;
            _timer.Tick += LoadRandomNumbers;
            _timer.Start();
        }
        private void LoadRandomNumbers(object sender, EventArgs e)
        {
            SelectedRandomModel.RndOne = SelectedRandomModel.RndNumber.Next(0, 100);
            SelectedRandomModel.RndTwo = SelectedRandomModel.RndNumber.Next(0, 100);

            AddToList();
        }
        public void AddToList()
        {
            SelectedRandomModel.ListOne.Add(SelectedRandomModel.RndOne);
            SelectedRandomModel.ListTwo.Add(SelectedRandomModel.RndTwo);
        }

        //public void Example()
        //{
        //    SelectedRandomModel.Rnd = SelectedRandomModel.RndNumber.Next(0, 100);
        //    SelectedRandomModel.ListOne.Add(SelectedRandomModel.Rnd);

        //    SelectedRandomModel.Rnd = SelectedRandomModel.RndNumber.Next(0, 100);
        //    SelectedRandomModel.ListTwo.Add(SelectedRandomModel.Rnd);
        //}

        private void FillListsWithData()
        {
            MyRandomModels = new ObservableCollection<RandomModel>
            {
                RandomModel.Create("List One",
                    new ObservableCollection<ListModel>
                    {
                        ListModel.Create(100),
                        ListModel.Create(110),
                        ListModel.Create(120),
                        ListModel.Create(130),
                        ListModel.Create(140),
                        ListModel.Create(150),
                        ListModel.Create(160),
                        ListModel.Create(170)
                    }),
                RandomModel.Create("List Two",
                    new ObservableCollection<ListModel>
                    {
                        ListModel.Create(200),
                        ListModel.Create(210),
                        ListModel.Create(220),
                        ListModel.Create(230),
                        ListModel.Create(240),
                        ListModel.Create(250),
                        ListModel.Create(260),
                        ListModel.Create(270)
                    })
            };
        }

        private void RandomizeNumberExecuted(object model)
        {
            if (RandomizeNumberCanExecute(true))
            {
                RndNumber = SelectedRandomModel.RndNumber.Next(0, 100);
            }
        }
        private bool RandomizeNumberCanExecute(object model)
        {
            return true;
        }

        private void AddRandomCmdExecuted(object model)
        {
            if (AddRandomCmdCanExecute(true))
            {
                SelectedRandomModel.RndThree = SelectedRandomModel.RndNumber.Next(0, 100);

                SelectedRandomModel.ListThree.Add(SelectedRandomModel.RndThree);
            }
        }
        private bool AddRandomCmdCanExecute(object model)
        {
            return true;
        }

        private void ClearRandomCmdExecuted(object model)
        {
            if (ClearRandomCmdCanExecute(true))
            {
                SelectedRandomModel.ListThree.Clear();
            }
        }
        private bool ClearRandomCmdCanExecute(object model)
        {
            return true;
        }

        public async Task Loaded()
        {
            await LoadRandomsAndStartTimer();
        }
        public Task Unloaded()
        {
            throw new NotImplementedException();
        }
    }
}