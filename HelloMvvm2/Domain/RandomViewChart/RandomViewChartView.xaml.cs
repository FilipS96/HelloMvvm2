using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomViewChart
{
    /// <summary>
    /// Interaction logic for RandomViewChartView.xaml
    /// </summary>
    public partial class RandomViewChartView : UserControl, IUserControl
    {
        public static readonly DependencyProperty RandomChartViewModelProperty =
            DependencyProperty.Register("RandomChartModels", typeof(ObservableCollection<RandomChartModel>), typeof(RandomViewChartView),
                new PropertyMetadata(RandomChartModelsPropertyChanged));

        public RandomViewChartView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public ObservableCollection<RandomChartModel> RandomChartModels
        {
            get => (ObservableCollection<RandomChartModel>)GetValue(RandomChartViewModelProperty);
            set => SetValue(RandomChartViewModelProperty, value);
        }

        private static void RandomChartModelsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var randomChartModels = (ObservableCollection<RandomChartModel>)e.NewValue;
                ((RandomViewChartViewModel)((RandomViewChartView)d).DataContext).RandomChartModels = randomChartModels;
                ((RandomViewChartViewModel)((RandomViewChartView)d).DataContext).RandomChartModels.CollectionChanged += RandomChartModelsCollectionChanged;
            }
        }

        private static void RandomChartModelsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
                ((IViewModel)this.DataContext).Loaded();
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
