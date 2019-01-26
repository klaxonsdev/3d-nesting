using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _3D_viewer
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public Calculation Calc = new Calculation();
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(WInput.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(LInput.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(HInput.Text))
            {
                return;
            }
            double PrintVolD = Calc.PrintVolCalc(Convert.ToDouble(LInput.Text), Convert.ToDouble(WInput.Text), Convert.ToDouble(HInput.Text));
            float PrintVolF = float.Parse(PrintVolD.ToString());
            VolText.Text = "Print Volume : "+ PrintVolF + " cm³";
            ((MainWindow)Application.Current.MainWindow).PrintVolStr = VolText.Text;
            ((MainWindow)Application.Current.MainWindow).PrintVol = PrintVolF;
            ((MainWindow)Application.Current.MainWindow).containerLength = Convert.ToDecimal(LInput.Text);
            ((MainWindow)Application.Current.MainWindow).containerWidth = Convert.ToDecimal(WInput.Text);
            ((MainWindow)Application.Current.MainWindow).containerHeight = Convert.ToDecimal(HInput.Text);
            this.Hide();
        }
    }
}
