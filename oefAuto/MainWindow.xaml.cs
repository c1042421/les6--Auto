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

namespace oefAuto
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

        private Auto a;
        private DispatcherTimer timer;

        private void a_AutoGestartEvent(Auto sender)
        {
            timer.Start();
        }

        private void a_AutoGestopEvent(Auto sender)
        {
            timer.Stop();
        }

        private void a_TankBijnaOpEvent(Auto sender)
        {
            wdwAuto.Background = new SolidColorBrush(Color.FromRgb(255, 165, 0));
        }

        private void a_TankChangeEvent(Auto sender)
        {
            lblAuto.Content = a.ToString();
        }

        private void a_TankOpEvent(Auto sender)
        {
            wdwAuto.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            MessageBox.Show("Tank is op!");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            a.LitersInTank = a.LitersInTank - 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer(TimeSpan.FromSeconds(1),DispatcherPriority.Normal, timer_Tick, Dispatcher.CurrentDispatcher);

            a = new Auto(14);
            a.AutoGestartEvent += a_AutoGestartEvent;
            a.AutoGestoptEvent += a_AutoGestopEvent;
            a.TankBijnaOpEvent += a_TankBijnaOpEvent;
            a.TankChangeEvent += a_TankChangeEvent;
            a.TankOpEvent += a_TankOpEvent;
            a.Snelheid = 50;
        }
    }
}
