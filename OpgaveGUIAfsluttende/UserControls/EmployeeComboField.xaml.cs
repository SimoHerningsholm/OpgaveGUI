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
    /// Interaction logic for EmployeeComboField.xaml
    /// </summary>
    public partial class EmployeeComboField : UserControl
    {
        public bool selectedChanged;
        public EmployeeComboField()
        {
            InitializeComponent();
            selectedChanged = false;
        }

        private void employeeComboField_GotFocus(object sender, RoutedEventArgs e)
        {
            employeeComboFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void employeeComboField_LostFocus(object sender, RoutedEventArgs e)
        {
            employeeComboFieldLabel.FontWeight = FontWeights.Normal;
        }

        private void EmployeeComboField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedChanged = true;
        }
    }
}
