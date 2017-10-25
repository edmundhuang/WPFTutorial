using System.ComponentModel;

namespace WPFTreeView
{
 
    public class DirectoryViewModel: BaseViewModel
    {

    }

    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged= (sender,e) => {};
    }
}
