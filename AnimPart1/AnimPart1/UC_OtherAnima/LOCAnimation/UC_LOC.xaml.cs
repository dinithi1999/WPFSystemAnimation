using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;


namespace AnimPart1.UC_OtherAnima.LOCAnimation
{
    /// <summary>
    /// Interaction logic for UC_LOC.xaml
    /// </summary>
    public partial class UC_LOC : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl2;

        public UC_Label labelUserCtrl;


        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "LOC-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        public bool isAnimationOngoing;

        Storyboard collectorMovement;
        DoubleAnimation collectorAnimation;

        Storyboard collectorCarrierTextMovement;
        DoubleAnimation collectorTEXTAnimation;

        double destinationXPos = 0;

        private bool isAnimationOnGoing;


        public static readonly RoutedUICommand LOCLighCommand = new RoutedUICommand("", "LOCLighCommand", typeof(UC_LOC));
        public static readonly RoutedUICommand LOCCameraCommand = new RoutedUICommand("", "LOCCameraCommand", typeof(UC_LOC));
        //public static readonly RoutedUICommand LOCOpenValveCommand = new RoutedUICommand("", "LOCOpenValveCommand", typeof(UC_LOC));
        public static readonly RoutedUICommand LOCStartAimationCameraCommand = new RoutedUICommand("", "LOCStartAimationCameraCommand", typeof(UC_LOC));

        public UC_LOC()
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

            CommandBindings.Add(new CommandBinding(LOCLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(LOCCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(LOCOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(LOCStartAimationCameraCommand, Option4_Click));

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer8.Start();
            }
            else
            {
                MainWindow.blinkTimer8.Stop();
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

                StartAnimation();
            }
            else
            {
                StopAnimation();
            }
        }


        public void StartAnimation()
        {
            collectorMovement = (Storyboard)this.Resources["CollectorMovement"];
            collectorAnimation = (DoubleAnimation)collectorMovement.Children[0]; 

            collectorCarrierTextMovement = (Storyboard)this.Resources["CollectortextboxMovement"];
            collectorTEXTAnimation = (DoubleAnimation)collectorCarrierTextMovement.Children[0];


            MainWindow.arrowUpDownHBY.Visibility = Visibility.Hidden;
            MainWindow.arrowUCIinstance.Visibility = Visibility.Hidden;
            MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg");
            MainWindow.ChangeVisibilityOfPortionerArrow(false);

            isAnimationOngoing = true;

            if (collectorMovement != null && collectorAnimation != null && collectorCarrierTextMovement != null && collectorTEXTAnimation != null)
            {
                collectorAnimation.From = translateTransformCollector.X;
                collectorAnimation.To = destinationXPos;

                collectorTEXTAnimation.From = translateTransformCollectortexybox.X;
                collectorTEXTAnimation.To = destinationXPos;

                collectorMovement.Completed += CollectorMovement_Completed;


                collectorMovement.Begin();
                collectorCarrierTextMovement.Begin();


            }

        }


        public void StopAnimation()
        {
            isAnimationOngoing = false;

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
                else if (item.Name == "menuItem3")
                {
                    //if (IsValveOpen)
                    //{

                    //    item.Header = "Close Valve";

                    //}
                    //else
                    //{
                    //    item.Header = "Open Valve";
                    //}

                }
                else if (item.Name == "menuItem4")
                {
                    if (isAnimationOngoing)
                    {

                        item.Header = "Stop Animation";

                    }
                    else
                    {
                        item.Header = "Start Animation";
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

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Content.ToString();

                switch (selectedValue)
                {
                    case "0":
                        destinationXPos = -0;
                        break;

                    case "1":
                        destinationXPos = -60;
                        break;

                    case "2":
                        destinationXPos = -120;
                        break;

                    case "3":
                        destinationXPos = -180;
                        break;

                    case "4":
                        destinationXPos = -240;
                        break;

                    case "5":
                        destinationXPos = -300;
                        break;

                    case "6":
                        destinationXPos = -365;
                        break;

                    case "7":
                        destinationXPos = -425;
                        break;

                    case "8":
                        destinationXPos = -485;
                        break;

                    case "9":
                        destinationXPos = -545;
                        break;

                    case "10":

                        destinationXPos = -600;

                        break;

                    default:
                        destinationXPos = -0;
                        break;
                }
            }
        }

        private void CollectorMovement_Completed(object sender, EventArgs e)
        {
            if (destinationXPos == -485)
            {
                MainWindow.arrowUCIinstance.Visibility = Visibility.Visible;

            }else if (destinationXPos == -600)
            {
                MainWindow.arrowUpDownHBY.Visibility = Visibility.Visible;

            }
            else if(destinationXPos == -425)
            {
                //just below slicer
            }else if(destinationXPos == -60)
            {
                MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner180.svg");
                MainWindow.ChangeVisibilityOfPortionerArrow(true);
            }
        }
    }


}
