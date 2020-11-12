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

namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeDateField.xaml
    /// </summary>
    public partial class EmployeeDateField : UserControl
    {
        public EmployeeDateField()
        {
            InitializeComponent();
        }

        private void employeeDateField_GotFocus(object sender, RoutedEventArgs e)
        {
            employeeDateFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void employeeDateField_LostFocus(object sender, RoutedEventArgs e)
        {
            employeeDateFieldLabel.FontWeight = FontWeights.Normal;
        }
    }
}
