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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimPart1.UC_OtherAnima.Pipes
{
    /// <summary>
    /// Interaction logic for UserControlBluePipes.xaml
    /// </summary>
    public partial class UserControlBluePipes : UserControl
    {
        private bool _isFPUValveOpen = false;
        private bool _isPFUValveOpen = true;
        Storyboard piplePulses;
        private Storyboard blinkAnimation;

        public UserControlBluePipes()
        {
            InitializeComponent();

            StartPippeAnimation();

            blinkAnimation = (Storyboard)this.Resources["blinkAnimation"];
            StartBlinking(); // Start blinking on load

        }

        private void StartPippeAnimation()
        {
            piplePulses = (Storyboard)this.Resources["pulse1Animation"];
            piplePulses.Begin();

        }

        public void StartBlinking()
        {
            blinkAnimation.Begin();
        }

        public void StopBlinking()
        {
            blinkAnimation.Stop();
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            if (_isPFUValveOpen)
            {

                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulseX1.Visibility = Visibility.Collapsed;
                svgViewboxPulse5.Visibility = Visibility.Collapsed;

                            blinkAnimation.Stop();

            }
            else
            {
                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulseX1.Visibility=Visibility.Visible;
                svgViewboxPulse5.Visibility = Visibility.Visible;

                piplePulses.Begin();
                blinkAnimation.Begin();


            }

            _isPFUValveOpen = !_isPFUValveOpen;

            if (!_isPFUValveOpen && !_isFPUValveOpen)
            {

                piplePulses.Stop();
            }

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!_isFPUValveOpen)
            {

                svgViewBoxLowervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulse4.Visibility = Visibility.Visible;
                svgViewboxPulse3.Visibility = Visibility.Visible;

                piplePulses.Begin();

            }
            else
            {
                svgViewBoxLowervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulse4.Visibility= Visibility.Collapsed;
                svgViewboxPulse3.Visibility = Visibility.Collapsed;


            }

            _isFPUValveOpen = !_isFPUValveOpen;

            if (!_isPFUValveOpen && !_isFPUValveOpen)
            {

                piplePulses.Stop();
            }
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var contextMenu = (ContextMenu)this.Resources["ContextMenu1"];

            foreach (MenuItem item in contextMenu.Items)
            {
                item.Icon = "pack://application:,,,/Images/Remove.svg";

                if (item.Name == "menuItem1")
                {

                    if (_isFPUValveOpen)
                    {
                        item.Header = "Close FPU Valve";
                    }
                    else
                    {
                        item.Header = "Open FPU Valve";
                    }
                }
                else if (item.Name == "menuItem2")
                {

                    if (_isPFUValveOpen)
                    {
                        item.Header = "Close PFU Valve";
                    }
                    else
                    {
                        item.Header = "Open PFU Valve";
                    }

                }
              

            }

        }
    }
}
