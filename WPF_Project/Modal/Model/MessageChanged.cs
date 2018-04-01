using System;
using System.ComponentModel;

namespace Modal.Model
{
    public class MessagesChanged : INotifyPropertyChanged
    {
        private int _messageId;
        private string _messageInternal;
        private string _messageScreenTransfer;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public MessagesChanged()
        {
            _messageId = 0;
            _messageInternal =
                _messageScreenTransfer =
                    null;
        }

        public int MessageId
        {
            get { return _messageId; }
            set
            {
                _messageId = value;
                OnPropertyChanged("MessageId");
            }
        }

        public string MessageInternal
        {
            get { return _messageInternal; }
            set
            {
                _messageInternal = value;
                OnPropertyChanged("MessageInternal");
            }
        }

        public string MessageScreenTransfer
        {
            get { return _messageScreenTransfer; }
            set
            {
                _messageScreenTransfer = value;
                OnPropertyChanged("MessageScreenTransfer");
            }
        }


        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", MessageInternal, MessageScreenTransfer, MessageId);
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            var args = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged(this, args);
        }

    }
}
