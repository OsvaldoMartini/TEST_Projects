using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding.Basics.TwoWays.Concrete
{
    public class Person : INotifyPropertyChanged
    {
        private string fullname;
        public string FullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
                OnPropertChanged("FullName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
