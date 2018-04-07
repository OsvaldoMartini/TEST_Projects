using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Binding.StaticResource.AddNew.Abstract;
using Binding.StaticResource.AddNew.Model;

namespace Binding.StaticResource.AddNew.ViewModel
{
    public class EmployeeList : ViewModelBase
    {
        private Employee _selectedEmployeeObject;
        public Employee SelectedEmployeeObject
        {
            get { return _selectedEmployeeObject; }
            set
            {
                if (value != this._selectedEmployeeObject)
                    _selectedEmployeeObject = value;
                this.SetPropertyChanged("SelectedEmployeeObject");
            }
        }

        private ObservableCollection<Employee> _employeeObjectCollection;
        public ObservableCollection<Employee> EmployeeObjectCollection
        {
            get { return _employeeObjectCollection; }
            set
            {
                if (value != this._employeeObjectCollection)
                    _employeeObjectCollection = value;
                this.SetPropertyChanged("EmployeeObjectCollection");
            }
        }

        private ObservableCollection<Inventory> _inventoryObjectCollection;
        public ObservableCollection<Inventory> InventoryObjectCollection
        {
            get { return _inventoryObjectCollection; }
            set
            {
                if (value != this._inventoryObjectCollection)
                    _inventoryObjectCollection = value;
                this.SetPropertyChanged("InventoryObjectCollection");
            }
        }
        public EmployeeList()
        {

            SetFiles();
        }

        private void SetFiles()
        {
            this._employeeObjectCollection = new ObservableCollection<Employee>();
            this._employeeObjectCollection.Add(new Employee
            {
                EmployeeNumber = 1,
                FirstName = "Osvaldo",
                LastName = "Martini",
                Title = "Software Architect",
                Department = "Engineering Operation"
            });
            this._employeeObjectCollection.Add(new Employee
            {
                EmployeeNumber = 2,
                FirstName = "Claudia",
                LastName = "Almeida",
                Title = "Account Executive",
                Department = "Engineering Operation"
            });
            this._employeeObjectCollection.Add(new Employee
            {
                EmployeeNumber = 3,
                FirstName = "Oscar",
                LastName = "Matias",
                Title = "QA Manager",
                Department = "Web Design"
            });

        }

        //private Action<Employee> SetFileObjectCollection()
        //{
        //    this._fileObjectCollection = new ObservableCollection<FileObject>();
        //    return f => this._fileObjectCollection.Add(new FileObject { FileName = f.Name, Location = f.DirectoryName });
        //}


    }
}
