﻿using P1_AP1_Nachely_20190734.UI.Consultas;
using P1_AP1_Nachely_20190734.UI.Registros;
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

namespace P1_AP1_Nachely_20190734
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAportes registro = new rAportes();
            registro.Show();
        }

        private void ConsultaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAportes consulta = new cAportes();
            consulta.Show();
        }
    }
}
