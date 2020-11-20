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
    /// Interaction logic for UpdateEmployeePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        public UpdatePage()
        {
            InitializeComponent();
        }
        private void UpdateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmployeeFormField updateForm = new UpdateEmployeeFormField();
            updateForm.Height = 530;
            updateForm.Width = 1000;
            viewGrid.Children.Add(updateForm);
            hideBtns();
        }
        private void hideBtns()
        {
            UpdateEmployeeBtn.Visibility = Visibility.Hidden;
        }
    }
}
