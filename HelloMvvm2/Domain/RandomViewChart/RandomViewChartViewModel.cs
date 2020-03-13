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
            Rnd = new Random();
            DpModel = new DataPointModel();
            DpModels = new ObservableCollection<DataPointModel>();
            TestSerie = new TestSeries();
            TestSeriesOc = new ObservableCollection<TestSeries>
            {
                TestSeries.Create(SeriesTypeEnum.Line,
                    new ObservableCollection<TestSeriesData>
                    {
                        TestSeriesData.Create(1, 5,   Rnd.Next(0,100)),
                        TestSeriesData.Create(2, 10,  20),
                        TestSeriesData.Create(3, 15,  Rnd.Next(0,100)),
                        TestSeriesData.Create(4, 20,  35),
                        TestSeriesData.Create(5, 25,  Rnd.Next(0,100)),
                        TestSeriesData.Create(6, 30,  Rnd.Next(0,100)),
                        TestSeriesData.Create(7, 35,  65),
                        TestSeriesData.Create(8, 40,  Rnd.Next(0,100)),
                        TestSeriesData.Create(9, 45,  Rnd.Next(0,100)),
                        TestSeriesData.Create(10, 50, Rnd.Next(0,100))
                    }),
            TestSeries.Create(SeriesTypeEnum.Point,
                new ObservableCollection<TestSeriesData>
                {
                    TestSeriesData.Create(4, 20, 35)
                }),
            TestSeries.Create(SeriesTypeEnum.Point,
                new ObservableCollection<TestSeriesData>
                {
                    TestSeriesData.Create(7, 35, 65)
                })
            };


            TestSerieData = new TestSeriesData();
            TestSeriesDataOc = new ObservableItemCollection<TestSeriesData>();

            ButtonCommand = new DelegateCommand(ButtonExecuted);
        }


        public DelegateCommand ButtonCommand { get; set; }


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

        private void ButtonExecuted(object obj)
        {
            TestSeriesOc.Add(
                TestSeries.Create(SeriesTypeEnum.Point,
                    new ObservableCollection<TestSeriesData>
                    {
                        TestSeriesData.Create(2, 10, 20) //Denna ska lägga till värdet som är angivet i textbox. 
                    }));
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
