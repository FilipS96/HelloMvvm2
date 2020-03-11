using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models.Charts
{
    public class TestSeriesData : ViewModelBase
    {
        public int Counter { get; set; }

        public int Point { get; set; }
        public int Height { get; set; }

        public TestSeriesData()
        {
        }

        public TestSeriesData(int counter, int point, int height)
        {
            Counter = counter;
            Point = point;
            Height = height;
        }

        public static TestSeriesData Create()
            => new TestSeriesData();

        public static TestSeriesData Create(int counter, int point, int height)
            => new TestSeriesData(counter, point, height);
    }
}
