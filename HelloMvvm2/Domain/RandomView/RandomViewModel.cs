using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomView
{
    public class RandomViewModel : ViewModelBase, IRandomViewModel
    {
        private int _rndNumber;

        private RandomModel _myModel;

        private ObservableCollection<RandomModel> _myModels;

        public RandomViewModel()
        {

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





        private void RandomizeNumberExecuted(object model)
        {
            if (RandomizeNumberCanExecute(true))
            {
                MyModel = new RandomModel()
                {
                    RndNumber = new Random()
                };

                RndNumber = MyModel.RndNumber.Next(0, 100);
            }
        }

        private bool RandomizeNumberCanExecute(object model)
        {
            return true;
        }

        public Task Loaded()
        {
            throw new NotImplementedException();
        }

        public Task Unloaded()
        {
            throw new NotImplementedException();
        }
    }
}
