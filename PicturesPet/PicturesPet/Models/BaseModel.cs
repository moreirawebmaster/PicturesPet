using System.ComponentModel;
using PropertyChanged;

namespace PicturesPet.Models
{
    [AddINotifyPropertyChangedInterface]
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
