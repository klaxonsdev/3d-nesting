using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.IO;
using Microsoft.Win32;
using QuantumConcepts.Formats.StereoLithography;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace _3D_viewer_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Model> modelFiles = new List<Model>();
        public MainWindow()
        {

            InitializeComponent();
        }
        public class Model
        {
            public string Name { get; set; }
            public string Vol { get; set; }
            public string ModelPath { get; set; }
        }

        private Model3D Display3d(string model)
        {
            Model3D device = null;
            try
            {
                //Adding a gesture here
                Port3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                device = import.Load(model);
            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            return device;
            
        }
        private void OpenFile_Click (object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                STLDocument model = new STLDocument();
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    model = STLDocument.Open(openFileDialog.FileNames[i]);
                    modelFiles.Add(new Model() { Name = openFileDialog.SafeFileNames[i], Vol = VolumeOfMesh(model).ToString() + " Cubic ml" ,ModelPath = openFileDialog.FileNames[i]});
                }
                        
                lvModel.ItemsSource = modelFiles;                       
            }
        }

        public float SignedVolumeOfTriangle(Vertex p1, Vertex p2, Vertex p3)
        {
            var v321 = p3.X * p2.Y * p1.Z;
            var v231 = p2.X * p3.Y * p1.Z;
            var v312 = p3.X * p1.Y * p2.Z;
            var v132 = p1.X * p3.Y * p2.Z;
            var v213 = p2.X * p1.Y * p3.Z;
            var v123 = p1.X * p2.Y * p3.Z;
            return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }

        public float VolumeOfMesh(STLDocument model)
        {
            var vol = 0.0f;
            foreach (var item in model.Facets)
            {
                vol = vol + SignedVolumeOfTriangle(item.Vertices[0], item.Vertices[1], item.Vertices[2]);
            }
            return vol;
        }


        public void FromFile()
        {
            STLDocument stl = null;

            using (Stream inStream = GetData("ASCII.stl"))
            {
                string tempFilePath = Path.GetTempFileName();

                using (var outStream = File.Create(tempFilePath))
                {
                    inStream.CopyTo(outStream);
                }

                stl = STLDocument.Open(tempFilePath);

                try
                {
                    File.Delete(tempFilePath);
                }
                catch { /* Ignore. */ }
            }

        }
        private Stream GetData(string filename)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream("QuantumConcepts.Formats.StereoLithography.Test.Data.{0}".Interpolate(filename));
        }

        private void ListView_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
  
            ModelVisual3D device3D = new ModelVisual3D();
            device3D.Content = Display3d();
            Port3d.Children.Add(device3D);
            box.Clear();
            STLDocument model = new STLDocument();
            model = STLDocument.Open(file);

        }
    }

    
}
