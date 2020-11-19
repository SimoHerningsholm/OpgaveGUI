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
    /// Interaction logic for UpdateEmployeeFormField.xaml
    /// </summary>
    public partial class UpdateEmployeeFormField : UserControl
    {
        private EmployeeRepository empRep;
        private List<Employee> empList;
        public UpdateEmployeeFormField(EmployeeRepository rep)
        {
            InitializeComponent();
            empRep = rep;
            setEmployeeFieldLabels();
            loadEmployees();
        }
        private async void loadEmployees()
        {
            empList = await empRep.GetEmployees();
            EmployeeViewerGrid.ItemsSource = empList;
        }
        private void EmployeeViewerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void EmployeeCompany_comboFieldChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeDepartment_comboFieldChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeZipCode_comboFieldChanged(object sender, EventArgs e)
        {

        }
        private async void setEmployeeFieldLabels()
        {
            //Content på labels i de forskellige usercontrols sættes med de værdier der gør sig gældende for en createemployee form
            EmployeeFirstName.TextFieldLabel.Content = "Firstname:";
            EmployeeLastName.TextFieldLabel.Content = "Lastname:";
            EmployeeStreet.TextFieldLabel.Content = "Street:";
            EmployeeZipCode.ComboFieldLabel.Content = "Zipcode";
            EmployeeBirthDay.DateFieldLabel.Content = "Birthday:";
            EmployeeEmail.TextFieldLabel.Content = "Email";
            EmployeePhone.TextFieldLabel.Content = "Phone";
            EmployeeDepartment.ComboFieldLabel.Content = "Jobtitle";
            EmployeeCompany.ComboFieldLabel.Content = "Company:";
            EmployeeDepartment.ComboFieldLabel.Content = "Department:";
        }
        private async void UpdateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
