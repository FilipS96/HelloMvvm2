using System.Collections.ObjectModel;
using HelloMvvm2.Enums;

namespace HelloMvvm2.Domain.Models.Charts
{
    public class TestSeries
    {
        public SeriesTypeEnum SeriesType { get; }

        public ObservableCollection<TestSeriesData> Data { get; }

        public TestSeries()
        {
        }

        public TestSeries(SeriesTypeEnum seriesType, ObservableCollection<TestSeriesData> data)
        {
            SeriesType = seriesType;
            Data = data;
        }

        public static TestSeries Create(SeriesTypeEnum seriesType, ObservableCollection<TestSeriesData> data)
            => new TestSeries(seriesType, data);
    }
}
