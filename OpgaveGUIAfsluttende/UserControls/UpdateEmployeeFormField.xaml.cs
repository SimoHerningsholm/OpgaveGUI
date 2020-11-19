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

namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for UpdateEmployeeFormField.xaml
    /// </summary>
    public partial class UpdateEmployeeFormField : UserControl
    {
        public UpdateEmployeeFormField(EmployeeRepository rep)
        {
            InitializeComponent();
            setEmployeeFieldLabels();
        }

        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
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
    }
}
