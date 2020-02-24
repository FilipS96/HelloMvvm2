using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.CarView
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : UserControl, IUserControl
    {
        public static readonly DependencyProperty CarViewModelProperty = 
            DependencyProperty.Register("CarModels", typeof(ObservableCollection<CarModel>), typeof(CarView), new PropertyMetadata(CarViewModelsPropertyChanged));

        public CarView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public ObservableCollection<CarModel> CarModels
        {
            get => (ObservableCollection<CarModel>)GetValue(CarViewModelProperty);
            set => SetValue(CarViewModelProperty, value);
        }

        private static void CarViewModelsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var carModels = (ObservableCollection<CarModel>)e.NewValue;
                ((CarViewModel)((CarView)d).DataContext).CarModels = carModels;
                ((CarViewModel)((CarView)d).DataContext).CarModels.CollectionChanged += CarModelsCollectionChanged;
            }
        }

        private static void CarModelsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ((IViewModel)this.DataContext).Loaded();
            }
            catch (NotImplementedException)
            { }
            catch (Exception)
            { return; }
        }

        public void OnUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ((IViewModel)this.DataContext).Unloaded();
            }
            catch (NotImplementedException)
            { }
            catch (Exception)
            { return; }
        }
    }
}
