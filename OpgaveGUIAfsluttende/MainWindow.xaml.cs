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

namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeRepository empRep;
        public MainWindow()
        {
            InitializeComponent();
            //Når programmet begynder initieres mainwindow framet med en forside
            FrontPage frontpg = new FrontPage();
            empRep = new EmployeeRepository();
            contentFrame.Navigate(frontpg);
        }

        private void CreateEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på createemployees navigeres der til createsiden
            CreateEmployeePage createPage = new CreateEmployeePage(empRep);
            contentFrame.Navigate(createPage);
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på viewemployees navigeres der til viewsiden
            ViewEmployeePage viewPage = new ViewEmployeePage(empRep);
            contentFrame.Navigate(viewPage);
        }

        private void updateEmployees_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på updateemployees navigeres der til updatesiden
            UpdateEmployeePage updatePage = new UpdateEmployeePage();
            contentFrame.Navigate(updatePage);
        }

        private void deleteEmployees_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på deleteemployees navigeres der til deletesiden
            DeleteEmployeePage deletePage = new DeleteEmployeePage();
            contentFrame.Navigate(deletePage);
        }
    }
}
