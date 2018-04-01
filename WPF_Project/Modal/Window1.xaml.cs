using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Modal.Interfaces;
using Modal.UserControls;

namespace Modal {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window, IModalService {

        public Window1() {
            InitializeComponent();
        }

        private void ModalClick(object sender, RoutedEventArgs args) {
            GlobalServices.ModalService.NavigateTo(new UserControl1(), delegate(bool returnValue) {
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

    public class GlobalServices {
        public static IModalService ModalService {
            get { return (IModalService) Application.Current.MainWindow; } 
        }
    }
}