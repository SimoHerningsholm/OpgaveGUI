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
using CLBL;
using CLModels;

namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for DeleteEmployeeFormField.xaml
    /// </summary>
    public partial class DeleteEmployeeFormField : UserControl
    {
        private EmployeeRepository empRep;
        private List<Employee> empList;
        public DeleteEmployeeFormField(EmployeeRepository rep)
        {
            InitializeComponent();
            empRep = new EmployeeRepository();
            empList = new List<Employee>();
            empRep = rep;
        }
        public void loadEmployees()
        {
            EmployeeViewerGrid.ItemsSource = empList;
        }
        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeeViewerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
