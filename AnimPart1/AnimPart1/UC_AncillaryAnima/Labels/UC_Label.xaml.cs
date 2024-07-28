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

namespace AnimPart1.UC_AncillaryAnima.Label
{
    /// <summary>
    /// Interaction logic for UC_Label.xaml
    /// </summary>
    public partial class UC_Label : UserControl
    {
        public DispatcherTimer blinkTimerOperationOn;
        bool flag = false;
        public UC_Label()
        {
            InitializeComponent();

            svgViewboxLabelBackGround.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/labetFormat.svg");
            svgViewboxGeerIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/geerIcon.svg");
            svgViewboxWarningIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/warningIcon.svg");
            svgViewboxYellowIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/yellow2.svg");
            svgViewboxRedIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/red.svg");
            svgViewboxGreenIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/green.svg");

            svgViewboxGreenIcon.Visibility = Visibility.Hidden;
            svgViewboxWarningIcon.Visibility = Visibility.Hidden;
            svgViewboxGeerIcon.Visibility = Visibility.Hidden;
            svgViewboxGeerIcon.Visibility = Visibility.Hidden;

            // Initialize the timer for blinking for the yello
            blinkTimerOperationOn = new DispatcherTimer();
            blinkTimerOperationOn.Interval = TimeSpan.FromSeconds(0.5);
            blinkTimerOperationOn.Tick += BlinkTimerHopper_Tick;
            blinkTimerOperationOn.Start();
        }

        private void LabelIconCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Visibility = Visibility.Hidden;

        }

        private void BlinkTimerHopper_Tick(object sender, EventArgs e)
        {
          

            if (flag)
            {
                svgViewboxYellowIcon.Opacity = 0.7; 
                svgViewboxYellowIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/yellow2.svg");
            }
            else
            {
                svgViewboxYellowIcon.Opacity = 1;
                svgViewboxYellowIcon.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Labels/Images/yellow.svg");
            }

            flag = !flag;
        }
    }
}
