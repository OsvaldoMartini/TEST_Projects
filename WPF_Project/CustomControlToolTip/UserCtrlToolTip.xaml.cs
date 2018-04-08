using System.Windows.Controls;

namespace CustomControlToolTip
{
    /// <summary>
    /// Interaction logic for UserControlToolTip.xaml
    /// </summary>
    public partial class UserCtrlToolTip : UserControl
    {
        public UserCtrlToolTip()
        {
            InitializeComponent();
        }
        public double UserControlToolTipX
        {
            get { return this.UserControlToolTipXY.X; }
            set { this.UserControlToolTipXY.X = value; }
        }

        public double UserControlToolTipY
        {
            get { return this.UserControlToolTipXY.Y; }
            set { this.UserControlToolTipXY.Y = value; }
        }

        public string UserControlTextBlockToolTip
        {
            get { return TextBlockToolTip.Text; }
            set { TextBlockToolTip.Text = value; }
        }

        public string UserControlToolTipTitle
        {
            get { return ToolTipTitle.Text; }
            set { ToolTipTitle.Text = value; }
        }
    }
}
