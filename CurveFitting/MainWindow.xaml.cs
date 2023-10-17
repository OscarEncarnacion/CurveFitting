using CurveFitting.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CurveFitting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Actualizar este data set si se desea analizar otro
        private static readonly List<(float, float)> dataSet = new()
        {
            (23f, 651f),
            (26f, 762f),
            (30f, 856f),
            (34f, 1063f),
            (43f, 1190f),
            (48f, 1298f),
            (52f, 1421f),
            (57f, 1440f),
            (58f, 1518f)
        };
        private Generador generador = new(dataSet);

        public MainWindow()
        {
            InitializeComponent();
            LlenarControles();
        }

        private void LlenarControles()
        {
            ecuacionTextBox.Text = generador.Ecuacion;
            dataSetView.Text = "\nAdvertising\tSales\n";
            foreach ((float advertising, float sales) in dataSet)
            {
                dataSetView.Text += $"{advertising}\t\t{sales}\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(advertisingTextBox.Text, out float advertising))
            {
                float sales = generador.PredictSales(advertising);
                salesTextBox.Text = sales.ToString();
            }
            else
            {
                MessageBox.Show("El valor ingresado no es valido.");
            }
        }
    }
}
