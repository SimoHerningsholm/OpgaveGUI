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
    /// Interaction logic for CreateEmployeeFormField.xaml
    /// </summary>
    public partial class CreateEmployeeFormField : UserControl
    {
        public CreateEmployeeFormField()
        {
            InitializeComponent();
            setEmployeeFieldLabels();
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
        public void setEmployeeFieldLabels()
        {
            EmployeeName.employeeTextFieldLabel.Content = "Name:";
            EmployeeAddress.employeeTextFieldLabel.Content = "Address:";
            EmployeeZipCode.employeeTextFieldLabel.Content = "Zipcode:";
            EmployeeBirthDay.employeeDateFieldLabel.Content = "Birthday:";
            EmployeeCompany.employeeComboFieldLabel.Content = "Company:";
            EmployeeDepartment.employeeComboFieldLabel.Content = "Department:";
        }
    }
}
