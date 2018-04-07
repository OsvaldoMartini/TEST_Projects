using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
    using Binding.StaticResource.AddNew.Model;
using Binding.StaticResource.AddNew.ViewModel;

namespace Binding.StaticResource.AddNew 
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public EmployeeList EmployeeListProperty { get; set; }
        
        private ObservableCollection<Person> _person;


        public Window1()
        {
            InitializeComponent();


            Loaded += OnLoaded;
            SetPersonCollection();

        }

        private void SetPersonCollection()
        {
            _person = new ObservableCollection<Person>()
            {
                new Person(){Name="Prabhat",Address="India"},
                new Person(){Name="Smith",Address="US"}
            };
            lstNames.ItemsSource = _person;
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


        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            SizeToContent = SizeToContent.Manual;

            var messages = new ObservableCollection<string>
            {
                "This is a long string to demonstrate that the list" + 
                " box content is determining window width"
            };

            for (int i = 0; i < 16; i++)
            {
                messages.Add("Test" + i);
            }

            for (int i = 0; i < 4; i++)
            {
                messages.Add("this text should be visible by vertical scrollbars only");
            }

            ListBox1.ItemsSource = messages;
        }


        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            _person.Add(new Person() { Name = txtName.Text, Address = txtAddress.Text });
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }


    }

}
