using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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

        private ObservableCollection<RandomModel> _myModels;
    
        [DesignOnly(true)]
        public RandomViewModel()
        {
            MyModel = new RandomModel()
            { 
                RndNumber = new Random(),
                RndOne = new int(),
                RndTwo = new int(),
                RndThree = new int(),
                ListOne = new ObservableCollection<int>(),
                ListTwo = new ObservableCollection<int>(),
                ListThree = new ObservableCollection<int>()
            };

            RandomizeNumber = new DelegateCommand(RandomizeNumberExecuted, RandomizeNumberCanExecute);
        }

        public DelegateCommand RandomizeNumber { get; set; }

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

        public ObservableCollection<RandomModel> MyModels
        {
            get => _myModels;
            set => SetProperty(ref _myModels, value);
        }

        private async Task LoadRandomsAndStartTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            _timer.Tick -= LoadRandomsTimerExecute;
            _timer.Tick += LoadRandomsTimerExecute;
            _timer.Start();

        }

        private async void LoadRandomsTimerExecute(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                await LoadRandomNumbers();
            }
            catch (Exception)
            {
                // ?
            }
            finally { _timer.Start(); }
        }

        private async Task LoadRandomNumbers()
        {
            MyModel.RndOne = MyModel.RndNumber.Next(0, 100);
            MyModel.RndTwo = MyModel.RndNumber.Next(0, 100);
            MyModel.RndThree = MyModel.RndNumber.Next(0, 100);

            AddToList();
        }

        public void AddToList()
        {
            MyModel.ListOne.Add(MyModel.RndOne);
            MyModel.ListTwo.Add(MyModel.RndTwo);
            MyModel.ListThree.Add(MyModel.RndThree);
        }

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