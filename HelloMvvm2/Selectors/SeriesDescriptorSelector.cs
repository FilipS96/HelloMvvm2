using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Windows.Controls.ChartView;

namespace HelloMvvm2.Selectors
{
    public class SeriesDescriptorSelector : ChartSeriesDescriptorSelector
    {
        public ChartSeriesDescriptor CategoricalSeriesDescriptor { get; set; }

        public ChartSeriesDescriptor PointSeriesDescriptor { get; set; }

        //public override ChartSeriesDescriptor SelectDescriptor(ChartSeriesProvider provider, object context)
        //{
        //    var seriesModel = (TestRunSeries)context;

        //    switch (seriesModel.SeriesType)
        //    {
        //        case SeriesTypeEnum.Line:
        //            return CategoricalSeriesDescriptor;
        //        case SeriesTypeEnum.Point:
        //            return PointSeriesDescriptor;
        //        default:
        //            return CategoricalSeriesDescriptor;
        //    }
        //}
    }
}
