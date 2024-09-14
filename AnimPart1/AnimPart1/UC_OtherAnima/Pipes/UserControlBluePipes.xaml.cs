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


        public UserControlBluePipes()
        {
            InitializeComponent();

            StartPippeAnimation();
        }

        private void StartPippeAnimation()
        {
            var piplePulses = (Storyboard)this.Resources["pulse1Animation"];
            piplePulses.Begin();

        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            if (_isPFUValveOpen)
            {

                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulseX1.Visibility = Visibility.Collapsed;
                svgViewboxPulse5.Visibility = Visibility.Collapsed;
            }
            else
            {
                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulseX1.Visibility=Visibility.Visible;
                svgViewboxPulse5.Visibility = Visibility.Visible;

            }

            _isPFUValveOpen = !_isPFUValveOpen;

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!_isFPUValveOpen)
            {

                svgViewBoxLowervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulse4.Visibility = Visibility.Visible;
            }
            else
            {
                svgViewBoxLowervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulse4.Visibility= Visibility.Collapsed;
            }

            _isFPUValveOpen = !_isFPUValveOpen;
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
