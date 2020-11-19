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
using CLValidator;
namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for CreateEmployeeFormField.xaml
    /// </summary>
    public partial class CreateEmployeeFormField : UserControl
    {
        private EmployeeRepository empRep;
        private EmployeeDataTypeChecker employeeInputDataCheck;
        //Brugerinput sættes til at være objekter som skal valideres for om de opfylder datatype krav for employee properties. 
        //Efter valideringen castes de til korrekt datatype hvis de successfuldt er gået igennem
        public CreateEmployeeFormField(EmployeeRepository empRep)
        {
            InitializeComponent();
            setEmployeeFieldLabels();
            setComboCompanyItems();
            setComboDepartmentItems();
            employeeInputDataCheck = new EmployeeDataTypeChecker();
            this.empRep = empRep;
        }
        private async void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Efter objektet er lavet valideres der på om employee er oprettet
                Employee newEmp = new Employee();
                newEmp.FirstName = EmployeeFirstName.TextBoxField.Text;
                newEmp.LastName = EmployeeLastName.TextBoxField.Text;
                newEmp.Address = 0;
                newEmp.BirthDay = Convert.ToDateTime(EmployeeBirthDay.DatePickField.Text);
                newEmp.Email = EmployeeEmail.TextBoxField.Text;
                newEmp.Phone = int.Parse(EmployeePhone.TextBoxField.Text);
                newEmp.Department = 0;
                newEmp.JobTitle = setJobTitleFromName();
                await empRep.CreateEmployee(newEmp);
            }
            catch
            {
                statusLabel.Content = "error";
            }

            
        }
        private int setDepartmentFromName()
        {
            return 0;
        }
        private int setJobTitleFromName()
        {
            return 0;
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
        private async void setComboCompanyItems()
        {
            //Sætter company items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes businesslag som henter fra datalag
        }
        private async void setComboDepartmentItems()
        {
            //Sætter department items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes på basis af valgt company fra liste fra fået fra businesslag som henter fra datalag
        }
        private async void Company_ComboFieldChanged(object sender, EventArgs e)
        {
            //Er der valgt et firma sættes employeedepartment comboboks til at være synlig så man kan vælge afdeling
            EmployeeDepartment.Visibility = Visibility.Visible;
        }

        private void EmployeeJobTitle_comboFieldChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeDepartment_comboFieldChanged(object sender, EventArgs e)
        {

        }
    }
}
