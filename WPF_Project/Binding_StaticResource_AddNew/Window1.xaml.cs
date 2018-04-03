using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Binding.StaticResource.AddNew.Model;

namespace Binding.StaticResource.AddNew
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public EmployeeList employeeList { get; set; }
        public List<Inventory> Inventory { get; set; }
        public Window1()
        {
            InitializeComponent();

            //SetData();
        }

        private void SetData()
        {
           

          employeeList = new EmployeeList();

            employeeList.Add(new Employee
            {
                EmployeeNumber = 1,
                FirstName = "John",
                LastName = "Dow",
                Title = "Accountant",
                Department = "Payroll"
            });
            employeeList.Add(new Employee
            {
                EmployeeNumber = 2,
                FirstName = "Jane",
                LastName = "Austin",
                Title = "Account Executive",
                Department = "Customer Management"
            });
            employeeList.Add(new Employee
            {
                EmployeeNumber = 3,
                FirstName = "Ralph",
                LastName = "Emmerson",
                Title = "QA Manager",
                Department = "Product Development"
            });
        }

      

    

        private void cmdAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeDetails wNewEmployee = new NewEmployeeDetails();
            bool? employeeEntered = wNewEmployee.ShowDialog();
            if ((employeeEntered.HasValue) && (employeeEntered.Value == true))
            {
                ObservableCollection<Employee> oc = Resources["myEmployeeList"] as ObservableCollection<Employee>;
                oc.Add(wNewEmployee.ReturnValue);
            }
        }
    }
}
