using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.Rotating_Padle;
using AnimPart1.UC_AncillaryAnima.SlicerBallsAnimation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace AnimPart1.UC_PrimiAnima.UC_Slicer
{
    /// <summary>
    /// Interaction logic for UC_Slicer.xaml
    /// </summary>
    public partial class UC_Slicer : UserControl
    {

        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public UC_Label labelUserCtrl;

        public SlicerBallAnimation slicerAnime;

        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;
        private bool isCameraOn = true;

        private int currentHopperLevel; // Keep track of the current tank level

        public string labelName = "SLC XXX";
        public ICommand ToggleLightCommand { get; }

        public static readonly RoutedUICommand SlicerLighCommand = new RoutedUICommand("", "SlicerLighCommand", typeof(UC_Slicer));
        public static readonly RoutedUICommand SlicerCameraCommand = new RoutedUICommand("", "SlicerCameraCommand", typeof(UC_Slicer));
        //public static readonly RoutedUICommand HBYOpenValveCommand = new RoutedUICommand("", "HBYOpenValveCommand", typeof(UC_Pump));
        public static readonly RoutedUICommand SlicerStartAimationCameraCommand = new RoutedUICommand("", "SlicerStartAimationCameraCommand", typeof(UC_Slicer));

        public bool isAnimationOngoing;


        public UC_Slicer()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

      
            labelUserCtrl2 = new UC_PrimiLabel();
            labelColumn2.Content = labelUserCtrl2;


            slicerAnime = new SlicerBallAnimation();
            PadleColumn.Content = slicerAnime;


            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;

            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerMarquee.svg");
            //svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerbackground.svg");

            CommandBindings.Add(new CommandBinding(SlicerLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(SlicerCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(HBYOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(SlicerStartAimationCameraCommand, Option4_Click));
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer5.Start();
            }
            else
            {
                MainWindow.blinkTimer5.Stop();
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
                slicerAnime.StartAnimations();
                isAnimationOngoing = true;

            }
            else
            {
                slicerAnime.StopAnimations();
                isAnimationOngoing = false;
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
                        item.Icon = "pack://application:,,,/Images/Camera.svg";

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

                        item.Header = "Stop";
                        item.Icon = "pack://application:,,,/Images/Stop.svg";


                    }
                    else
                    {
                        item.Header = "Start";
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
    }
}
