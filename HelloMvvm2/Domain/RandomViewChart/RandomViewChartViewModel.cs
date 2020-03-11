using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models.Charts;
using HelloMvvm2.Enums;
using Telerik.Windows.Data;

namespace HelloMvvm2.Domain.RandomViewChart
{
    public class RandomViewChartViewModel : ViewModelBase, IRandomViewChartViewModel
    {
        private Random _rnd;
        private DataPointModel _dpModel;
        private ObservableCollection<DataPointModel> _dpModels;
        //private ObservableCollection<RandomChartModel> _randomChartModels;

        private TestSeries _testSerie;
        private ObservableCollection<TestSeries> _testSeriesOc;

        private TestSeriesData _testSerieData;
        private ObservableCollection<TestSeriesData> _testSeriesDataOc;

        [DesignOnly(true)]
        public RandomViewChartViewModel()
        {
            DpModel = new DataPointModel();
            DpModels = new ObservableCollection<DataPointModel>();
            TestSerie = new TestSeries();
            TestSeriesOc = new ObservableCollection<TestSeries>
            {
                TestSeries.Create(SeriesTypeEnum.Line,
                    new ObservableCollection<TestSeriesData>
                    {
                        TestSeriesData.Create(1, 5, 0),
                        TestSeriesData.Create(2, 10, 100),
                        TestSeriesData.Create(3, 15, 100),
                        TestSeriesData.Create(4, 20, 100),
                        TestSeriesData.Create(5, 25, 100),
                        TestSeriesData.Create(6, 30, 100),
                        TestSeriesData.Create(7, 35, 100),
                        TestSeriesData.Create(8, 40, 100),
                        TestSeriesData.Create(9, 45, 100),
                        TestSeriesData.Create(10, 50,100)
                    })
            };
            TestSerieData = new TestSeriesData();
            TestSeriesDataOc = new ObservableItemCollection<TestSeriesData>();

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

        //public ObservableCollection<RandomChartModel> RandomChartModels
        //{
        //    get => _randomChartModels;
        //    set => SetProperty(ref _randomChartModels, value);
        //}

        public TestSeries TestSerie
        {
            get => _testSerie;
            set => SetProperty(ref _testSerie, value);
        }
        public ObservableCollection<TestSeries> TestSeriesOc
        {
            get => _testSeriesOc;
            set => SetProperty(ref _testSeriesOc, value);
        }

        public TestSeriesData TestSerieData
        {
            get => _testSerieData;
            set => SetProperty(ref _testSerieData, value);
        }
        public ObservableCollection<TestSeriesData> TestSeriesDataOc
        {
            get => _testSeriesDataOc;
            set => SetProperty(ref _testSeriesDataOc, value);
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
