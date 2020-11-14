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
    public partial class CreateEmployeePage : Page
    {
        public CreateEmployeePage(EmployeeRepository inRep)
        {
            InitializeComponent();
            CreateEmployeeFormField createForm = new CreateEmployeeFormField(inRep);
            createForm.Height = 300;
            createForm.Width = 300;
            viewGrid.Children.Add(createForm);
        }
    }
}
