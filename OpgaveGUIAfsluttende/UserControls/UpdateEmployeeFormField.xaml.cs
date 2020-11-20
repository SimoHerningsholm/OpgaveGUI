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
        private int employeeId;
        private int chosenZipCode;
        private int chosenCompanyId;
        private int chosenJobTitle;
        private int chosendepartment;
        private List<Employee> empList;
        private EmployeeRepository empRep;
        private CompanyRepository compRep;
        private DepartmentRepository depRep;
        private JobTitleRepository jobRep;
        private ZipCodeRepository zipRep;
        private AddressRepository addRep;
        List<Department> departments;
        List<JobTitle> jobtitles;
        List<ZipCode> zipCodes;
        List<Company> companies;
        public UpdateEmployeeFormField()
        {
            InitializeComponent();
            empRep = new EmployeeRepository();
            companies = new List<Company>();
            compRep = new CompanyRepository();
            depRep = new DepartmentRepository();
            jobRep = new JobTitleRepository();
            zipRep = new ZipCodeRepository();
            addRep = new AddressRepository();
            empRep = new EmployeeRepository();
            departments = new List<Department>();
            jobtitles = new List<JobTitle>();
            zipCodes = new List<ZipCode>();
            empList = new List<Employee>();
            setEmployeeFieldLabels();
            loadEmployees();
            chosenCompanyId = 0;
            setEmployeeFieldLabels();
            setZipCodeItems();
            setComboJobTitleItems();
            setComboCompanyItems();
        }
        private async void UpdateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Efter objektet er lavet valideres der på om employee er oprettet
                Employee updateEmp = new Employee();
                updateEmp.Id = employeeId;
                updateEmp.FirstName = EmployeeFirstName.TextBoxField.Text;
                updateEmp.LastName = EmployeeLastName.TextBoxField.Text;
                updateEmp.Address = int.Parse((EmployeeViewerGrid.SelectedCells[3].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
                updateEmp.BirthDay = Convert.ToDateTime(EmployeeBirthDay.DatePickField.Text);
                updateEmp.Email = EmployeeEmail.TextBoxField.Text;
                updateEmp.Phone = int.Parse(EmployeePhone.TextBoxField.Text);
                updateEmp.Department = chosendepartment;
                updateEmp.JobTitle = chosenJobTitle;
                await empRep.UpdateEmployee(updateEmp);
                statusLabel.Content = "Success";
            }
            catch(Exception errorMsg)
            {
                statusLabel.Content = "error";
            }
        }
        private async void loadEmployees()
        {
            empList = await empRep.GetEmployees();
            EmployeeViewerGrid.ItemsSource = empList;
        }
        private async void EmployeeViewerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employeeId = int.Parse((EmployeeViewerGrid.SelectedCells[0].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
            EmployeeFirstName.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[1].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
            EmployeeLastName.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[2].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
            SetStreetAndZipCodeFromAdress(int.Parse((EmployeeViewerGrid.SelectedCells[3].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text));
            EmployeeBirthDay.DatePickField.Text = (EmployeeViewerGrid.SelectedCells[5].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
            EmployeeEmail.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[5].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
            EmployeePhone.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[6].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
            chosendepartment = int.Parse((EmployeeViewerGrid.SelectedCells[7].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
            chosenJobTitle = int.Parse((EmployeeViewerGrid.SelectedCells[8].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
            EmployeeDepartment.ComboBoxField.SelectedIndex = 2;
        /*    for (int i = 0; i < departments.Count; i++)
            {
                if((string)EmployeeDepartment.ComboBoxField.Items[i] == "Manager")
                {
                    EmployeeDepartment.ComboBoxField.SelectedIndex = i + 1;
                }
            }*/
        }

        private async void SetStreetAndZipCodeFromAdress(int addressId)
        {
            Address newAddr = await addRep.getAddressFromId(addressId);
            EmployeeStreet.TextBoxField.Text = newAddr.Street;
            chosenZipCode = newAddr.ZipCode;
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

        //Company combobokse skal liste alle de mulige companies man kan vælge imellem
        private async void setComboCompanyItems()
        {
            companies = await compRep.getCompanies();
            for (int i = 0; i < companies.Count; i++)
            {
                EmployeeCompany.ComboBoxField.Items.Add(companies[i].Name);
            }
        }
        //zipcode comboboks skal liste alle de mulige postnumre. Ved at placere i comboboks kan brugeren ikke vælge et der ikke eksistere
        private async void setZipCodeItems()
        {
            zipCodes = await zipRep.getZipCodes();
            for (int i = 0; i < zipCodes.Count; i++)
            {
                EmployeeZipCode.ComboBoxField.Items.Add(zipCodes[i].Zipcode);
            }
        }
        //comboboks med jobtitler skal have alle de mulige jobtitler
        private async void setComboJobTitleItems()
        {
            jobtitles = await jobRep.getJobTitles();
            for (int i = 0; i < jobtitles.Count; i++)
            {
                EmployeeJobTitle.ComboBoxField.Items.Add(jobtitles[i].Name);
            }
        }
        //comboboks med afdelinger skal fyldes med afdelinger der ligger i forlængelse af den company der er valgt
        private async void setComboDepartmentItems(int chosenCompany)
        {
            departments = await depRep.GetDepartmentsFromCompany(chosenCompany);
            for (int i = 0; i < departments.Count; i++)
            {
                EmployeeDepartment.ComboBoxField.Items.Add(departments[i].Name);
            }
        }
        //Alle combofieldchanged
        //Når man har valgt et firma sættes id på det firma man har valgt og det bliver muligt at vælge afdelinger relateret til firmaet
        private async void EmployeeCompany_comboFieldChanged(object sender, EventArgs e)
        {
            //Er der valgt et firma sættes employeedepartment comboboks til at være synlig så man kan vælge afdeling
            chosenCompanyId = companies.Find(c => c.Id == companies[EmployeeCompany.ComboBoxField.SelectedIndex].Id).Id;
            setComboDepartmentItems(chosenCompanyId);
            EmployeeDepartment.Visibility = Visibility.Visible;
            statusLabel.Content = chosenCompanyId;
        }
        //Når der vælges en ny jobtitel sættes id på den pågældende titel med henblik på at kunne opdatere bruger med det id
        private void EmployeeJobTitle_comboFieldChanged(object sender, EventArgs e)
        {
            chosenJobTitle = jobtitles.Find(c => c.Id == jobtitles[EmployeeJobTitle.ComboBoxField.SelectedIndex].Id).Id;
            statusLabel.Content = chosenJobTitle;
        }
        //Når man har valgt en afdeling sættes id på det department med henblik på at brugeren modtager denne department
        private void EmployeeDepartment_comboFieldChanged(object sender, EventArgs e)
        {
            chosendepartment = departments.Find(c => c.Id == departments[EmployeeDepartment.ComboBoxField.SelectedIndex].Id).Id;
            statusLabel.Content = chosendepartment;
        }
        //Når man har valgt postnumre sættes postnummer property som kan sendes videre til adresse for brugeren
        private void EmployeeZipCode_comboFieldChanged(object sender, EventArgs e)
        {
            chosenZipCode = zipCodes.Find(c => c.Zipcode == zipCodes[EmployeeZipCode.ComboBoxField.SelectedIndex].Zipcode).Zipcode;
            statusLabel.Content = chosenZipCode;
        }
    }
}
