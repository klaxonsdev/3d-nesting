﻿using HelixToolkit.Wpf;
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
using CromulentBisgetti.ContainerPacking.Entities;


namespace _3D_viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        ModelVisual3D device3D = new ModelVisual3D();
        List<Container> containers = new List<Container>();
        public float PrintVol = 0;
        float TotModVol = 0;
        float availvol = 0;
        public string PrintVolStr;
        decimal containerLength = 0;
        decimal containerWidth = 0;
        decimal containerHeight = 0;
        public MainWindow()
        {
            InitializeComponent();
            SettingWindow sett = new SettingWindow();
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
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                Calculation Calc = new Calculation();
                STLDocument model = new STLDocument();
                List<Model> modelFiles = new List<Model>();
                List<Item> itemToPack = new List<Item>();

                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    model = STLDocument.Open(openFileDialog.FileNames[i]);
                    modelFiles.Add(new Model() { Name = openFileDialog.SafeFileNames[i], Vol = Calc.VolumeOfMesh(model).ToString() + " cm³", ModelPath = openFileDialog.FileNames[i]});
                    TotModVol = TotModVol + Calc.VolumeOfMesh(model);
                    itemToPack.Add(new Item(i,Convert.ToDecimal(Calc.getBoundingBox()[0]), Convert.ToDecimal(Calc.getBoundingBox()[1]), Convert.ToDecimal(Calc.getBoundingBox()[2]), 1));
                }                     
                lvModel.ItemsSource = modelFiles;
                ModelTotText.Text = "Total Model: " + openFileDialog.FileNames.Length.ToString();
                ModelVolText.Text = "3D Model Volume: " + TotModVol + " cm³";
                availvol = PrintVol - TotModVol;
                AvailVolText.Text = "Available Volume: "+ availvol.ToString()+ " cm³";
            }
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
            if (lvModel.SelectedItems.Count == 0)
            {
                return;
            }
            int index = lvModel.SelectedIndex;
            Port3d.Children.Remove(device3D);
            device3D.Content = Display3d(openFileDialog.FileNames[index]);
            Port3d.Children.Add(device3D);
            STLDocument model = new STLDocument();
            model = STLDocument.Open(openFileDialog.FileNames[index]);
            Calculation bounding = new Calculation();
            bounding.VolumeOfMesh(model);
            BoundingText.Text = "Model Bounding Box : "+ bounding.getBoundingBox()[0].ToString()+"  "+ bounding.getBoundingBox()[1].ToString()+ "  "+ bounding.getBoundingBox()[2].ToString();
        }

        private void Settingbtn_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
            PrintVolText.Text = PrintVolStr;
        }

        private void Calcbtn_Click(object sender, RoutedEventArgs e)
        {
            availvol = PrintVol - TotModVol;
            AvailVolText.Text = "Available Volume: " + availvol.ToString() + " cm³";
        }

        private void MeshSimbtn_Click(object sender, RoutedEventArgs e)
        {
            SimplificationWindow simplificationWindow = new SimplificationWindow();
            simplificationWindow.ShowDialog();

        }
    }

    
}
