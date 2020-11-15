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
        //Laver en eventhandler der skal modtage comboboks selectionchanged event
        public event EventHandler EmployeeComboFieldChanged;
        public EmployeeComboField()
        {
            InitializeComponent();
            //Hvis selection på comboboksen ændre sig, skal employeeComboFieldSelectionChanged metoden eksekveres.
            this.employeeComboField.SelectionChanged += new SelectionChangedEventHandler(this.employeeComboFieldSelectionChanged);
        }
        protected void employeeComboFieldSelectionChanged(object sender, EventArgs e)
        {
            //Eksekveres denne metode eksekveres eventet såfremt eventet er sat
            EmployeeComboFieldChanged?.Invoke(sender, e);
        }
        private void employeeComboField_GotFocus(object sender, RoutedEventArgs e)
        {
            //Modtager comboboks fokus skal fontweight på label være bold
            employeeComboFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void employeeComboField_LostFocus(object sender, RoutedEventArgs e)
        {
            //Mister comboboks fokus skal fontweight på label være normal
            employeeComboFieldLabel.FontWeight = FontWeights.Normal;
        }
    }
}
