using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.IO;
using Microsoft.Win32;
using QuantumConcepts.Formats.StereoLithography;
using System.Reflection;
using System.Linq;


namespace _3D_viewer_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ModelVisual3D device3D = new ModelVisual3D();
            //device3D.Content = Display3d(MODEL_PATH);
            // Add to view port
            
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
            if (openFileDialog.ShowDialog() == true)
            {
                string MODEL_PATHs = openFileDialog.FileName;
                ModelVisual3D device3D = new ModelVisual3D();
                device3D.Content = Display3d(MODEL_PATHs);
                Port3d.Children.Add(device3D);
                box.Clear();
                STLDocument model = new STLDocument();
                model = STLDocument.Open(MODEL_PATHs);
                for (int i = 0; i < model.Facets.Count; i++)
                {
                    box.AppendText($"Facet : {i} \n" + model.Facets[i].Normal.X.ToString() +";"+ model.Facets[i].Normal.Y.ToString() + ";" + model.Facets[i].Normal.Z.ToString() + "\n");
                    for (int j = 0; j < model.Facets[i].Vertices.Count; j++)
                    {
                        
                        box.AppendText(model.Facets[i].Vertices[j].X.ToString() +
                            ";" + model.Facets[i].Vertices[j].Y.ToString() +
                            ";" + model.Facets[i].Vertices[j].Z.ToString() +"\n");


                    }
                    
                }
            }

        }

        public double SignedVolumeOfTriangle(Vector3D p1, Vector3D p2, Vector3D p3)
        {
            var v321 = p3.X * p2.Y * p1.Z;
            var v231 = p2.X * p3.Y * p1.Z;
            var v312 = p3.X * p1.Y * p2.Z;
            var v132 = p1.X * p3.Y * p2.Z;
            var v213 = p2.X * p1.Y * p3.Z;
            var v123 = p1.X * p2.Y * p3.Z;
            return (1.0 / 6.0) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }

        //public double VolumeOfMesh(STLDocument model)
        //{
        //    var vols = from t in model.Facets[1]
        //               select SignedVolumeOfTriangle(t.P1, t.P2, t.P3);
        //    return Math.Abs(vols.Sum());
        //}

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
       
    }

    
}
