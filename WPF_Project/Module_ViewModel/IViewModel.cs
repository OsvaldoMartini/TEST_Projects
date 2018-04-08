using System.ComponentModel;

namespace ViewModel
{
    public interface IViewModel: INotifyPropertyChanged
    {
        bool IsModified { get; set; }

        bool IsLoading { get; set; }
    }
}
