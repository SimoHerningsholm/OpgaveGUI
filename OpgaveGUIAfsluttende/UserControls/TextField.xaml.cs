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
    /// Interaction logic for EmployeeTextField.xaml
    /// </summary>
    public partial class TextField : UserControl
    {
        public TextField()
        {
            InitializeComponent();
        }

        private void TextField_GotFocus(object sender, RoutedEventArgs e)
        {
            //Modtager tekstboks fokus skal fontweight på label være bold
            TextFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void TextField_LostFocus(object sender, RoutedEventArgs e)
        {
            //Mister comboboks fokus skal fontweight på label være bold
            TextFieldLabel.FontWeight = FontWeights.Normal;
        }
    }
}
