using AnimPart1.UC_AncillaryAnima.Label;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_PrimiAnima
{
    /// <summary>
    /// Interaction logic for UC_Portioner.xaml
    /// </summary>
    public partial class UC_Portioner : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;

        public UC_Label labelUserCtrl;

        public string labelName = "POR-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        private bool isMaterialRemoved;

        public static readonly RoutedUICommand PORLighCommand = new RoutedUICommand("Option 1", "PORLighCommand", typeof(UC_Portioner));
        public static readonly RoutedUICommand PORCameraCommand = new RoutedUICommand("Option 2", "PORCameraCommand", typeof(UC_Portioner));
        public static readonly RoutedUICommand PORStartAimationCameraCommand = new RoutedUICommand("Option 2", "PORStartAimationCameraCommand", typeof(UC_Portioner));

        public UC_Portioner()
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
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portionerMarquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg");

            StartAnimations();

            CommandBindings.Add(new CommandBinding(PORLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(PORCameraCommand, Option2_Click));
            CommandBindings.Add(new CommandBinding(PORStartAimationCameraCommand, Option3_Click));


        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            ToggleLight();
        }


        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer7.Start();
            }
            else
            {
                MainWindow.blinkTimer7.Stop();
                cameraUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg");
            }

            isCameraOn = !isCameraOn;
        }


        private void Option3_Click(object sender, RoutedEventArgs e)
        {

            if (!isMaterialRemoved)
            {

                svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner90.svg");
            }
            else
            {
                svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg");
            }

            isMaterialRemoved = !isMaterialRemoved;

        }


        private void Option4_Click(object sender, RoutedEventArgs e)
        {

            //if (!isAnimationOngoing)
            //{

            //    StartSpinning();
            //}
            //else
            //{
            //    StopSpinning();
            //}
        }

        public void StartAnimations()
        {
            var secondOrangeBallFallingAnimation = (Storyboard)this.Resources["GreenArrowDown"];
            secondOrangeBallFallingAnimation.Begin();
        }


        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
            this.Focus();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
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

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var contextMenu = (ContextMenu)this.Resources["ContextMenu1"];

            foreach (MenuItem item in contextMenu.Items)
            {
                if (item.Name == "menuItem1")
                {
                    item.Header = "Updated Option 1"; // Update header text

                    if (isLightOn)
                    {
                        item.Header = "Light Off"; // Update header text
                    }
                    else
                    {
                        item.Header = "Light on"; // Update header text
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
                    if (isMaterialRemoved)
                    {

                        item.Header = "Set Initial Position";

                    }
                    else
                    {
                        item.Header = "Remove Material";
                    }

                }

            }

            contextMenu.IsOpen = true;
        }

        //private void Option1_Click(object sender, RoutedEventArgs e)
        //{
        //    ToggleLight();
        //}
    }
}
