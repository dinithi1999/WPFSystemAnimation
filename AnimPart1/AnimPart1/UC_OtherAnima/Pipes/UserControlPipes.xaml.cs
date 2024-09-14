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
    /// Interaction logic for UserControlPipes.xaml
    /// </summary>
    public partial class UserControlPipes : UserControl
    {

        private bool _isFPUValveOpen = true;

        public UserControlPipes()
        {
            InitializeComponent();


            StartPippeAnimation();
        }


        private void StartPippeAnimation()
        {
            var piplePulses = (Storyboard)this.Resources["pulse1Animation"];
            piplePulses.Begin();
         
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


            }

        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {


            if (_isFPUValveOpen)
            {

                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulseY1.Visibility = Visibility.Collapsed;
                svgViewboxPulseX3.Visibility = Visibility.Collapsed;
            }
            else
            {
                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulseY1.Visibility = Visibility.Visible;
                svgViewboxPulseX3.Visibility = Visibility.Visible;


            }

            _isFPUValveOpen = !_isFPUValveOpen;
        }
    }
}
