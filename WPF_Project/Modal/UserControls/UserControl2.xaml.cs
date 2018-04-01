using System.ComponentModel;
using System.Windows;
using Controls = System.Windows.Controls;

namespace Modal.UserControls {
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>

    public partial class UserControl2 : Controls.UserControl, INotifyPropertyChanged
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        #region OnProperty Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            var args = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged(this, args);
        }
        #endregion

        private string _messageScreenTransfer;

        public string MessageScreenTransfer
        {
            get { return _messageScreenTransfer; }
            set
            {
                _messageScreenTransfer = value;
                OnPropertyChanged("MessageScreenTransfer");
            }
        }


        #region Message

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message", typeof(string), typeof(UserControl2), new UIPropertyMetadata(string.Empty));

        #endregion

        private void OkButton_Click(object sender, RoutedEventArgs args)
        {
            GlobalServices.ModalService.GoBackward(true);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs args)
        {
            GlobalServices.ModalService.GoBackward(false);
        }

        
    }
}