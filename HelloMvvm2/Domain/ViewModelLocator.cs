using HelloMvvm2.Domain.CarModifier;
using HelloMvvm2.Domain.CarView;
using HelloMvvm2.Domain.RandomView;
using HelloMvvm2.Domain.RandomViewChart;


namespace HelloMvvm2.Domain
{
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            CarViewModel = new CarViewModel();
            CarModifierViewModel = new CarModifierViewModel();
            RandomViewModel = new RandomViewModel();
            RandomViewChartViewModel = new RandomViewChartViewModel();
        }

        public IMainViewModel MainViewModel { get; set; }

        public ICarViewModel CarViewModel { get; set; }
        
        public ICarModifierViewModel CarModifierViewModel { get; set; }

        public IRandomViewModel RandomViewModel { get; set; }

        public IRandomViewChartViewModel RandomViewChartViewModel { get; set; }

    }
}
