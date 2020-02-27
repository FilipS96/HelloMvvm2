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

        private RandomModel _myModel;
        private ListModel _listModel;

        private ObservableCollection<RandomModel> _myModels;
        
        [DesignOnly(true)]
        public RandomViewModel()
        {
            MyModel = new RandomModel()
            {   //Rnd one, two & three kan vara en Rnd, Men då behöver man sätta .next i varje AddToList innan man lägger det i listan. Se exempel nedan.
                RndNumber = new Random(),
                RndOne = new int(),
                RndTwo = new int(),
                RndThree = new int(),
                ListOne = new ObservableCollection<int>(),
                ListTwo = new ObservableCollection<int>(),
                ListThree = new ObservableCollection<int>(),
            };
            ListModel = new ListModel();

            RandomizeNumber = new DelegateCommand(RandomizeNumberExecuted, RandomizeNumberCanExecute);
            AddRandomCmd = new DelegateCommand(AddRandomCmdExecuted, AddRandomCmdCanExecute);
            ClearRandomCmd = new DelegateCommand(ClearRandomCmdExecuted, ClearRandomCmdCanExecute);
        }

        public DelegateCommand RandomizeNumber { get; set; }
        public DelegateCommand AddRandomCmd { get; set; }
        public DelegateCommand ClearRandomCmd { get; set; }

        public int RndNumber
        {
            get => _rndNumber;
            set => SetProperty(ref _rndNumber, value);
        }

        public RandomModel MyModel
        {
            get => _myModel;
            set => SetProperty(ref _myModel, value);
        }

        public ListModel ListModel
        {
            get => _listModel;
            set => SetProperty(ref _listModel, value);
        }
        public ObservableCollection<RandomModel> MyModels
        {
            get => _myModels;
            set => SetProperty(ref _myModels, value);
        }

        private async Task LoadRandomsAndStartTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            _timer.Tick -= LoadRandomNumbers;
            _timer.Tick += LoadRandomNumbers;

            _timer.Tick -= FillListsWithData;
            _timer.Tick += FillListsWithData;
            
            _timer.Start();
        }
        private void LoadRandomNumbers(object sender, EventArgs e)
        {
            MyModel.RndOne = MyModel.RndNumber.Next(0, 100);
            MyModel.RndTwo = MyModel.RndNumber.Next(0, 100);

            AddToList();
        }

        private void FillListsWithData(object sender, EventArgs e)
        {
            RandomModel.Create(new ObservableCollection<ListModel>(ListModel.Create()))
        }
        public void AddToList()
        {
            MyModel.ListOne.Add(MyModel.RndOne);
            MyModel.ListTwo.Add(MyModel.RndTwo);
        }

        //public void Example()
        //{
        //    MyModel.Rnd = MyModel.RndNumber.Next(0, 100);
        //    MyModel.ListOne.Add(MyModel.Rnd);

        //    MyModel.Rnd = MyModel.RndNumber.Next(0, 100);
        //    MyModel.ListTwo.Add(MyModel.Rnd);
        //}

        private void RandomizeNumberExecuted(object model)
        {
            if (RandomizeNumberCanExecute(true))
            {
                RndNumber = MyModel.RndNumber.Next(0, 100);
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
                MyModel.RndThree = MyModel.RndNumber.Next(0, 100);

                MyModel.ListThree.Add(MyModel.RndThree);
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
                MyModel.ListThree.Clear();
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