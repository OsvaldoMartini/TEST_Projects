using System.Collections.Generic;
using System.Collections.ObjectModel;
using Binding.StaticResource.AddNew.Model;

namespace Binding.StaticResource.AddNew.ViewModel
{
    public class EmployeeList : ObservableCollection<Employee>
    {
        public List<Inventory> Inventory { get; set; }
        public EmployeeList()
        {
            Inventory = new List<Inventory>();

            for (int i = 1; i < 10; i++)
            {
                Inventory iv = new Inventory();
                iv.Heading = "R" + i;
                iv.Values = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    iv.Values.Add("Pic");
                }
                Inventory.Add(iv);
            }


            this.Add(new Employee
            {
                EmployeeNumber = 1,
                FirstName = "Osvaldo",
                LastName = "Martini",
                Title = "Software Architect",
                Department = "Engineering Operation"
            });
            this.Add(new Employee
            {
                EmployeeNumber = 2,
                FirstName = "Claudia",
                LastName = "Almeida",
                Title = "Account Executive",
                Department = "Engineering Operation"
            });
            this.Add(new Employee
            {
                EmployeeNumber = 3,
                FirstName = "Oscar",
                LastName = "Matias",
                Title = "QA Manager",
                Department = "Web Design"
            });

        }

    }
}
