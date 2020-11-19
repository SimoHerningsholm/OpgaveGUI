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

namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeDateField.xaml
    /// </summary>
    public partial class DateField : UserControl
    {
        public DateField()
        {
            InitializeComponent();
        }

        private void DateField_GotFocus(object sender, RoutedEventArgs e)
        {
            //Modtager datepicker fokus skal fontweight på label være bold
            DateFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void DateField_LostFocus(object sender, RoutedEventArgs e)
        {
            //Mister datepicker fokus skal fontweight på label være normal
            DateFieldLabel.FontWeight = FontWeights.Normal;
        }
    }
}
