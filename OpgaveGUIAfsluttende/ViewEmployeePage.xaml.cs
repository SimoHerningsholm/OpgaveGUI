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
using OpgaveGUIAfsluttende.UserControls;
using CLBL;

namespace OpgaveGUIAfsluttende
{
    /// <summary>
    /// Interaction logic for ViewEmployeePage.xaml
    /// </summary>
    public partial class ViewEmployeePage : Page
    {
        public ViewEmployeePage(EmployeeRepository inRep)
        {
            InitializeComponent();
            ViewEmployeeFormField viewfield = new ViewEmployeeFormField(inRep);
            viewfield.HorizontalAlignment = HorizontalAlignment.Center;
            viewfield.VerticalAlignment = VerticalAlignment.Center;
            viewfield.Height = 400;
            viewfield.Width = 650;
            viewgrid.Children.Add(viewfield);

        }
        /*ViewEmployeeFormField x:Name="EmployeekageCode" Grid.Row="0" Height="400" Width="650" HorizontalAlignment="Center" VerticalAlignment="Center" Loaded="EmployeekageCode_Loaded*/
    }
}
