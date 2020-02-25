using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using HelloMvvm2.Base;
using HelloMvvm2.Domain.Models;

namespace HelloMvvm2.Domain.RandomView
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class RandomView : UserControl, IUserControl
    {
        public static readonly DependencyProperty RandomViewModelProperty =
            DependencyProperty.Register("RandomModels", typeof(ObservableCollection<RandomModel>), typeof(RandomView),
                new PropertyMetadata(RandomModelsPropertyChanged));
        public RandomView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public ObservableCollection<RandomModel> RandomModels
        {
            get => (ObservableCollection<RandomModel>) GetValue(RandomViewModelProperty);
            set => SetValue(RandomViewModelProperty, value);
        }

        private static void RandomModelsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var randomModels = (ObservableCollection<RandomModel>) e.NewValue;
                ((RandomViewModel)((RandomView) d).DataContext).MyModels = randomModels;
                ((RandomViewModel) ((RandomView) d).DataContext).MyModels.CollectionChanged += RandomModelsCollectionChanged;
            }
        }

        private static void RandomModelsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
