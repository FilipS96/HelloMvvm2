using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomViewChart
{
    public class RandomViewChartViewModel : ViewModelBase, IRandomViewChartViewModel
    {
        private ObservableCollection<RandomChartModel> _randomChartModels;

        public RandomViewChartViewModel()
        {
            
        }



        public ObservableCollection<RandomChartModel> RandomChartModels
        {
            get => _randomChartModels;
            set => SetProperty(ref _randomChartModels, value);
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
