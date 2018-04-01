using System.Windows;

namespace Modal.UserControls {
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class UserControl1 : System.Windows.Controls.UserControl {
        public UserControl1() {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs args) {
            GlobalServices.ModalService.GoBackward(true);
        }
        private void CancelClick(object sender, RoutedEventArgs args) {
            GlobalServices.ModalService.GoBackward(false);
        }
        private void Screen2_Click(object sender, RoutedEventArgs args)
        {
            var objUControl2 = new UserControl2 {Message = txtSender.Text};

            GlobalServices.ModalService.NavigateTo(objUControl2, delegate(bool returnValue)
            {
                if (returnValue)
                    MessageBox.Show("Return value == true");
                else
                    MessageBox.Show("Return value == false");            
            });
        }
    }
}