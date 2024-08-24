using AnimPart1.UC_AncillaryAnima.FPUAnimation;
using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
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

namespace AnimPart1.UC_OtherAnima.PFUAnimation
{
    /// <summary>
    /// Interaction logic for UC_PFUAnimation.xaml
    /// </summary>
    public partial class UC_PFUAnimation : UserControl
    {
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl;

        public UC_Label labelUserCtrl;


        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "PFU-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        public bool isAnimationOngoing;

        public static readonly RoutedUICommand PFULighCommand = new RoutedUICommand("", "PFULighCommand", typeof(UC_PFUAnimation));
        public static readonly RoutedUICommand PFUCameraCommand = new RoutedUICommand("", "PFUCameraCommand", typeof(UC_PFUAnimation));
        public static readonly RoutedUICommand PFUOpenValveCommand = new RoutedUICommand("", "PFUOpenValveCommand", typeof(UC_PFUAnimation));
        public static readonly RoutedUICommand PFUStartAimationCameraCommand = new RoutedUICommand("", "PFUStartAimationCameraCommand", typeof(UC_PFUAnimation));

        public bool IsValveOpen { get; private set; }

        public UC_PFUAnimation()
        {
            InitializeComponent();

           
            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;


            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/PrefinalBoarer.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/PrefinalBackground.svg");
            svgViewboxValve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");

            uC_ScrewRotation = new UC_ScrewRotation();

            PadleColumn.Content = uC_ScrewRotation;
            uC_ScrewRotation.backgroundStarsSvg.Visibility = Visibility.Visible;
            uC_ScrewRotation.backgroundSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/PrefinalRotationalPart.svg");
            uC_ScrewRotation.backgroundStarsSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/StartOnlyRotation.svg");

            CommandBindings.Add(new CommandBinding(PFULighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(PFUCameraCommand, Option2_Click));
            CommandBindings.Add(new CommandBinding(PFUOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(PFUStartAimationCameraCommand, Option4_Click));
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            ToggleLight();

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer10.Start();
            }
            else
            {
                MainWindow.blinkTimer10.Stop();
                cameraUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg");

            }

            isCameraOn = !isCameraOn;
        }


        private void Option3_Click(object sender, RoutedEventArgs e)
        {

            if (!IsValveOpen)
            {

                svgViewboxValve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
            }
            else
            {
                svgViewboxValve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
            }

            IsValveOpen = !IsValveOpen;

        }


        private void Option4_Click(object sender, RoutedEventArgs e)
        {

            if (!isAnimationOngoing)
            {

                StartSpinning();
            }
            else
            {
                StopSpinning();
            }
        }


        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Focus();
            backgroundSvg.Visibility = Visibility.Visible;
        }


        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
        }


        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var contextMenu = (ContextMenu)this.Resources["ContextMenu1"];

            foreach (MenuItem item in contextMenu.Items)
            {
                if (item.Name == "menuItem1")
                {

                    if (isLightOn)
                    {
                        item.Header = "Light Off";
                    }
                    else
                    {
                        item.Header = "Light on";
                    }
                }
                else if (item.Name == "menuItem2")
                {
                    if (isCameraOn)
                    {

                        item.Header = "Camera Off";

                    }
                    else
                    {
                        item.Header = "Camera On";
                    }
                }
                else if (item.Name == "menuItem3")
                {
                    if (IsValveOpen)
                    {

                        item.Header = "Close Valve";

                    }
                    else
                    {
                        item.Header = "Open Valve";
                    }

                }
                else if (item.Name == "menuItem4")
                {
                    if (isAnimationOngoing)
                    {

                        item.Header = "Stop Stirring";

                    }
                    else
                    {
                        item.Header = "Start Stirring";
                    }

                }

            }

            contextMenu.IsOpen = true;
        }

    

        private void ToggleLight()
        {
            if (isLightOn)
            {
                lightUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOff.svg");
                isLightOn = false;
            }
            else
            {
                lightUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOn.svg");
                isLightOn = true;
            }
        }

        public void StartSpinning()
        {
            uC_ScrewRotation.animation.RepeatBehavior = RepeatBehavior.Forever;
            uC_ScrewRotation.animation2.RepeatBehavior = RepeatBehavior.Forever;
            SetRotationDirection(false);

            uC_ScrewRotation.StartSpinning();
            isAnimationOngoing = true;
        }

        public void StopSpinning()
        {
            uC_ScrewRotation.StopSpinning();
            isAnimationOngoing = false;

        }

        public void SetRotationDirection(bool Anticlockwise)
        {
            uC_ScrewRotation.SetRotationDirection(Anticlockwise);
        }

        public void SetRotationSpeed(int percentage)
        {
            if (isAnimationOngoing)
            {
                uC_ScrewRotation.SetRotationSpeed(percentage);
            }
        }

      
    }
}
