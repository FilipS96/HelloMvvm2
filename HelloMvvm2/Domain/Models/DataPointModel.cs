using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models
{
    public class DataPointModel : ViewModelBase
    {
        private int _dataPoint;

        public DataPointModel()
        {

        }

        public int DataPoint
        {
            get => _dataPoint;
            set => SetProperty(ref _dataPoint, value);
        }

    }
}
