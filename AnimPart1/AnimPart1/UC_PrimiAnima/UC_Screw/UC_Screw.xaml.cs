using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AnimPart1.UC_AncillaryAnima.Label;
using System.Windows.Media.Animation;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_OtherAnima.PFUAnimation;

namespace AnimPart1.UC_PrimiAnima.UC_Screw
{
    /// <summary>
    /// Interaction logic for UC_Screw.xaml
    /// </summary>
    public partial class UC_Screw : UserControl
    {

        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public UC_Label labelUserCtrl;

        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "SRW-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        public bool isAnimationOnGoing;

        public static readonly RoutedUICommand ScrewLighCommand = new RoutedUICommand("", "ScrewLighCommand", typeof(UC_Screw));
        public static readonly RoutedUICommand ScrewCameraCommand = new RoutedUICommand("", "ScrewCameraCommand", typeof(UC_Screw));
        //public static readonly RoutedUICommand ScrewOpenValveCommand = new RoutedUICommand("", "ScrewOpenValveCommand", typeof(UC_Screw));
        public static readonly RoutedUICommand ScrewStartAimationCameraCommand = new RoutedUICommand("", "ScrewStartAimationCameraCommand", typeof(UC_Screw));


        public UC_Screw()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;


            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            uC_ScrewRotation = new UC_ScrewRotation();
            PadleColumn.Content = uC_ScrewRotation;
            uC_ScrewRotation.backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwRotatingPart.svg");

            labelUserCtrl2 = new UC_PrimiLabel();
            labelColumn2.Content = labelUserCtrl2;


            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;

            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwmarquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwBackground.svg");

            CommandBindings.Add(new CommandBinding(ScrewLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(ScrewCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(ScrewOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(ScrewStartAimationCameraCommand, Option4_Click));

        }


        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer6.Start();
            }
            else
            {
                MainWindow.blinkTimer6.Stop();
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

            if (!isAnimationOnGoing)
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
                else if (item.Name == "menuItem4")
                {
                    if (isAnimationOnGoing)
                    {
                        item.Header = "Stop Spinning";
                    }
                    else
                    {
                        item.Header = "Start Spinning";
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
            isAnimationOnGoing = true;
        }

        public void StopSpinning()
        {
            uC_ScrewRotation.StopSpinning();
            isAnimationOnGoing = false;
        }

        public void SetRotationDirection(bool clockwise)
        {
            uC_ScrewRotation.SetRotationDirection(clockwise);
        }

        public void SetRotationSpeed(int percentage)
        {
            if (isAnimationOnGoing)
            {
                uC_ScrewRotation.SetRotationSpeed(percentage);
            }       
        }


    }
}
