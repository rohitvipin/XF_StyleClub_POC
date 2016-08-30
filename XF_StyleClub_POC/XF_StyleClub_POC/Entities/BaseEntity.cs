using System.ComponentModel;
using System.Runtime.CompilerServices;
using XF_StyleClub_POC.Annotations;

namespace XF_StyleClub_POC.Entities
{
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}