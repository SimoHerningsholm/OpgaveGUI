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
        public MainWindow()
        {
            InitializeComponent();
            //Når programmet begynder initieres mainwindow framet med en forside
            FrontPage frontpg = new FrontPage();
            contentFrame.Navigate(frontpg);
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på createemployees navigeres der til createsiden
            CreatePage createPage = new CreatePage();
            contentFrame.Navigate(createPage);
        }
        private void View_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på viewemployees navigeres der til viewsiden
            ViewPage viewPage = new ViewPage();
            contentFrame.Navigate(viewPage);
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på updateemployees navigeres der til updatesiden
            UpdatePage updatePage = new UpdatePage();
            contentFrame.Navigate(updatePage);
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //ved klik på deleteemployees navigeres der til deletesiden
            DeletePage deletePage = new DeletePage();
            contentFrame.Navigate(deletePage);
        }
    }
}
