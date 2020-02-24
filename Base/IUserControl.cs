using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMvvm2.Base
{
    public interface IUserControl
    {
        void OnLoaded(object sender, System.Windows.RoutedEventArgs e);

        void OnUnloaded(object sender, System.Windows.RoutedEventArgs e);
    }
}
