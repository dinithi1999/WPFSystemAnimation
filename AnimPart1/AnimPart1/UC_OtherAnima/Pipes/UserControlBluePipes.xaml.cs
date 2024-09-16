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
using System.Windows.Threading;

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
        private Storyboard pulse1Animation;
        private Storyboard pulse2Animation;
        private Storyboard pulse3Animation;
        private Storyboard pulse4Animation;
        private Storyboard pulse5Animation;
        private Storyboard pulseX1Animation;
        private DispatcherTimer animationCheckTimer;

        public UserControlBluePipes()
        {
            InitializeComponent();

            StartPippeAnimation();

            blinkAnimation = (Storyboard)this.Resources["blinkAnimation"];
            StartBlinking(); // Start blinking on load

            // Initialize and start the DispatcherTimer
            animationCheckTimer = new DispatcherTimer();
            animationCheckTimer.Interval = TimeSpan.FromMilliseconds(100); // Check every 100ms
            animationCheckTimer.Tick += AnimationCheckTimer_Tick;
            animationCheckTimer.Start();

        }

        private void StartPippeAnimation()
        {
            pulse1Animation = (Storyboard)this.Resources["pulse1Animation"];
            pulse2Animation = (Storyboard)this.Resources["pulse2Animation"];
            pulse3Animation = (Storyboard)this.Resources["pulse3Animation"];
            pulse4Animation = (Storyboard)this.Resources["pulse4Animation"];
            pulse5Animation = (Storyboard)this.Resources["pulse5Animation"];
            pulseX1Animation = (Storyboard)this.Resources["pulseX1Animation"];

            pulse1Animation.Begin();
            pulse5Animation.Begin();
            pulseX1Animation.Begin();


        }

        private void AnimationCheckTimer_Tick(object sender, EventArgs e)
        {
            // Check if translatePulse1 has traveled 100 units
            if (translatePulse1.Y >= 150)
            {
                // Start pulse2Animation
                pulse2Animation.Begin();
               

                // Stop the timer as we only need to start pulse2Animation once
                animationCheckTimer.Stop();
            }
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

                blinkAnimation.Begin();
                animationCheckTimer.Start();

                pulse1Animation.Begin();


            }

            _isPFUValveOpen = !_isPFUValveOpen;

            if (!_isPFUValveOpen && !_isFPUValveOpen)
            {
                PauseAnimations("translatePulse1", "translatePulse2");
            }

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!_isFPUValveOpen)
            {

                svgViewBoxLowervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulse4.Visibility = Visibility.Collapsed;
                svgViewboxPulse3.Visibility = Visibility.Visible;

                pulse3Animation.Begin();

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

                PauseAnimations("translatePulse1", "translatePulse2");
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


        public void PauseAnimations(params string[] targetNames)
        {
            foreach (var targetName in targetNames)
            {
                foreach (var storyboardKey in this.Resources.Keys)
                {
                    if (this.Resources[storyboardKey] is Storyboard storyboard)
                    {
                        foreach (var animation in storyboard.Children)
                        {
                            if (Storyboard.GetTargetName(animation) == targetName)
                            {
                                storyboard.Pause();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void ResumeAnimations(params string[] targetNames)
        {
            foreach (var targetName in targetNames)
            {
                foreach (var storyboardKey in this.Resources.Keys)
                {
                    if (this.Resources[storyboardKey] is Storyboard storyboard)
                    {
                        foreach (var animation in storyboard.Children)
                        {
                            if (Storyboard.GetTargetName(animation) == targetName)
                            {
                                storyboard.Resume();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
