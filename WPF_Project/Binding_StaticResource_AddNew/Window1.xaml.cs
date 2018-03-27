using System.Collections.ObjectModel;
using System.Windows;

namespace Binding.StaticResource.AddNew
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
        }

        private void cmdAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeDetails ned = new NewEmployeeDetails();
            bool? employeeEntered = ned.ShowDialog();
            if ((employeeEntered.HasValue) && (employeeEntered.Value == true))
            {
                ObservableCollection<Employee> oc = Resources["myEmployeeList"] as ObservableCollection<Employee>;
                oc.Add(ned.ReturnValue);
            }
        }
    }
}
