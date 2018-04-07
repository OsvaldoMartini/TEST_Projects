using System.Windows;
using Binding.StaticResource.AddNew.ViewModel;

namespace Binding.StaticResource.AddNew
{
    /// <summary>
    /// Interaction logic for NewEmployeeDetails.xaml
    /// </summary>
    public partial class NewEmployeeDetails : Window
    {
        public Employee ReturnValue = null;
        public NewEmployeeDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue = Resources["NewEmployee"] as Employee;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReturnValue = null;
        }
    }
}
