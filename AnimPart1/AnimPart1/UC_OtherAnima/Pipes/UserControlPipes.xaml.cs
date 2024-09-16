using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        Storyboard piplePulses;
        private Storyboard storyboard;

        private Storyboard blinkAnimation;
        private bool pulse2Started = false;
        private bool pulse3Started = false;
        private bool pulse4Started = false;
        private bool pulse5Started = false;
        private bool pulse6Started = false;
        private bool pulse7Started = false;

        public UserControlPipes()
        {
            InitializeComponent();




            blinkAnimation = (Storyboard)this.Resources["blinkAnimation"];
            CompositionTarget.Rendering += OnRendering;
            StartPulseAnimation("translatePulse1", "pulse1Animation");
            StartBlinking();

        }

        private bool pulseX1Started = false;
        private bool pulseX2Started = false;
        private bool pulseX3Started = false;
        private bool pulseY1Started = false;

        private void OnRendering(object sender, EventArgs e)
        {
            if (translatePulse1.Y >= 250 && !pulse2Started)
            {
                pulse2Started = true;
                StartPulseAnimation("translatePulse2", "pulse2Animation");
            }
            if (translatePulse2.Y >= 250 && !pulse3Started)
            {
                pulse3Started = true;
                StartPulseAnimation("translatePulse3", "pulse3Animation");
            }
            if (translatePulse3.Y >= 250 && !pulse4Started)
            {
                pulse4Started = true;
                StartPulseAnimation("translatePulse4", "pulse4Animation");
            }
            if (translatePulse4.Y >= 250 && !pulse5Started)
            {
                pulse5Started = true;
                StartPulseAnimation("translatePulse5", "pulse5Animation");
            }
            if (translatePulse5.Y >= 250 && !pulse6Started)
            {
                pulse6Started = true;
                StartPulseAnimation("translatePulse6", "pulse6Animation");
            }
            if (translatePulse6.Y >= 250 && !pulse7Started)
            {
                pulse7Started = true;
                StartPulseAnimation("translatePulse7", "pulse7Animation");
            }
            if (translatePulse7.Y >= 1 && !pulseX1Started)
            {
                pulseX1Started = true;
                svgViewboxPulseX1.Visibility = Visibility.Visible;
                svgViewboxPulseX2.Visibility = Visibility.Visible;
                svgViewboxPulseY1.Visibility = Visibility.Visible;
                StartPulseAnimation("translatePulseX1", "pulseX1Animation");
            }
            if (translatePulseX1.X >= 120 & !pulseX2Started)
            {
                pulseX2Started = true;
                StartPulseAnimation("translatePulseX2", "pulseX2Animation");
            }
            if (translatePulseX2.X >= 120 && !pulseX3Started)
            {
                pulseX3Started = true;
                svgViewboxPulseY1.Visibility = Visibility.Visible;

                StartPulseAnimation("translatePulseY1", "pulseY1Animation");
            }
          
        }

        private void StartPulseAnimation(string targetName, string storyboardKey)
        {
            storyboard = (Storyboard)FindResource(storyboardKey);
            foreach (var animation in storyboard.Children)
            {
                if (Storyboard.GetTargetName(animation) == targetName)
                {
                    storyboard.Begin();
                    break;
                }
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


        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            OperateValve();

        }

        private void OperateValve()
        {
            if (_isFPUValveOpen)//current state, but user say need to close the valve
            {

                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
                svgViewboxPulseY1.Visibility = Visibility.Collapsed;
                svgViewboxPulseX3.Visibility = Visibility.Collapsed;
                svgViewboxPulseX2.Visibility = Visibility.Collapsed;
                svgViewboxPulseX1.Visibility = Visibility.Collapsed;
                svgViewboxPulseX3.Visibility = Visibility.Visible;
                svgViewboxPulseX4.Visibility = Visibility.Visible;
                PauseAnimations("translatePulse1", "translatePulse2", "translatePulse3", "translatePulse4", "translatePulse5", "translatePulse6", "translatePulse7", "translatePulseX1", "translatePulseX2");
                StopBlinking();
            }
            else //current state is closed , but user say need to open the valve
            {
                svgViewBoxUppervalve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
                svgViewboxPulseY1.Visibility = Visibility.Visible;
                svgViewboxPulseX2.Visibility = Visibility.Visible;
                svgViewboxPulseX2.Visibility = Visibility.Visible;
                svgViewboxPulseX1.Visibility = Visibility.Visible;
                svgViewboxPulseX3.Visibility = Visibility.Collapsed;
                svgViewboxPulseX4.Visibility = Visibility.Collapsed;
                ResumeAnimations("translatePulse1", "translatePulse2", "translatePulse3", "translatePulse4", "translatePulse5", "translatePulse6", "translatePulse7", "translatePulseX1", "translatePulseX2");
                StartBlinking();
            }

            _isFPUValveOpen = !_isFPUValveOpen;
        }
    }
}
