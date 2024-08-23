using AnimPart1.UC_AncillaryAnima.DownArrow;
using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using AnimPart1.UC_OtherAnima.PFUAnimation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.HBYRotation
{
    /// <summary>
    /// Interaction logic for UC_HBYAnimation.xaml
    /// </summary>
    public partial class UC_HBYAnimation : UserControl
    {
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl;
        public UC_Label labelUserCtrl;

     
        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "HBY-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        public bool isAnimationOngoing;

        public static readonly RoutedUICommand HBYLighCommand = new RoutedUICommand("", "HBYLighCommand", typeof(UC_HBYAnimation));
        public static readonly RoutedUICommand HBYCameraCommand = new RoutedUICommand("", "HBYCameraCommand", typeof(UC_HBYAnimation));
        //public static readonly RoutedUICommand HBYOpenValveCommand = new RoutedUICommand("", "HBYOpenValveCommand", typeof(UC_HBYAnimation));
        public static readonly RoutedUICommand HBYStartAimationCameraCommand = new RoutedUICommand("", "HBYStartAimationCameraCommand", typeof(UC_HBYAnimation));


        public UC_HBYAnimation()
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
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/HBYRotation/Images/HoldBayboader.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/HBYRotation/Images/hallbayBackground.svg");

            uC_ScrewRotation = new UC_ScrewRotation();
            PadleColumn.Content = uC_ScrewRotation;
            uC_ScrewRotation.backgroundSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/HBYRotation/Images/HalbayRotationalSection.svg");


            CommandBindings.Add(new CommandBinding(HBYLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(HBYCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(HBYOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(HBYStartAimationCameraCommand, Option4_Click));
        }

     
        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer9.Start();
            }
            else
            {
                MainWindow.blinkTimer9.Stop();

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
                //else if (item.Name == "menuItem3")
                //{
                //    if (IsValveOpen)
                //    {

                //        item.Header = "Close Valve";

                //    }
                //    else
                //    {
                //        item.Header = "Open Valve";
                //    }

                //}
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

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedColor = selectedItem.Content.ToString();

                // Display the selected color in the TextBox
                colorComboBox.Text = selectedColor;

                if (uC_ScrewRotation.isAntiClockWise)
                {
                    uC_ScrewRotation.rotateFrom = 0;
                }
                else
                {
                    uC_ScrewRotation.rotateFrom = 0;
                }

                // Use a switch case to handle different colors
                switch (selectedColor)
                {
                    case "Red":

                        uC_ScrewRotation.rotateT0 = 0;

                       

                        break;

                    case "Yellow":

                        
                            uC_ScrewRotation.rotateT0 = 70;

                        
                        break;

                    case "Green":

                       
                            uC_ScrewRotation.rotateT0 = 140;

                        break;

                    case "Pink":

                       
                            uC_ScrewRotation.rotateT0 = 220;

                        break;

                    case "Blue":

                            uC_ScrewRotation.rotateT0 = 290;
                        break;

                    default:
                        // Handle any other cases if necessary
                        break;
                }
            }
        }

    }
}
