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
    /// Interaction logic for EmployeeComboField.xaml
    /// </summary>
    public partial class ComboField : UserControl
    {
        public bool selectedChanged;
        //Laver en eventhandler der skal modtage comboboks selectionchanged event
        public event EventHandler comboFieldChanged;
        public static readonly DependencyProperty SelectedIndexProperty;
        static ComboField()
        {
            SelectedIndexProperty = DependencyProperty.RegisterAttached("SelectedIndex", typeof(int), typeof(ComboField));
        }
        public ComboField()
        {
            InitializeComponent();
            //Hvis selection på comboboksen ændre sig, skal employeeComboFieldSelectionChanged metoden eksekveres.
            this.ComboBoxField.SelectionChanged += new SelectionChangedEventHandler(this.ComboFieldSelectionChanged);
            //depr
            Binding b = new Binding("SelectedIndex");
            b.Source = this;
            ComboBoxField.SetBinding(ComboBox.SelectedIndexProperty, b);
        }
        public int SelectedIndex
        {
            get { return ((ComboBox)Content).SelectedIndex; }
            set { ((ComboBox)Content).SelectedIndex = value; }
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
