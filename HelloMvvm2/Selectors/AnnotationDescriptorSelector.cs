using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Windows.Controls.ChartView;

namespace HelloMvvm2.Selectors
{
    public class AnnotationsDescriptorSelector : ChartAnnotationDescriptorSelector
    {
        public ChartAnnotationDescriptor MarkedZoneAnnotationDescriptor { get; set; }

        public ChartAnnotationDescriptor RecipePlotAnnotationBandDescriptor { get; set; }

        public ChartAnnotationDescriptor UnbalancedPolarAxisGridLineAnnotationDescriptor { get; set; }

        //public override ChartAnnotationDescriptor SelectDescriptor(ChartAnnotationsProvider provider, object context)
        //{
        //    switch (context)
        //    {
        //        case MeasureZoneAnnotation _:
        //            return this.MarkedZoneAnnotationDescriptor;
        //        case RecipePlotBandAnnotation _:
        //            return this.RecipePlotAnnotationBandDescriptor;
        //        case UnbalancedPolarAxisGridLineAnnotation _:
        //            return this.UnbalancedPolarAxisGridLineAnnotationDescriptor;
        //        default:
        //            return base.SelectDescriptor(provider, context);
        //    }
        //}
    }
}
