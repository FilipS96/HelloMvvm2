using HelloMvvm2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloMvvm2
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {

        [DesignOnly(true)]
        public MainViewModel()
        {

        }

        public Task Loaded()
        {
            throw new NotImplementedException();
        }

        public Task Unloaded()
        {
            throw new NotImplementedException();
        }
    }
}
