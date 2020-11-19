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
using OpgaveGUIAfsluttende.UserControls;
using CLBL;

namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for DeleteEmployeePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        private EmployeeRepository rep;
        public DeletePage(EmployeeRepository inRep)
        {
            InitializeComponent();
            rep = inRep;
        }
        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteEmployeeFormField deleteForm = new DeleteEmployeeFormField(rep);
            deleteForm.Height = 530;
            deleteForm.Width = 650;
            viewGrid.Children.Add(deleteForm);
            hideBtns();
        }
        private void hideBtns()
        {
            DeleteEmployeeBtn.Visibility = Visibility.Hidden;
        }
    }
}
