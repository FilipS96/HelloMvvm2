using HelloMvvm2.Domain.CarModifier;
using HelloMvvm2.Domain.CarView;


namespace HelloMvvm2.Domain
{
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            CarViewModel = new CarViewModel();
            CarModifierViewModel = new CarModifierViewModel();
        }

        public IMainViewModel MainViewModel { get; set; }

        public ICarViewModel CarViewModel { get; set; }
        
        public ICarModifierViewModel CarModifierViewModel { get; set; }

    }
}
