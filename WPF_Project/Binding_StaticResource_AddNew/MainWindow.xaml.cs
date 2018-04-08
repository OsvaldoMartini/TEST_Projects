using System.Collections.ObjectModel;
using System.Windows;
    using Binding.StaticResource.AddNew.Model;
using Binding.StaticResource.AddNew.ViewModel;
using System.Text;
using Binding.StaticResource.AddNew.Utils;


namespace Binding.StaticResource.AddNew 
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public EmployeeList EmployeeListProperty { get; set; }
        
        private ObservableCollection<Person> _person;

        ObservableCollection<string> mineObservableCollection;
        StringBuilder mineLog = new StringBuilder();


        public Window1()
        {
            InitializeComponent();


            Loaded += OnLoaded;
            SetPersonCollection();

            SettingObservableEvents();

        }

        private void SettingObservableEvents()
        {
            mineLog.AppendLine("-- ObservableCollection --");
            InitOC();
            mineObservableCollection.CollectionChanged += mOC_CollectionChanged;
            TestOC();

            mineLog.AppendLine("-- ObservedCollection --");
            InitOC();
            var xObserved = new ObservedCollection<string>(mineObservableCollection);
            xObserved.OnCleared += xObserved_OnCleared;
            xObserved.OnItemAdded += xObserved_OnItemAdded;
            xObserved.OnItemMoved += xObserved_OnItemMoved;
            xObserved.OnItemRemoved += xObserved_OnItemRemoved;
            xObserved.OnItemReplaced += xObserved_OnItemReplaced;
            TestOC();
        }

        private void SetPersonCollection()
        {
            _person = new ObservableCollection<Person>()
            {
                new Person(){Name="Osvaldo",Address="Greater London"},
                new Person(){Name="Alexandre",Address="US"}
            };
            lstNames.ItemsSource = _person;
        }

        private void cmdAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeDetails newEmployee = new NewEmployeeDetails();
            bool? employeeEntered = newEmployee.ShowDialog();
            if ((employeeEntered.HasValue) && (employeeEntered.Value == true))
            {
                ObservableCollection<Employee> oc = Resources["DirectContentEmployeeList"] as ObservableCollection<Employee>;
                oc.Add(newEmployee.ReturnValue);
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


        #region Events ObservableColletcion
        void xObserved_OnItemReplaced(ObservableCollection<string> aSender, int aIndex, string aOldItem, string aNewItem)
        {
            mineLog.AppendLine("  Replaced @ " + aIndex);
            mineLog.AppendLine("  Old: " + aOldItem);
            mineLog.AppendLine("  New: " + aNewItem);
            mineLog.AppendLine();
        }
        void xObserved_OnItemRemoved(ObservableCollection<string> aSender, int aIndex, string aItem)
        {
            mineLog.AppendLine("  Removed @ " + aIndex);
            mineLog.AppendLine("  " + aItem);
            mineLog.AppendLine();
        }
        void xObserved_OnItemMoved(ObservableCollection<string> aSender, int aOldIndex, int aNewIndex, string aItem)
        {
            mineLog.AppendLine("  Moved from " + aOldIndex + " to " + aNewIndex);
            mineLog.AppendLine("  " + aItem);
            mineLog.AppendLine();
        }
        void xObserved_OnItemAdded(ObservableCollection<string> aSender, int aIndex, string aItem)
        {
            mineLog.AppendLine("  Added @ " + aIndex);
            mineLog.AppendLine("  " + aItem);
            mineLog.AppendLine();
        }
        void xObserved_OnCleared(ObservableCollection<string> aSender)
        {
            mineLog.AppendLine("  Cleared");
            mineLog.AppendLine();
        }

        void InitOC()
        {
            mineObservableCollection = new ObservableCollection<string>();
            mineObservableCollection.Add("One");
            mineObservableCollection.Add("Two");
            mineObservableCollection.Add("Three");
            mineObservableCollection.Add("Four");
            mineObservableCollection.Add("Five");
        }

        void TestOC()
        {
            mineLog.AppendLine("mOC[2] = \"3\";");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection[2] = "3";

            mineLog.AppendLine("mineObservableCollection.Add(\"Six\");");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection.Add("Six");

            mineLog.AppendLine("mineObservableCollection.RemoveAt(2);");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection.RemoveAt(2);

            mineLog.AppendLine("mineObservableCollection.Insert(2, \"Three\");");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection.Insert(2, "Three");

            mineLog.AppendLine("mineObservableCollection.Move(0, 1);");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection.Move(0, 1);

            mineLog.AppendLine("mineObservableCollection.Clear();");
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);
            mineObservableCollection.Clear();

            tboxLog.Text = mineLog.ToString();
        }

        void LogItems(System.Collections.IList aItems)
        {
            if (aItems == null)
            {
                mineLog.AppendLine("    (null)");
            }
            else
            {
                foreach (var x in aItems)
                {
                    mineLog.AppendLine("    " + x);
                }
            }
        }

        void mOC_CollectionChanged(object aSender, System.Collections.Specialized.NotifyCollectionChangedEventArgs aArgs)
        {
            mineLog.AppendLine("  " + aArgs.Action);
            mineLog.AppendLine("  " + aSender.GetType());
            mineLog.AppendLine("  Count: " + mineObservableCollection.Count);

            mineLog.AppendLine("  Old");
            mineLog.AppendLine("    Index: " + aArgs.OldStartingIndex);
            LogItems(aArgs.OldItems);

            mineLog.AppendLine("  New");
            mineLog.AppendLine("    Index: " + aArgs.NewStartingIndex);
            LogItems(aArgs.NewItems);

            mineLog.AppendLine();
        }
        #endregion


    }

}
