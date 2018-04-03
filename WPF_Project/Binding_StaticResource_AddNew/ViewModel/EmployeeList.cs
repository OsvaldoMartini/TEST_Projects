using System.Collections.Generic;
using System.Collections.ObjectModel;
using Binding.StaticResource.AddNew.Model;

namespace Binding.StaticResource.AddNew
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
        }

    }
}
