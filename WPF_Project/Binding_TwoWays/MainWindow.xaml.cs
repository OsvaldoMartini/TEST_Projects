using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            //Sete DataContext
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

    }
}
