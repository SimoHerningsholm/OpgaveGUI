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
        private int EmployeeId;
        private string EmployeeName;
        public DeleteEmployeeFormField()
        {
            InitializeComponent();
            empRep = new EmployeeRepository();
            empList = new List<Employee>();
            EmployeeId = 0;
            loadEmployees();
        }
        public async void loadEmployees()
        {
            EmployeeViewGrid.ItemsSource = null;
            empList.Clear();
            empList = await empRep.GetEmployees();
            EmployeeViewGrid.ItemsSource = empList;
        }
        private async void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await empRep.DeleteEmployee(EmployeeId);
                statusLabel.Content = "Success";
                loadEmployees();
            }
            catch
            {
                statusLabel.Content = "Something went wrong";
            }

        }
        private void EmployeeViewerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EmployeeViewGrid.ItemsSource != null)
            {
                EmployeeId = int.Parse((EmployeeViewGrid.SelectedCells[0].Column.GetCellContent(EmployeeViewGrid.SelectedItem) as TextBlock).Text);
                EmployeeName = (EmployeeViewGrid.SelectedCells[1].Column.GetCellContent(EmployeeViewGrid.SelectedItem) as TextBlock).Text;
                chosenEmployeeId.Content = EmployeeId;
                chosenEmployeeName.Content = EmployeeName;
            }
        }
    }
}
