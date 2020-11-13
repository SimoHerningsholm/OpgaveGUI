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

namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Når programmet begynder initieres mainwindow framet med en forside
            FrontPage frontpg = new FrontPage();
            contentFrame.Navigate(frontpg);
        }

        private void CreateEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på createemployee navigeres der til createsiden
            CreateEmployeePage createPage = new CreateEmployeePage();
            contentFrame.Navigate(createPage);
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på viewemployee navigeres der til viewsiden
            ViewEmployeePage viewPage = new ViewEmployeePage();
            contentFrame.Navigate(viewPage);
        }
    }
}
