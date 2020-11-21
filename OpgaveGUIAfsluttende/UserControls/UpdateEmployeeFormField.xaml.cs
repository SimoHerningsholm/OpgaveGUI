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
        //deklerere variabler der skal anvendes for at updateemployee modulet fungere
        bool comboFilled;
        private string chosenStreet;
        private int chosenAddressId;
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
            //instanciere objekter der skal anvendes for at updateemployeemodulet fungere
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
            GetEmployeeFieldLabels();
            loadEmployees();
            GetZipCodeItems();
            GetComboJobTitleItems();
            GetComboCompanyItems();
            comboFilled = false;
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
                updateEmp.Address = chosenAddressId;
                updateEmp.BirthDay = Convert.ToDateTime(EmployeeBirthDay.DatePickField.SelectedDate);
                updateEmp.Email = EmployeeEmail.TextBoxField.Text;
                updateEmp.Phone = int.Parse(EmployeePhone.TextBoxField.Text);
                updateEmp.Department = chosendepartment;
                updateEmp.JobTitle = chosenJobTitle;
                updateAddress();
                await empRep.UpdateEmployee(updateEmp);
                
                statusLabel.Content = "Success";
                loadEmployees();
            }
            catch(Exception errorMsg)
            {
                statusLabel.Content = "error";
            }
        }
        private async void loadEmployees()
        {
            EmployeeViewerGrid.ItemsSource = null;
            empList.Clear();
            empList = await empRep.GetEmployees();
            EmployeeViewerGrid.ItemsSource = empList;
        }
        private async void EmployeeViewerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Når der vælges en employee i viewgrid, loades employee ind i de forskellige form felter. Nogengange skal et felt parses ind i en metode der 
            //henter brugervenlig værdi som.feks når brugeren skal kunne se zipcode ud fra adresse id. Man kunne også lave view hvor der er joined på adresse
            //Men lige pt ligger views i forlængelse af modeller der ligger i direkte forlængelse af database. Et view hvor der er joined på andre tabeller
            //Laves i viewemployeeformfield hvis jeg får tid og husker det.
            if(EmployeeViewerGrid.ItemsSource != null)
            {
                try
                {
                    employeeId = int.Parse((EmployeeViewerGrid.SelectedCells[0].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
                    EmployeeFirstName.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[1].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
                    EmployeeLastName.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[2].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
                    GetAddressValues(int.Parse((EmployeeViewerGrid.SelectedCells[3].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text));
                    EmployeeBirthDay.DatePickField.SelectedDate = DateTime.Parse((EmployeeViewerGrid.SelectedCells[4].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
                    EmployeeEmail.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[5].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
                    EmployeePhone.TextBoxField.Text = (EmployeeViewerGrid.SelectedCells[6].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text;
                    GetDepartmentNameFromid(int.Parse((EmployeeViewerGrid.SelectedCells[7].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text));
                    GetJobTitleFromId(int.Parse((EmployeeViewerGrid.SelectedCells[8].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text));
                    GetCompanyFromDepartment(int.Parse((EmployeeViewerGrid.SelectedCells[7].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text));
                }
                catch
                {
                    statusLabel.Content = "missclick";
                }
            }
        }
        public async void updateAddress()
        {
            //når en employee opdateres skal adressen tilhørende employee opdateres.. Dette burde eventuelt flyttes over i SQL..
            Address updatedAddr = new Address();
            updatedAddr.Id = int.Parse((EmployeeViewerGrid.SelectedCells[3].Column.GetCellContent(EmployeeViewerGrid.SelectedItem) as TextBlock).Text);
            updatedAddr.ZipCode = chosenZipCode;
            updatedAddr.Street = EmployeeStreet.TextBoxField.Text;
            await addRep.updateAddress(updatedAddr);
        }
        private async void GetAddressValues(int addressId)
        {
            //sætter værdier associeret med adresse på basis af valgt adresse id fra gridview
            chosenAddressId = addressId;
            Address getAddr = await addRep.getAddressFromId(addressId);
            chosenZipCode = getAddr.ZipCode;
            chosenStreet = getAddr.Street;
            EmployeeStreet.TextBoxField.Text = chosenStreet;
            for (int i = 0; i < zipCodes.Count; i++)
            {
                if ((int)EmployeeZipCode.ComboBoxField.Items[i] == getAddr.ZipCode)
                {
                    EmployeeZipCode.ComboBoxField.SelectedIndex = i;
                    break;
                }
            }
        }
        //sætter værdi for comboboks med companynavne basis af department id
        public async void GetCompanyFromDepartment(int departmentId)
        {
            Company comp = await compRep.getCompanyFromDepartmentId(departmentId);
            for (int i = 0; i < companies.Count; i++)
            {
                if ((string)EmployeeCompany.ComboBoxField.Items[i] == comp.Name)
                {
                    EmployeeCompany.ComboBoxField.SelectedIndex = i;
                    break;
                }
            }
        }
        //sætter værdi for comboboks med department på basis af department id... har en bug her lige pt der skal fikses pga event på comboboks
        //i relation med når den loades gennem company comboboks event
        public async void GetDepartmentNameFromid(int departmentId)
        {
            Department dep = await depRep.GetDepartment(departmentId);
            for (int i = 0; i < departments.Count; i++)
            {
                if ((string)EmployeeDepartment.ComboBoxField.Items[i] == dep.Name)
                {
                    EmployeeDepartment.ComboBoxField.SelectedIndex = i;
                    break;
                }
            }
        }
        //sætter værdi for comboboks med jobtitel på basis af jobtitelid
        public async void GetJobTitleFromId(int jobTitleId)
        {
            JobTitle job = await jobRep.getJobTitle(jobTitleId);
            for (int i = 0; i < jobtitles.Count; i++)
            {
                if ((string)EmployeeJobTitle.ComboBoxField.Items[i] == job.Name)
                {
                    EmployeeJobTitle.ComboBoxField.SelectedIndex = i;
                    break;
                }
            }
        }
        //Company combobokse skal liste alle de mulige companies man kan vælge imellem
        private async void GetComboCompanyItems()
        {
            companies = await compRep.getCompanies();
            for (int i = 0; i < companies.Count; i++)
            {
                EmployeeCompany.ComboBoxField.Items.Add(companies[i].Name);
            }
        }
        //zipcode comboboks skal liste alle de mulige postnumre. Ved at placere i comboboks kan brugeren ikke vælge et der ikke eksistere
        private async void GetZipCodeItems()
        {
            zipCodes = await zipRep.getZipCodes();
            for (int i = 0; i < zipCodes.Count; i++)
            {
                EmployeeZipCode.ComboBoxField.Items.Add(zipCodes[i].Zipcode);
            }
        }
        //comboboks med jobtitler skal have alle de mulige jobtitler
        private async void GetComboJobTitleItems()
        {
            jobtitles = await jobRep.getJobTitles();
            for (int i = 0; i < jobtitles.Count; i++)
            {
                EmployeeJobTitle.ComboBoxField.Items.Add(jobtitles[i].Name);
            }
        }
        //comboboks med afdelinger skal fyldes med afdelinger der ligger i forlængelse af den company der er valgt
        private async void GetComboDepartmentItems(int chosenCompany)
        {
            //hvis comboboks har flere items end 0 skal departmentliste clears og combobox skal cleares. derefter skal 
            //liste og comboboks reloades med nye værdier. Hvis der ikke er over 0 er det første gang den skal fyldes.
            if (EmployeeDepartment.ComboBoxField.Items.Count >= 1)
            {
                comboFilled = true;
                departments.Clear();
                EmployeeDepartment.ComboBoxField.Items.Clear();
                departments = await depRep.GetDepartmentsFromCompany(chosenCompany);
                for (int i = 0; i < departments.Count; i++)
                {
                    EmployeeDepartment.ComboBoxField.Items.Add(departments[i].Name);
                }
            }
            else
            {
                departments = await depRep.GetDepartmentsFromCompany(chosenCompany);
                for (int i = 0; i < departments.Count; i++)
                {
                    EmployeeDepartment.ComboBoxField.Items.Add(departments[i].Name);
                }
            }
        }
        //Når man har valgt et firma sættes id på det firma man har valgt og det bliver muligt at vælge afdelinger relateret til firmaet
        private async void EmployeeCompany_comboFieldChanged(object sender, EventArgs e)
        {
            //Er der valgt et firma sættes employeedepartment comboboks til at være synlig så man kan vælge afdeling
            chosenCompanyId = companies.Find(c => c.Id == companies[EmployeeCompany.ComboBoxField.SelectedIndex].Id).Id;
            GetComboDepartmentItems(chosenCompanyId);
        }
        //Når der vælges en ny jobtitel sættes id på den pågældende titel med henblik på at kunne opdatere bruger med det id
        private void EmployeeJobTitle_comboFieldChanged(object sender, EventArgs e)
        {
            chosenJobTitle = jobtitles.Find(c => c.Id == jobtitles[EmployeeJobTitle.ComboBoxField.SelectedIndex].Id).Id;
        }
        //Når man har valgt en afdeling sættes id på det department med henblik på at brugeren modtager denne department
        private void EmployeeDepartment_comboFieldChanged(object sender, EventArgs e)
        {
            //hvis combofilled er sat til true vil comboboks for departments blive cleared hvilket vil trigger dette event. Derfor
            //vil der opstå en error hvis den går direkte til at query på departments lige efter den er blevet tømt fordi der ikke vil være
            //nogle departments at vælge imellem. Derfor sættes combofilled til true oppe i GetComboDepartmentItems således dette 
            //if statement kan laves som gør at den ikke pr automatik går ind querier på department ved reload efter comboboks er tømt
            if (comboFilled == false)
            {
                chosendepartment = departments.Find(c => c.Id == departments[EmployeeDepartment.ComboBoxField.SelectedIndex].Id).Id;
                statusLabel.Content = chosendepartment;
            }
            else
            {
                comboFilled = false;
            }
        }
        //Når man har valgt postnumre sættes postnummer property som kan sendes videre til adresse for brugeren
        private void EmployeeZipCode_comboFieldChanged(object sender, EventArgs e)
        {
            chosenZipCode = zipCodes.Find(c => c.Zipcode == zipCodes[EmployeeZipCode.ComboBoxField.SelectedIndex].Zipcode).Zipcode;
        }
        //Content på labels i de forskellige usercontrols sættes med de værdier der gør sig gældende for en createemployee form
        private async void GetEmployeeFieldLabels()
        {
            EmployeeFirstName.TextFieldLabel.Content = "Firstname:";
            EmployeeLastName.TextFieldLabel.Content = "Lastname:";
            EmployeeStreet.TextFieldLabel.Content = "Street:";
            EmployeeZipCode.ComboFieldLabel.Content = "Zipcode";
            EmployeeBirthDay.DateFieldLabel.Content = "Birthday:";
            EmployeeEmail.TextFieldLabel.Content = "Email";
            EmployeePhone.TextFieldLabel.Content = "Phone";
            EmployeeJobTitle.ComboFieldLabel.Content = "Jobtitle";
            EmployeeCompany.ComboFieldLabel.Content = "Company:";
            EmployeeDepartment.ComboFieldLabel.Content = "Department:";
        }
    }
}
