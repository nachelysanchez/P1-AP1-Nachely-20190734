using P1_AP1_Nachely_20190734.BLL;
using P1_AP1_Nachely_20190734.Entidades;
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
using System.Windows.Shapes;

namespace P1_AP1_Nachely_20190734.UI.Registros
{
    /// <summary>
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        public Aportes aporte = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aporte;
        }
        public void Limpiar()
        {
            this.aporte = new Aportes();
            this.DataContext = aporte;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aportes = AportesBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));
            if (aportes != null)
            {
                this.aporte = aportes;
            }
            else
            {
                this.aporte = new Aportes();
                MessageBox.Show("No se ha encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.aporte;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var paso = AportesBLL.Guardar(this.aporte);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se ha guardado exitosamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha guardado exitosamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se ha eliminado exitosamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha eliminado exitosamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
