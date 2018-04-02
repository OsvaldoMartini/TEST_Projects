using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Binding.Basics.TwoWays.Interfaces
{
    public delegate void BackNavigationEventHandler(bool dialogReturn);

    public interface IModalService
    {
        void NavigateTo(UserControl uc, BackNavigationEventHandler backFromDialog);
        void GoBackward(bool dialogReturnValue);
    }
}
