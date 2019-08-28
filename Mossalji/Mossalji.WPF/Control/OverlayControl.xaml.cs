using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for OverlayControl.xaml
    /// </summary>
    public partial class OverlayControl : UserControl
    {
        public OverlayControl(UserControl ChildControl)
        {
            InitializeComponent();

            ControlContainar.Content = ChildControl;

            ((UserControl)ControlContainar.Content).IsEnabledChanged += ChildControl_IsEnabledChanged;
        }

        private void ChildControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.IsEnabled = false;

            ((ContentControl)this.Parent).Content = null;
        }
    }
}
