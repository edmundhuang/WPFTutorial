using System.ComponentModel;

namespace InstantMessage.ViewModel
{
    /// <summary>
    /// 实现 INotifyPropertyChanged 的基本 ViewModel 类
    /// </summary>
    public class BaseViewMode : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性变化事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
