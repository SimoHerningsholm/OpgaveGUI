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
    /// Interaction logic for CreateDepartmentFormField.xaml
    /// </summary>
    public partial class CreateDepartmentFormField : UserControl
    {
        //deklerere alle variabler der skal anvendes for at oprette department
        private int ChosenCompanyId;
        private CompanyRepository compRep;
        private DepartmentRepository depRep;
        private EmployeeRepository empRep;
        private List<Employee> potentialBosses;
        private List<Company> PotentialCompanies;
        private List<Department> Departments;
        private Employee chosenBoss;
        public CreateDepartmentFormField()
        {
            InitializeComponent();
            //instancere alle objekter der skal anvends for at oprette department
            depRep = new DepartmentRepository();
            compRep = new CompanyRepository();
            empRep = new EmployeeRepository();
            chosenBoss = new Employee();
            potentialBosses = new List<Employee>();
            PotentialCompanies = new List<Company>();
            Departments = new List<Department>();
            ChosenCompanyId = 0;
            //loader ting der skal loades fra start for at oprettelsesmodulet er funktionelt
            SetDepartmentFormLabels();
            loadCompanyCombo();
            LoadBossCombo();
            loadDepartments();
        }
        private async void loadDepartments()
        {
            //læser departments ind i gridview, for at grid ikke bliver overfyldt cleares listen for hver gang en load finder steder
            departmentsGrid.ItemsSource = null;
            Departments.Clear();
            Departments = await depRep.GetDepartments();
            departmentsGrid.ItemsSource = Departments;
        }
        private async void CreateDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Employee objektet sættes til at få jobtitel 1 hvilket er en boss jobtitel
                chosenBoss.JobTitle = 1;
                //Der laves et nyt department object hvor navnet på department sættes til at være tekstboks værdi og valgt id firma department tilhører sættes
                Department newDep = new Department();
                newDep.Name = DepartmentName.TextBoxField.Text;
                //Brugeren kan kun vælge lovlige id'er, derfor valideres der ikke
                newDep.CompanyId = ChosenCompanyId;
                //Den nye department sendes til oprettelse med employee der er sat til at være chef for afdelingen
                await depRep.CreateDepartment(newDep, chosenBoss);
                statusLabel.Content = "Department created";
                loadDepartments();
            }
            catch
            {
                statusLabel.Content = "An error occured";
            }
        }
        private async void SetDepartmentFormLabels()
        {
            //sætter labels
            DepartmentCompany.ComboFieldLabel.Content = "Company";
            DepartmentName.TextFieldLabel.Content = "Name";
            DepartmentBoss.ComboFieldLabel.Content = "Boss";
        }
        private async void loadCompanyCombo()
        {
            //modtager companies og loader dem ind i combobox for companies
            PotentialCompanies = await compRep.getCompanies();
            for (int i = 0; i < PotentialCompanies.Count; i++)
            {
                DepartmentCompany.ComboBoxField.Items.Add(PotentialCompanies[i].Name);
            }
        }
        private async void LoadBossCombo()
        {
            //modtager potentielle bosses og loader dem ind i comboboks for bosses
            potentialBosses = await empRep.GetEmployees();
            for (int i = 0; i < potentialBosses.Count; i++)
            {
                DepartmentBoss.ComboBoxField.Items.Add(potentialBosses[i].Id.ToString() + " " + potentialBosses[i].FirstName + " " + potentialBosses[i].LastName);
            }
        }
        private void DepartmentCompany_comboFieldChanged(object sender, EventArgs e)
        {
            //querier company id ud fra valgt company i comboboksen med et lambda udtryk
            ChosenCompanyId = PotentialCompanies.Find(c => c.Id == PotentialCompanies[DepartmentCompany.ComboBoxField.SelectedIndex].Id).Id;
        }

        private void DepartmentBoss_comboFieldChanged(object sender, EventArgs e)
        {
            //qurier boss id ud fra valgt boss i comboboksen med et lambdaudtryk
            chosenBoss = potentialBosses.Find(p => p.Id == potentialBosses[DepartmentBoss.ComboBoxField.SelectedIndex].Id);
        }
    }
}
