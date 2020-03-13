using HelloMvvm2.Base;

namespace HelloMvvm2.Domain.Models.Charts
{
    public class DataPointModel : ViewModelBase
    {

        public DataPointModel()
        {
        }

        public static DataPointModel Create()
            => new DataPointModel();


    }
}
