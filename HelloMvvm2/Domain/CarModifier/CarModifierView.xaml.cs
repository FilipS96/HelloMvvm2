using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.CarView;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.CarModifier
{
    /// <summary>
    /// Interaction logic for CarModifierView.xaml
    /// </summary>
    public partial class CarModifierView : UserControl, IUserControl
    {
        public static readonly DependencyProperty CarViewModifierModelProperty =
            DependencyProperty.Register("CarModifierModels", typeof(ObservableCollection<CarModifierModel>), typeof(CarModifierView), new PropertyMetadata(CarModifierModelsPropertyChanged));

        public static readonly DependencyProperty CarViewModelProperty =
           DependencyProperty.Register("CarModels", typeof(ObservableCollection<CarModel>), typeof(CarModifierView), new PropertyMetadata(CarViewModelsPropertyChanged));

        public CarModifierView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public ObservableCollection<CarModifierModel> CarModifierModels
        {
            get => (ObservableCollection<CarModifierModel>)GetValue(CarViewModifierModelProperty);
            set => SetValue(CarViewModifierModelProperty, value);
        }

        public ObservableCollection<CarModel> CarModels
        {
            get => (ObservableCollection<CarModel>)GetValue(CarViewModelProperty);
            set => SetValue(CarViewModelProperty, value);
        }

        private static void CarModifierModelsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var carModifierModels = (ObservableCollection<CarModifierModel>)e.NewValue;
                ((CarModifierViewModel)((CarModifierView)d).DataContext).CarModifierModels = carModifierModels;
                ((CarModifierViewModel)((CarModifierView)d).DataContext).CarModifierModels.CollectionChanged += CarModifierModelsCollectionChanged;
            }
        }

        private static void CarViewModelsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var carModels = (ObservableCollection<CarModel>)e.NewValue;
                ((CarViewModel)((CarModifierView)d).DataContext).CarModels = carModels;
                ((CarViewModel)((CarModifierView)d).DataContext).CarModels.CollectionChanged += CarModelsCollectionChanged;
            }
        }

        private static void CarModifierModelsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
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
            {
                return;
            }
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
            {
                return;
            }
        }
    }
}
