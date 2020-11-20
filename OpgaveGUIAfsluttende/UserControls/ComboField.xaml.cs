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
using System.Windows.Forms;

namespace OpgaveGUIAfsluttende.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeComboField.xaml
    /// </summary>
    public partial class ComboField : System.Windows.Controls.UserControl
    {
        public bool selectedChanged;
        //Laver en eventhandler der skal modtage comboboks selectionchanged event
        public event EventHandler comboFieldChanged;
        public ComboField()
        {
            InitializeComponent();
            //Hvis selection på comboboksen ændre sig, skal employeeComboFieldSelectionChanged metoden eksekveres.
            this.ComboBoxField.SelectionChanged += new SelectionChangedEventHandler(this.ComboFieldSelectionChanged);
        }

        protected void ComboFieldSelectionChanged(object sender, EventArgs e)
        {
            //Eksekveres denne metode eksekveres eventet såfremt eventet er sat
            comboFieldChanged?.Invoke(sender, e);
        }
        private void ComboField_GotFocus(object sender, RoutedEventArgs e)
        {
            //Modtager comboboks fokus skal fontweight på label være bold
            ComboFieldLabel.FontWeight = FontWeights.Bold;
        }

        private void ComboField_LostFocus(object sender, RoutedEventArgs e)
        {
            //Mister comboboks fokus skal fontweight på label være normal
            ComboFieldLabel.FontWeight = FontWeights.Normal;
        }
    }
}
