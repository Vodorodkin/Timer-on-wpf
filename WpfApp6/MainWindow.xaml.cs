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
using System.Windows.Threading;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime startTime, pauseTime;
        TimeSpan pauseSpan;
        DispatcherTimer timer1 = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;

        }
        void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            TimeSpan s = DateTime.Now - startTime - pauseSpan;
            label1.Text = string.Format("{0}:{1}", s.Minutes * 60 + s.Seconds, s.Milliseconds / 100);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.Items.Clear();
            ComboBox1.Items.Clear();
            ListBox1.SelectedIndex = ListBox1.Items.Add("Результаты");
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void ComboBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ComboBox1.SelectedIndex = ComboBox1.Items.Add(Convert.ToString(ComboBox1.Text));
            }
        }

        private void ComboBox1_PreviewKeyUp(object sender, KeyEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToString(button1.Content)=="Start")
            {
                startTime = DateTime.Now;
                pauseSpan = TimeSpan.Zero;
                timer1.Interval = TimeSpan.FromMilliseconds(100);
                timer1_Tick(null, null);
                timer1.IsEnabled = true;
                button1.Content = Convert.ToString("Stop");
            }
            else
            {
                ListBox1.SelectedIndex = ListBox1.Items.Add(label1.Text+Convert.ToString(ComboBox1.Text));
                timer1.IsEnabled = false;
                pauseTime = startTime;
                pauseSpan = TimeSpan.Zero;
                label1.Text = "0:0";
                button1.Content = Convert.ToString("Start");
            }
        }
    }
}
