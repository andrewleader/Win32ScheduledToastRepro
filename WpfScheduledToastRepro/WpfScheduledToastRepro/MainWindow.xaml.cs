using Microsoft.Toolkit.Uwp.Notifications;
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

namespace WpfScheduledToastRepro
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

        private bool _hasNormalToastBeenSent;

        private void ButtonPopToast_Click(object sender, RoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddText("Basic toast notification")
                .Show();

            _hasNormalToastBeenSent = true;
        }

        private void ButtonScheduleToast_Click(object sender, RoutedEventArgs e)
        {
            if (!_hasNormalToastBeenSent)
            {
                MessageBox.Show("You must pop a non-scheduled toast first.");
                return;
            }

            try
            {
                new ToastContentBuilder()
                    .AddText("Scheduled toast notification")
                    .Schedule(DateTime.Now.AddSeconds(5));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
