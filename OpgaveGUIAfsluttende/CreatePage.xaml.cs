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
using OpgaveGUIAfsluttende.UserControls;
namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for CreateEmployeePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        private EmployeeRepository rep;
        public CreatePage(EmployeeRepository inRep)
        {
            InitializeComponent();
            rep = inRep;

        }

        private void CreateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeFormField createForm = new CreateEmployeeFormField(rep);
            createForm.Height = 340;
            createForm.Width = 300;
            viewGrid.Children.Add(createForm);
            hideBtns();
            
        }

        private void CreateDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateDepartmentFormField createForm = new CreateDepartmentFormField(rep);
            createForm.Height = 340;
            createForm.Width = 300;
            viewGrid.Children.Add(createForm);
            hideBtns();

        }
        public void hideBtns()
        {
            CreateEmployeeBtn.Visibility = Visibility.Hidden;
            CreateDepartmentBtn.Visibility = Visibility.Hidden;
        }
    }
}
