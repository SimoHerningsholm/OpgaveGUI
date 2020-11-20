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
        public DeletePage()
        {
            InitializeComponent();
        }
        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            //Laver en specifikt FormField og dimensionere det og putter det i viewgrid
            DeleteEmployeeFormField deleteForm = new DeleteEmployeeFormField();
            deleteForm.Height = 530;
            deleteForm.Width = 1000;
            viewGrid.Children.Add(deleteForm);
            hideBtns();
        }
        private void hideBtns()
        {
            //Når man har loadet form ind i grid skal knapper gøres usyndlig
            DeleteEmployeeBtn.Visibility = Visibility.Hidden;
        }
    }
}
