using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Binding.Basics.TwoWays
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //Instead of "Window" we need to use INotifyPropertyChanged
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            //Set DataContext
            DataContext = this;
            InitializeComponent();
        }

        //To Keep two UI Elements Syncronized with some Global Variable
        private int _boundNumber;

        public int BounderNumber
        {
            get { return _boundNumber;}
            set
            {
                if (_boundNumber != value)
                {
                    _boundNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        //<TextBox Grid.Row="0" Text="{Binding Path=BoundNumber, Mode=TwoWay}"></TextBox>
        //<TextBox Grid.Row="0" Text="{Binding Path=BoundNumber, Mode=TwoWay,NotifyOnSourceUpdated=true}"></TextBox>


        //Handler Property Changed All elements Know
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //This Requires C# 6.0 Support Enabled / Capability 
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string OldStylePropertyChanged
        {
            get { return _boundNumber; }
            set
            {
                if (value != _boundNumber)
                {
                    _boundNumber = value;
                    OnPropertyChangedOldStyle("OldStylePropertyChanged");
                }
            }
        }
        private void OnPropertyChangedOldStyle(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
