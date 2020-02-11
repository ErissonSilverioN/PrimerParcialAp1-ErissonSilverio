using PrimerParcial_Aplicada1.BLL;
using PrimerParcial_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrimerParcial_Aplicada1.UI
{
    /// <summary>
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        public rArticulos()
        {
            InitializeComponent();
            idTextBox.Text = "0";
        }


        private void LimpiarObj()
        {
            descripcionTextBox.Text = string.Empty;
            existenciaTextBox.Text = string.Empty;
            costoTextBox.Text = string.Empty;
            valorinvTextBox.Text = string.Empty;
            idTextBox.Text = "0";
            
        }


        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();

            articulos.ProductoId = Convert.ToInt32(idTextBox.Text);
            articulos.Existencia = Convert.ToDecimal(existenciaTextBox.Text);
            articulos.Descripcion = descripcionTextBox.Text;
            articulos.Costo = Convert.ToDecimal(costoTextBox.Text);
           // articulos.ValorInventario = Convert.ToDecimal(valorinvTextBox.Text);

            return articulos;
        }


        private void LlenaCampo(Articulos articulos)
        {
            idTextBox.Text = Convert.ToString(articulos.ProductoId);
            descripcionTextBox.Text = articulos.Descripcion;
            costoTextBox.Text = Convert.ToString(articulos.Costo);
            existenciaTextBox.Text = Convert.ToString(articulos.Existencia);
           // valorinvTextBox.Text = Convert.ToString(articulos.ValorInventario);
        }

        private bool ExisteEnLaBaseDatos()
        {
            Articulos articulos = ArticuloBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (articulos != null);
        }


        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("El campo Descripcion es Obligatorio!!!");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(existenciaTextBox.Text))
            {
                MessageBox.Show("El campo Existencia es Obligatorio!!!");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(costoTextBox.Text))
            {
                MessageBox.Show("El campo Costo es Obligatorio!!!");
                paso = false;
            }

            

            return paso;

        }

        private void idTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void existenciaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void costoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos;
            bool paso = false;

            if (!ValidarCampos())
                return;

            articulos = LlenaClase();

            if (idTextBox.Text == "0")
                paso = ArticuloBLL.Guardar(articulos);
            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("El Producto No Existe En La Base Datos!!!");

                }

                MessageBox.Show("Articulo Modificado!!!");
                    paso = ArticuloBLL.Modificar(articulos);
            }

            if (paso)
            {
                MessageBox.Show("Se Guardo El Articulo!!!");
                LimpiarObj();
            }
            else
            {
                MessageBox.Show("No Se Pudo Guardar!!!");
            }


        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarObj();
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(idTextBox.Text, out id);
            Articulos articulos = new Articulos();

            articulos = ArticuloBLL.Buscar(id);

            if (articulos != null)
            {
                MessageBox.Show("Articulo Encontrado!!!");
                LlenaCampo(articulos);
            }
            else
            {
                MessageBox.Show("No Se Encontro!!!");
            }
            
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(idTextBox.Text, out id);

            if (ArticuloBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!!");
                LimpiarObj();

            }
            else
            {
                MessageBox.Show("No Se Elimino");
            }
        }

        public void Calcular()
        {
            
            decimal costo = Convert.ToDecimal(costoTextBox.Text);
            decimal existencia = Convert.ToDecimal(existenciaTextBox.Text);

           decimal Calculo = (costo * existencia);

            
        }

        private void valorinvTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            Calcular();

        }

        private void costoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }
    }
}
