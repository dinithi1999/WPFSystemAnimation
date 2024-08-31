using AnimPart1.UC_AncillaryAnima.FPUAnimation;
using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using AnimPart1.UC_OtherAnima.LOCAnimation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_OtherAnima.FPPAnimation
{
    /// <summary>
    /// Interaction logic for UC_FPAAnimation.xaml
    /// </summary>
    public partial class UC_FPPAnimation : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl2;

        public UC_Label labelUserCtrl;



        public string labelName = "FPP-XXX";
        public bool isLightOn;
        private bool isCameraOn;
        public bool isAnimationOngoing;

        Storyboard collectorMovement;
        DoubleAnimation collectorAnimation;

        Storyboard collectorCarrierTextMovement;
        DoubleAnimation collectorTEXTAnimation;

        double destinationXPos = 0;

        private bool isAnimationOnGoing;


        public static readonly RoutedUICommand FPPLighCommand = new RoutedUICommand("", "FPPLighCommand", typeof(UC_FPPAnimation));
        public static readonly RoutedUICommand FPPCameraCommand = new RoutedUICommand("", "FPPCameraCommand", typeof(UC_FPPAnimation));
        //public static readonly RoutedUICommand LOCOpenValveCommand = new RoutedUICommand("", "LOCOpenValveCommand", typeof(UC_LOC));
        public static readonly RoutedUICommand FPPStartAimationCameraCommand = new RoutedUICommand("", "FPPStartAimationCameraCommand", typeof(UC_FPPAnimation));

        public UC_FPPAnimation()
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

            CommandBindings.Add(new CommandBinding(FPPLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(FPPCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(LOCOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(FPPStartAimationCameraCommand, Option4_Click));
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

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
            this.Focus();
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
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

        public void StartAnimation()
        {
            collectorMovement = (Storyboard)this.Resources["CollectorMovement"];
            collectorAnimation = (DoubleAnimation)collectorMovement.Children[0];

           

            svgViewbox2.Visibility = Visibility.Visible;

            //MainWindow.arrowUpDownHBY.Visibility = Visibility.Hidden;
            //MainWindow.arrowUCIinstance.Visibility = Visibility.Hidden;
            //MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg");
            //MainWindow.ChangeVisibilityOfPortionerArrow(false);

            isAnimationOngoing = true;

            if (collectorMovement != null && collectorAnimation != null)
            {
                collectorAnimation.From = translateTransformCollector.X;
                collectorAnimation.To = destinationXPos;
              
                collectorMovement.Completed += CollectorMovement_Completed;

                collectorMovement.Begin();

            }

        }


        public void StopAnimation()
        {
            isAnimationOngoing = false;

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

        private void CollectorMovement_Completed(object sender, EventArgs e)
        {
            //if (destinationXPos == -485)
            //{
            //    MainWindow.arrowUCIinstance.Visibility = Visibility.Visible;

            //}
            //else if (destinationXPos == -600)
            //{
            //    MainWindow.arrowUpDownHBY.Visibility = Visibility.Visible;

            //}
            //else if (destinationXPos == -425)
            //{
            //    //just below slicer
            //}
            //else if (destinationXPos == -60)
            //{
            //    //MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner180.svg");
            //    //MainWindow.ChangeVisibilityOfPortionerArrow(true);
            //}
            svgViewbox2.Visibility = Visibility.Hidden;
        }
    }
}
