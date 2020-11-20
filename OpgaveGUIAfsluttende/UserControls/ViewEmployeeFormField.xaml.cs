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
using System.Data;
using CLBL;
using CLModels;

namespace OpgaveGUIAfsluttende.UserControls
{
    public partial class ViewEmployeeFormField : UserControl
    {
        private int chosenEmployeeId;
        private JoinedViewRepository joinRep;
        private EmployeeRepository empRep;
        public ViewEmployeeFormField()
        {
            InitializeComponent();
            //Employee Repository instancieres og emloyees loades i grid og comboboks fyldes med gyldige værdier (når der kommer SQL på)
            joinRep = new JoinedViewRepository();
            empRep = new EmployeeRepository();
            LoadEmployeesIds();
            loadView();
        }

        private async void QueryEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Klikkes der på queryemployee kaldes queryemployee metoden
            EmployeeViewerGrid.ItemsSource = await joinRep.ViewEmployeeWithJoinedData(chosenEmployeeId);
        }
        private async void LoadEmployeesIds()
        {
            List<Employee> emps = new List<Employee>();
            emps = await empRep.GetEmployees();
            for (int i = 0; i < emps.Count; i++)
            {
                QueryOptionsCombo.Items.Add(emps[i].Id);
            }
        }
        public async void loadView()
        {
            //Sætter gridview til at indeholde liste over employees der hentes fra businesslogic laget.
            EmployeeViewerGrid.ItemsSource = await joinRep.ViewEmployeesWithJoinedData();
          //  EmployeeViewerGrid.ItemsSource = empList;
        }
        private async void QueryOptionsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Når en værdi på item i comboboksen er valgt, registreres denne værdi
            chosenEmployeeId = (int)QueryOptionsCombo.SelectedItem;
        }
    }
}
