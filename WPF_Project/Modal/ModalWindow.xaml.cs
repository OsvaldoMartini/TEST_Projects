using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Modal.Concrete;
using Modal.Interfaces;
using Modal.UserControls;
using Modal.ViewModel;

namespace Modal {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class ModalWindow : Window, IModalService
    {
        //If you get this example you'll get 90% of MVVM.
        public IntermediateMessages MessagesModel { get; set; }

        public ModalWindow() {
            InitializeComponent();
            SetDataContext();
        }

        public void SetDataContext()
        {
            //If you get this example you'll get 90% of MVVM.
            IntermediateMessages messages = new IntermediateMessages();
            
            messages.MessageInternal = "Internal Message";
            messages.MessageScreenTransfer = "Screen Transfer";
            messages.MessageId = 1;

            UserViewModel user = new UserViewModel();
            user.UserName = "User";
            user.IsModified = false;

            messages.UserViewModel = user;
            
            this.DataContext = messages;
        }

        private void ModalClick(object sender, RoutedEventArgs args) {
            GlobalServices.ModalService.NavigateTo(new UserControl1(MessagesModel), delegate(bool returnValue) {
                if (returnValue)
                    MessageBox.Show("Return value == true");
                else
                    MessageBox.Show("Return value == false");
            });
        }

        #region IMainWindow Members

        private Stack<BackNavigationEventHandler> _backFunctions
            = new Stack<BackNavigationEventHandler>();

        void IModalService.NavigateTo(UserControl uc, BackNavigationEventHandler backFromDialog) {
            foreach (UIElement item in modalGrid.Children)
                item.IsEnabled = false;
            modalGrid.Children.Add(uc);

            _backFunctions.Push(backFromDialog);
        }

        void IModalService.GoBackward(bool dialogReturnValue) {
            modalGrid.Children.RemoveAt(modalGrid.Children.Count - 1);

            UIElement element = modalGrid.Children[modalGrid.Children.Count - 1];
            element.IsEnabled = true;

            BackNavigationEventHandler handler = _backFunctions.Pop();
            if (handler != null)
                handler(dialogReturnValue); 
        }

        #endregion
    }
    
}