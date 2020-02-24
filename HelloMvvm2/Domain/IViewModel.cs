using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloMvvm2.Domain
{
    public interface IViewModel
    {
        Task Loaded();

        Task Unloaded();
    }
}
