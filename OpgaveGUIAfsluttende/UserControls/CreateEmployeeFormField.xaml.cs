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
        //Deklerere variabler og lister der skal anvends for at oprette en employee
        private int chosenZipCode;
        private int chosenCompanyId;
        private int chosenJobTitle;
        private int chosendepartment;
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
        //Brugerinput sættes til at være objekter som skal valideres for om de opfylder datatype krav for employee properties. 
        //Efter valideringen castes de til korrekt datatype hvis de successfuldt er gået igennem
        public CreateEmployeeFormField()
        {
            InitializeComponent();
            //instanciere objekter der skal anvendes for at oprette employee
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
            chosenCompanyId = 0;
            //loader data ind der skal anvendes for at employeeformen er funktionel
            setEmployeeFieldLabels();
            setZipCodeItems();
            setComboJobTitleItems();
            setComboCompanyItems();
        }
        private async void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Prøver man at oprette employee laves et nyt employee objekt med data i felter som sendes mod datalaget
                Employee newEmp = new Employee();
                newEmp.FirstName = EmployeeFirstName.TextBoxField.Text;
                newEmp.LastName = EmployeeLastName.TextBoxField.Text;
                newEmp.Address = await getNewAddressId();
                newEmp.BirthDay = Convert.ToDateTime(EmployeeBirthDay.DatePickField.Text);
                newEmp.Email = EmployeeEmail.TextBoxField.Text;
                newEmp.Phone = int.Parse(EmployeePhone.TextBoxField.Text);
                newEmp.Department = chosendepartment;
                newEmp.JobTitle = chosenJobTitle;
                await empRep.CreateEmployee(newEmp);
            }
            catch
            {
                statusLabel.Content = "error";
            }
        }
        private async Task<int> getNewAddressId()
        {
            //opretter adresse på basis af zipcode og street og modtager id på ny adresse
            int addrId = await addRep.CreateAddress(new Address { Street = EmployeeStreet.TextBoxField.Text, ZipCode = chosenZipCode });
            //er oprettelsen sket successfuldt kan den fortsætte videre og lave ny employee med pågældende adresse....
            if(addrId != 0)
            {
                return addrId; 
            }
            else
            {
                return 1;
            }
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
        //Alle comboboks sættere
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
        private async void Company_ComboFieldChanged(object sender, EventArgs e)
        {
            EmployeeDepartment.ComboBoxField.SelectedIndex = -1;
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
