using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WarehouseDocumentApplication.Utils
{
    public class BaseControlClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (field == null && value == null) return false;
            if(typeof(T).GetInterface(nameof(IContainsId)) != null && new ContainsIdClassComparer<IContainsId>().Equals((IContainsId)field, (IContainsId)value)) return false;
            if(EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
