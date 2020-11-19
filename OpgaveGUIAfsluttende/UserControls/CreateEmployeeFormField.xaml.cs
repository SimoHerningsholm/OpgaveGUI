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
        private object nameField;
        private object addressField;
        private object zipCodeField;
        private object birthDayField;
        private object companyField;
        private object departmentField;
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
          /*  //Sætter properties med brugerinput
            setEmployeeTxtFields();
            //tjekker på alle brugerinput employeeDataChecker som tjekker at datatyper for felter er korrekt for et employee objekt
            if(employeeInputDataCheck.employeeDataChecker(await getEmployeeFieldArray()))
            {
                //Efter objektet er lavet valideres der på om employee er oprettet
                if(await empRep.CreateEmployee(new Employee { FirstName = (string)nameField, Address = (string)addressField, ZipCode = int.Parse((string)zipCodeField), BirthDay = Convert.ToDateTime(birthDayField), Company = (string)companyField, Department = (string)departmentField }))
                {
                    EmployeeErrors.Visibility = Visibility.Hidden;
                    statusLabel.Visibility = Visibility.Visible;
                    statusLabel.Content = "Employee created successfully";
                }
                else
                {
                    genErrorMessages(empRep.getErrors());
                }
            }
            else
            {
                genErrorMessages(employeeInputDataCheck.getErrorMessages());
            }*/
        }
        private async void setEmployeeFieldLabels()
        {
            //Content på labels i de forskellige usercontrols sættes med de værdier der gør sig gældende for en createemployee form
            EmployeeName.TextFieldLabel.Content = "Name:";
            EmployeeAddress.TextFieldLabel.Content = "Address:";
            EmployeeZipCode.TextFieldLabel.Content = "Zipcode:";
            EmployeeBirthDay.DateFieldLabel.Content = "Birthday:";
            EmployeeCompany.ComboFieldLabel.Content = "Company:";
            EmployeeDepartment.ComboFieldLabel.Content = "Department:";
        }
        private async void setComboCompanyItems()
        {
            //Sætter company items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes businesslag som henter fra datalag
            EmployeeCompany.ComboBoxField.Items.Add("FunnyINC");
            EmployeeCompany.ComboBoxField.Items.Add("CircusArena");
            EmployeeCompany.ComboBoxField.Items.Add("ToysRUs");
            EmployeeCompany.ComboBoxField.Items.Add("CircusArena");
        }
        private async void setComboDepartmentItems()
        {
            //Sætter department items. Indtil videre hardcodes der bare nogle værdier, men de skal hentes på basis af valgt company fra liste fra fået fra businesslag som henter fra datalag
            EmployeeDepartment.ComboBoxField.Items.Add("Comedy");
            EmployeeDepartment.ComboBoxField.Items.Add("Acrobatics");
            EmployeeDepartment.ComboBoxField.Items.Add("ToyProduction");
            EmployeeDepartment.ComboBoxField.Items.Add("Management");
        }
        private async void Company_ComboFieldChanged(object sender, EventArgs e)
        {
            //Er der valgt et firma sættes employeedepartment comboboks til at være synlig så man kan vælge afdeling
            EmployeeDepartment.Visibility = Visibility.Visible;
        }
        private async void setEmployeeTxtFields()
        {
            nameField = EmployeeName.TextBoxField.Text;
            addressField = EmployeeAddress.TextBoxField.Text;
            zipCodeField = EmployeeZipCode.TextBoxField.Text;
            birthDayField = EmployeeBirthDay.DatePickField.Text;
            companyField = EmployeeCompany.ComboBoxField.SelectedItem;
            departmentField = EmployeeDepartment.ComboBoxField.SelectedItem;
        }
        private async Task<List<object>> getEmployeeFieldArray()
        {
            return new List<object>() { nameField, addressField, zipCodeField, birthDayField, companyField, departmentField };
        }
        private async void genErrorMessages(List<string> errors)
        {
            EmployeeErrors.ComboBoxField.Items.Clear();
            EmployeeErrors.Visibility = Visibility.Visible;
            EmployeeErrors.ComboFieldLabel.Content = "Error:";
            for (int i = 0; i < errors.Count; i++)
            {
                EmployeeErrors.ComboBoxField.Items.Add(errors[i]);
            }
        }
    }
}
