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
    /// Interaction logic for CreateEmployeeFormField.xaml
    /// </summary>
    public partial class CreateEmployeeFormField : UserControl
    {
        private EmployeeRepository empRep;
        
        public CreateEmployeeFormField(EmployeeRepository empRep)
        {
            InitializeComponent();
            setEmployeeFieldLabels();
            setComboCompanyItems();
            setComboDepartmentItems();
            this.empRep = empRep;
           // empRep = new EmployeeRepository();
        }

        private async void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Ved at klikke på createemployee kaldes createEmployee metoden fra employeerepository objektet, som modtager en ny employee der skal indsætets
            //Værdien der er valgt sættes i loadQueryOptionsResult som så lister id'er indenfor det valgte item
            try
            {
               bool status = await empRep.createEmployee(
                        new Employee
                        {
                            Name = EmployeeName.employeeTextField.Text,
                            Address = EmployeeAddress.employeeTextField.Text,
                            ZipCode = int.Parse(EmployeeZipCode.employeeTextField.Text),
                            BirthDay = Convert.ToDateTime(EmployeeBirthDay.employeeDateField.Text),
                            Company = EmployeeCompany.employeeComboField.SelectedItem.ToString(),
                            Department = EmployeeDepartment.employeeComboField.SelectedItem.ToString()
                        }
                    );
                statusLabel.Content = "Success";
            }
            catch
            {
                statusLabel.Content = "Error";
            }
        }
        private void setEmployeeFieldLabels()
        {
            //Content på labels i de forskellige usercontrols sættes med de værdier der gør sig gældende for en createemployee form
            EmployeeName.employeeTextFieldLabel.Content = "Name:";
            EmployeeAddress.employeeTextFieldLabel.Content = "Address:";
            EmployeeZipCode.employeeTextFieldLabel.Content = "Zipcode:";
            EmployeeBirthDay.employeeDateFieldLabel.Content = "Birthday:";
            EmployeeCompany.employeeComboFieldLabel.Content = "Company:";
            EmployeeDepartment.employeeComboFieldLabel.Content = "Department:";
        }
        private async void setComboCompanyItems()
        {
            //Sætter company items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes businesslag som henter fra datalag
            EmployeeCompany.employeeComboField.Items.Add("FunnyINC");
            EmployeeCompany.employeeComboField.Items.Add("CircusArena");
            EmployeeCompany.employeeComboField.Items.Add("ToysRUs");
            EmployeeCompany.employeeComboField.Items.Add("CircusArena");
        }
        private async void setComboDepartmentItems()
        {
            //Sætter department items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes på basis af valgt company fra liste fra fået fra businesslag som henter fra datalag
            EmployeeDepartment.employeeComboField.Items.Add("Comedy");
            EmployeeDepartment.employeeComboField.Items.Add("Acrobatics");
            EmployeeDepartment.employeeComboField.Items.Add("ToyProduction");
            EmployeeDepartment.employeeComboField.Items.Add("Management");
        }
        private void EmployeeCompany_EmployeeComboFieldChanged(object sender, EventArgs e)
        {
            //Er der valgt et firma sættes employeedepartment comboboks til at være synlig så man kan vælge afdeling
            EmployeeDepartment.Visibility = Visibility.Visible;
        }
    }
}
