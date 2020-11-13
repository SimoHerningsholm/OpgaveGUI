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
using System.Threading;
using System.Threading.Tasks;
using CLBL;
using CLModels;

namespace OpgaveGUIAfsluttende.UserControls
{
    public partial class ViewEmployeeFormField : UserControl
    {
        private EmployeeRepository empRep;
        private List<Employee> empList;
        public ViewEmployeeFormField()
        {
            InitializeComponent();
            //Employee Repository instancieres og emloyees loades i grid og comboboks fyldes med gyldige værdier (når der kommer SQL på)
            empRep = new EmployeeRepository();
            empList = new List<Employee>();
            loadEmployees();
            loadComboOptions();
        }

        private void QueryEmployee_Click(object sender, RoutedEventArgs e)
        {
            queryEmployee();
        }
        public async void loadEmployees()
        {
        //Sætter gridview til at indeholde liste over employees der hentes fra businesslogic laget.
            empList = await empRep.getEmployees();
            EmployeeViewerGrid.ItemsSource = empList;
          //  EmployeeViewerGrid.ItemsSource = empList;
        }
        private async void loadComboOptions()
        {
            //Denne metode skal kunne dynamisk loade identifier options man kan query på, for at gøre det dynamisk. Dette kan dog først lade sig gøre når der er kommet SQL ind over.
        }
        private async void QueryOptionsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Når en værdi på item i comboboksen er valgt, registreres denne værdi
            ComboBoxItem selectedFarveComboItem = (ComboBoxItem)QueryOptionsCombo.SelectedItem;
            //Værdien der er valgt sættes i loadQueryOptionsResult som så lister id'er indenfor det valgte item
            loadQueryOptionsResult((string)selectedFarveComboItem.Content);
        }
        private async void loadQueryOptionsResult(string queryOption)
        {
            //Listen over identificers cleares hver gang eventet bliver triggered
            QueryOptionResultList.Items.Clear();
            //indtil videre kommer der bare en liste over employee id'er der kan queries på.
            //Når der kommer SQL ind over skal der queries data der ligger i forlængelse af valget
            List<Employee> employees = await empRep.getEmployees();
            for (int i = 0; i < employees.Count; i++)
            {
                QueryOptionResultList.Items.Add(employees[i].Id);
            }
        }
        private void queryEmployee()
        {
            //Laver en liste af employees som opfylder kriterie (som har specifikt id)
            List<Employee> queriedEmployee = new List<Employee>();
            //Hvis der ikke er valgt noget har den intet at iterere igennem
            if(QueryOptionResultList.SelectedValue != null)
            {
            //iterere igennem listen af employees
               for (int i = 0; i < empList.Count; i++)
                {
                    //Hvis der er en employee med id der er lig den valgte id så sættes den employee i listen over employees der opfylder kriterier
                    if(empList[i].Id == (int)QueryOptionResultList.SelectedValue)
                    {
                        queriedEmployee.Add(empList[i]);
                    }
                }
            }
 
            //Sætter itemsource på datagrid til at være listen over employees der opfylder kriterier
            EmployeeViewerGrid.ItemsSource = queriedEmployee;
        }
    }
}
