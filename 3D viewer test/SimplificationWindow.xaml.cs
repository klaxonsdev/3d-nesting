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
using System.IO;
using Microsoft.Win32;
using QuantumConcepts.Formats.StereoLithography;
using _3D_viewer;


namespace _3D_viewer
{
    /// <summary>
    /// Interaction logic for SimplificationWindow.xaml
    /// </summary>
    public partial class SimplificationWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public SimplificationWindow()
        {
            InitializeComponent();
        }

        private void OpenFilebtn_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog()==true)
            {
                STLDocument model = new STLDocument();
                model = STLDocument.Open(openFileDialog.FileName);
                Countbox.Text = "Triangle Count: "+ model.Facets.Count().ToString();
                TrianglesumBox.Text = model.Facets.Count().ToString();
            }
        }

        private void Reducerbtn_Click(object sender, RoutedEventArgs e)
        {
            MeshDecimator meshDecimator = new MeshDecimator();
            meshDecimator.MeshReducer(openFileDialog.FileName, int.Parse(TrianglesumBox.Text));
        }

        private void TriangleScroll_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
