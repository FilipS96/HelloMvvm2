using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models.Charts;

namespace HelloMvvm2.Domain.RandomViewChart
{
    /// <summary>
    /// Interaction logic for RandomViewChartView.xaml
    /// </summary>
    public partial class RandomViewChartView : UserControl, IUserControl
    {
        public static readonly DependencyProperty TestSeriesProperty =
            DependencyProperty.Register("TestSeries", typeof(ObservableCollection<TestSeries>), typeof(RandomViewChartView),
                new PropertyMetadata(TestSeriesPropertyChanged));

        public RandomViewChartView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public ObservableCollection<TestSeries> TestSeries
        {
            get => (ObservableCollection<TestSeries>)GetValue(TestSeriesProperty);
            set => SetValue(TestSeriesProperty, value);
        }

        private static void TestSeriesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var testSeriesOc = (ObservableCollection<TestSeries>)e.NewValue;
                ((RandomViewChartViewModel)((RandomViewChartView)d).DataContext).TestSeriesOc = testSeriesOc;
                ((RandomViewChartViewModel)((RandomViewChartView)d).DataContext).TestSeriesOc.CollectionChanged += RandomChartModelsCollectionChanged;
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
