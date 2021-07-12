using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace DemoInterface1.Core
{
    class observableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
