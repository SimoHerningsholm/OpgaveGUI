﻿using System;
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
using OpgaveGUIAfsluttende.UserControls;
namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for CreateEmployeePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        public CreatePage()
        {
            InitializeComponent();
        }
        private void CreateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            //Laver en specifikt FormField og dimensionere det og putter det i viewgrid
            CreateEmployeeFormField createForm = new CreateEmployeeFormField();
            createForm.Height = 480;
            createForm.Width = 300;
            viewGrid.Children.Add(createForm);
            hideBtns();
        }
        private void CreateDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            //Laver en specifikt FormField og dimensionere det og putter det i viewgrid
            CreateDepartmentFormField createForm = new CreateDepartmentFormField();
            createForm.Height = 480;
            createForm.Width = 1000;
            viewGrid.Children.Add(createForm);
            hideBtns();
        }
        private void hideBtns()
        {
            //Når man har loadet form ind i grid skal knapper gøres usyndlig
            CreateDepartmentBtn.Visibility = Visibility.Hidden;
            CreateEmployeeBtn.Visibility = Visibility.Hidden;
        }
    }
}
