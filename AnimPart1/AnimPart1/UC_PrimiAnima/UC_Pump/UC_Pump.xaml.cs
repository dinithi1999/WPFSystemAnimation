using AnimPart1.UC_AncillaryAnima.Label;
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
using AnimPart1.UC_AncillaryAnima.ScrewRotation;

using System.Reflection.Metadata;
using System.Windows.Media.Animation;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.HBYRotation;

namespace AnimPart1.UC_PrimiAnima.UC_Pump
{
    /// <summary>
    /// Interaction logic for UC_Pump.xaml
    /// </summary>
    public partial class UC_Pump : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;

        public UC_Label labelUserCtrl;
        private bool isCameraOn;

        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "PMP-XXX";
        public bool isLightOn;
        public bool isAnimationOngoing;

        public static readonly RoutedUICommand PumpLighCommand = new RoutedUICommand("", "PumpLighCommand", typeof(UC_Pump));
        public static readonly RoutedUICommand PumpCameraCommand = new RoutedUICommand("", "PumpCameraCommand", typeof(UC_Pump));
        //public static readonly RoutedUICommand HBYOpenValveCommand = new RoutedUICommand("", "HBYOpenValveCommand", typeof(UC_Pump));
        public static readonly RoutedUICommand PumpStartAimationCameraCommand = new RoutedUICommand("", "PumpStartAimationCameraCommand", typeof(UC_Pump));

        public UC_Pump()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;
      
            uC_ScrewRotation = new UC_ScrewRotation();
            PadleColumn.Content = uC_ScrewRotation;

            labelUserCtrl2 = new UC_PrimiLabel();
            labelColumn2.Content = labelUserCtrl2;

            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;

            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Pump/Images/pumpMarqueesvg.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Pump/Images/pumpFixedSection.svg");

            CommandBindings.Add(new CommandBinding(PumpLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(PumpCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(HBYOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(PumpStartAimationCameraCommand, Option4_Click));

        }


        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer4.Start();
            }
            else
            {
                MainWindow.blinkTimer4.Stop();
                cameraUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg");

            }

            isCameraOn = !isCameraOn;
        }


        private void Option3_Click(object sender, RoutedEventArgs e)
        {

            //if (!IsValveOpen)
            //{

            //    svgViewboxValve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveOpened.svg");
            //}
            //else
            //{
            //    svgViewboxValve.Source = new Uri("pack://application:,,,/UC_OtherAnima/PFUAnimation/Images/valveClosed.svg");
            //}

            //IsValveOpen = !IsValveOpen;

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
            backgroundSvg.Visibility = Visibility.Visible;
            this.Focus();
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
                        item.Icon = "pack://application:,,,/Images/lightOn.svg";

                    }
                    else
                    {
                        item.Header = "Light on";
                        item.Icon = "pack://application:,,,/Images/lightOn.svg";

                    }
                }
                else if (item.Name == "menuItem2")
                {
                    if (isCameraOn)
                    {

                        item.Header = "Camera Off";
                        item.Icon = "pack://application:,,,/Images/Camera.svg";


                    }
                    else
                    {
                        item.Header = "Camera On";
                        item.Icon = "pack://application:,,,/Images/Camera.svg";

                    }
                }
                else if (item.Name == "menuItem4")
                {
                    if (isAnimationOngoing)
                    {

                        item.Header = "Stop Spinning";
                        item.Icon = "pack://application:,,,/Images/Stop.svg";


                    }
                    else
                    {
                        item.Header = "Start Spinning";
                        item.Icon = "pack://application:,,,/Images/Start.svg";

                    }

                }

            }

            contextMenu.IsOpen = true;
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            ToggleLight();

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
            uC_ScrewRotation.StartSpinning();
            isAnimationOngoing = true;
        }

        public void StopSpinning()
        {
            uC_ScrewRotation.StopSpinning();
            isAnimationOngoing = false;

        }

        public void SetRotationDirection(bool clockwise)
        {
            uC_ScrewRotation.SetRotationDirection(clockwise);
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
