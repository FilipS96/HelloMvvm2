using HelloMvvm2.Base;
using HelloMvvm2.Enums;

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
