using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomViewChart
{
    public class RandomViewChartViewModel : ViewModelBase, IRandomViewChartViewModel
    {
        private ObservableCollection<RandomChartModel> _randomChartModels;

        private Random _rnd;

        private DataPointModel _dpModel;

        private ObservableCollection<DataPointModel> _dpModels;

        [DesignOnly(true)]
        public RandomViewChartViewModel()
        {
            DpModel = new DataPointModel();
            DpModels = new ObservableCollection<DataPointModel>();

            DpModel.DataPoint = Rnd.Next(0, 10);
        }

        public ObservableCollection<RandomChartModel> RandomChartModels
        {
            get => _randomChartModels;
            set => SetProperty(ref _randomChartModels, value);
        }
        
        public Random Rnd
        {
            get => _rnd;
            set => SetProperty(ref _rnd, value);
        }

        public DataPointModel DpModel
        {
            get => _dpModel;
            set => SetProperty(ref _dpModel, value);
        }

        public ObservableCollection<DataPointModel> DpModels
        {
            get => _dpModels;
            set => SetProperty(ref _dpModels, value);
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
