using AnimPart1.UC_DepenAnima.UC_Hopper;
using AnimPart1.UC_DepenAnima.UC_SLO;
using AnimPart1.UC_DepenAnima.UC_TNK;
using AnimPart1.UC_PrimiAnima;
using AnimPart1.UC_PrimiAnima.UC_Screw;
using AnimPart1.UC_PrimiAnima.UC_Slicer;
using AnimPart1.UC_PrimiAnima.UC_Pump;

using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using AnimPart1.UC_AncillaryAnima.FPPAnimation;
using AnimPart1.UC_AncillaryAnima.FPUAnimation;
using AnimPart1.UC_AncillaryAnima.HBYRotation;
using AnimPart1.UC_AncillaryAnima.LOCAnimation;
using AnimPart1.UC_OtherAnima.PFUAnimation;
using AnimPart1.UC_AncillaryAnima.DownArrow;

namespace AnimPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UC_Hopper hopperUCInstance;
        UC_SLO sloUCInstance;
        UC_TNK tankUCInstance;
        public static UC_Portioner portionerUCInstance;
        UC_Screw screwUCInstance;
        UC_Slicer slicerUCInstance;
        UC_Pump pumpUCInstance;

        UC_LOC locUCIinstance;
        UC_HBYAnimation hbyUCIinstance;
        UC_PFUAnimation pfuUCIinstance;
        UC_FPUAnimation fpuUCIinstance;
        UC_FPPAnimation fppUCIinstance;

        public static  UC_DownArrow arrowUCIinstance;

        public static DispatcherTimer blinkTimer;
        public static DispatcherTimer blinkTimer2;
        public static DispatcherTimer blinkTimer3;
        public static DispatcherTimer blinkTimer4;
        public static DispatcherTimer blinkTimer5;
        public static DispatcherTimer blinkTimer6;
        public static DispatcherTimer blinkTimer7;

        public static DispatcherTimer blinkTimer8;
        public static DispatcherTimer blinkTimer9;
        public static DispatcherTimer blinkTimer10;
        public static DispatcherTimer blinkTimer11;
        public static DispatcherTimer blinkTimer12;

        bool isCamFlashIsOn;
        bool isCamFlashIsOn2;
        bool isCamFlashIsOn3;
        bool isCamFlashIsOn4;
        bool isCamFlashIsOn5;
        bool isCamFlashIsOn6;
        bool isCamFlashIsOn7;
        bool isCamFlashIsOn8;
        bool isCamFlashIsOn9;
        bool isCamFlashIsOn10;
        bool isCamFlashIsOn11;
        bool isCamFlashIsOn12;

        public static UC_DownArrow arrowUpDownHBY;
        public static UC_DownArrow arrowDownDownHBY;

        public static UC_DownArrow arrowDownDownPFU;

        const string LightOnPath = "pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOn.svg";
        const string LightOffPath = "pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOff.svg";
        const string CameraOffPath = "pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg";
        const string CameraOnPath = "pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOn.svg";

        const string portionerInit = "pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg";
        const string portioner90 = "pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner90.svg";


        public MainWindow()
        {
            InitializeComponent();
         
            try
            {
                hopperUCInstance = new UC_Hopper();
                hopperContentControl.Content = hopperUCInstance;


                sloUCInstance = new UC_SLO();
                sloContentControl.Content = sloUCInstance; 


                tankUCInstance = new UC_TNK();
                tankContentControl.Content = tankUCInstance;


                portionerUCInstance = new UC_Portioner();
                portionerUCInstance.backgroundSvgRow.Visibility = Visibility.Collapsed;
                column3Row1ContentControl.Content = portionerUCInstance;


                screwUCInstance = new UC_Screw();
                column3Row2ContentControl.Content = screwUCInstance;


                slicerUCInstance = new UC_Slicer();
                column2ContentControl.Content = slicerUCInstance;

                pumpUCInstance = new UC_Pump();
                column1ContentControl.Content = pumpUCInstance;

                hbyUCIinstance = new UC_HBYAnimation();
                HBYTopLeftContentControl.Content = hbyUCIinstance;


                pfuUCIinstance = new UC_PFUAnimation();
                HBYBottomRightContentControl.Content = pfuUCIinstance;


                locUCIinstance = new UC_LOC();
                LOCcolumn2ContentControl.Content = locUCIinstance;


                //pfuUCIinstance = new UC_PFUAnimation();
                //PFUcolumn1ContentControl.Content = pfuUCIinstance;

                fpuUCIinstance = new UC_FPUAnimation();
                FPUcolumn1ContentControl.Content = fpuUCIinstance;

                arrowUCIinstance = new UC_DownArrow();
                HBYTopRightContentControl.Content= arrowUCIinstance;

                arrowUpDownHBY = new UC_DownArrow();
                arrowUpDownHBY.backgroundSvgRow.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/DownArrow/Images/down1Arrow.svg");
                HBYTopLeftContentControltopRow.Content = arrowUpDownHBY;


                arrowDownDownHBY = new UC_DownArrow();
                arrowDownDownHBY.backgroundSvgRow.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/DownArrow/Images/down1Arrow.svg");
                HBYTopLeftContentControldownRow.Content = arrowDownDownHBY;


                arrowDownDownPFU = new UC_DownArrow();
                arrowDownDownPFU.backgroundSvgRow.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/DownArrow/Images/down1Arrow.svg");
                PFUDownArrowContentControl.Content = arrowDownDownPFU;

                MainWindow.arrowDownDownHBY.Visibility = Visibility.Hidden;
                MainWindow.arrowUpDownHBY.Visibility = Visibility.Hidden;
                MainWindow.arrowDownDownPFU.Visibility = Visibility.Hidden;
                MainWindow.arrowUCIinstance.Visibility = Visibility.Hidden;

                // Initialize the timer for blinking for the camera
                blinkTimer = new DispatcherTimer();
                blinkTimer.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer.Tick += BlinkTimerHopper_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer2 = new DispatcherTimer();
                blinkTimer2.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer2.Tick += BlinkTimerSLO_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer3 = new DispatcherTimer();
                blinkTimer3.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer3.Tick += BlinkTimerTank_Tick;

                blinkTimer4 = new DispatcherTimer();
                blinkTimer4.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer4.Tick += BlinkTimerPMP_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer5 = new DispatcherTimer();
                blinkTimer5.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer5.Tick += BlinkTimerSLC_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer6 = new DispatcherTimer();
                blinkTimer6.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer6.Tick += BlinkTimerSRW_Tick;

                 // Initialize the timer for blinking for the camera
                blinkTimer7 = new DispatcherTimer();
                blinkTimer7.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer7.Tick += BlinkTimerPOR_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer8 = new DispatcherTimer();
                blinkTimer8.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer8.Tick += BlinkTimerLOC_Tick;


                // Initialize the timer for blinking for the camera
                blinkTimer9 = new DispatcherTimer();
                blinkTimer9.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer9.Tick += BlinkTimerHBY_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer10 = new DispatcherTimer();
                blinkTimer10.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer10.Tick += BlinkTimerPFU_Tick;


                // Initialize the timer for blinking for the camera
                blinkTimer11 = new DispatcherTimer();
                blinkTimer11.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer11.Tick += BlinkTimerFPU_Tick;

                // Initialize the timer for blinking for the camera
                blinkTimer12 = new DispatcherTimer();
                blinkTimer12.Interval = TimeSpan.FromSeconds(0.5);
                blinkTimer12.Tick += BlinkTimerFPP_Tick;

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            hopperAnimStart.IsChecked = false;
            hopperCam.IsChecked = true;
            hopperLight.IsChecked = true;
            hopperLabel.IsChecked = true;

            tankCam.IsChecked = true;
            tankLabel.IsChecked = true;
            tankLight.IsChecked = true;
            tankAnimStart.IsChecked = false;

            SiloCam.IsChecked = true;
            SiloLabel.IsChecked = true;
            SiloLight.IsChecked = true;
            SiloAnimStart.IsChecked = false;


            pmpLabelVisibilityToggleBtn.IsChecked = true;
            pmplightOnToggleBtn.IsChecked = true;
            pmpCamOnToggleBtn.IsChecked = true;
            pmpAnimStartToggleBtn.IsChecked = false;
            pmpclockwiseRadioButton.IsChecked = true;

            srwLabelVisibilityToggleBtn.IsChecked = true;
            srwlightOnToggleBtn.IsChecked = true;
            srwCamOnToggleBtn.IsChecked = true;
            srwAnimStartToggleBtn.IsChecked = false;
            srwclockwiseRadioButton.IsChecked = true;

            slcLabelVisibilityToggleBtn.IsChecked = true;
            slclightOnToggleBtn.IsChecked = true;
            slcCamOnToggleBtn.IsChecked = true;
            slcAnimStartToggleBtn.IsChecked = false;

            porLabelVisibilityToggleBtn.IsChecked = true;
            porlightOnToggleBtn.IsChecked = true;
            porCamOnToggleBtn.IsChecked = true;
            porAnimStartToggleBtn.IsChecked = false;


            pfuLabelVisibilityToggleBtn.IsChecked = true;
            pfuLightOnToggleBtn.IsChecked = true;
            pfuCamOnToggleBtn.IsChecked = true;
            pfuAnimStartToggleBtn.IsChecked = false;
            pfuClockwiseRadioButton.IsChecked = true;

            locLabelVisibilityToggleBtn.IsChecked = true;
            loclightOnToggleBtn.IsChecked = true;
            locCamOnToggleBtn.IsChecked = true;
            locAnimStartToggleBtn.IsChecked = false;

            hbyLabelVisibilityToggleBtn.IsChecked = true;
            hbyLightOnToggleBtn.IsChecked = true;
            hbyCamOnToggleBtn.IsChecked = true;
            hbyAnimStartToggleBtn.IsChecked = false;
            hbyClockwiseRadioButton.IsChecked = true;

        }


        public static void ChangeVisibilityOfPortionerArrow(bool isVisible)
        {
            if (isVisible)
            {
                portionerUCInstance.backgroundSvgRow.Visibility = Visibility.Visible;

            }
            else
            {
                portionerUCInstance.backgroundSvgRow.Visibility = Visibility.Collapsed;

            }
        }

        #region Camera
        private void HopperCameraChecked_Checked(object sender, RoutedEventArgs e)
        {
            // Start blinking
            isCamFlashIsOn = true; // Initial state
            blinkTimer.Start();
        }

        private void HopperCameraChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            // Stop blinking and show the LightOff image
            blinkTimer.Stop();
            hopperUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void TankCamera_Checked(object sender, RoutedEventArgs e)
        {
            // Start blinking
            isCamFlashIsOn3 = true; // Initial state
            blinkTimer3.Start();
        }
        private void Camera_Unchecked(object sender, RoutedEventArgs e)
        {
            // Stop blinking and show the LightOff image
            blinkTimer3.Stop();
            tankUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void SLOCamera_Checked(object sender, RoutedEventArgs e)
        {
            // Start blinking
            isCamFlashIsOn2 = true; // Initial state
            blinkTimer2.Start();
        }

        private void SLOCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer2.Stop();
            sloUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);

        }

        private void PMPCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer4.Stop();
            pumpUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void PMPCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn4 = true;
            blinkTimer4.Start();
        }

        private void SLCCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer5.Stop();
            slicerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void SLCCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn5 = true;
            blinkTimer5.Start();
           
        }

        private void SRWCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer6.Stop();
            screwUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void SRWCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn6 = true;
            blinkTimer6.Start();
           
        }
        private void PORCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer7.Stop();
            portionerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void PORCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn7 = true;
            blinkTimer7.Start();
        }

        private void LOCCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer8.Stop();
            locUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void LOCCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn8 = true;
            blinkTimer8.Start();
        }

        private void HBYCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer9.Stop();
            hbyUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void HBYCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn9 = true;
            blinkTimer9.Start();
        }

        private void PFUCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer10.Stop();
            pfuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void PFUCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn10 = true;
            blinkTimer10.Start();
        }

        private void FPUCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer11.Stop();
            fpuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void FPUCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn11 = true;
            blinkTimer11.Start();
        }

        private void FPPCamera_Unchecked(object sender, RoutedEventArgs e)
        {
            blinkTimer12.Stop();
            fppUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
        }

        private void FPPCamera_Checked(object sender, RoutedEventArgs e)
        {
            isCamFlashIsOn12 = true;
            blinkTimer12.Start();
        }



        private void BlinkTimerHopper_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn)
            {
                hopperUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                hopperUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn = !isCamFlashIsOn;
        }

        private void BlinkTimerSLO_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn2)
            {
                sloUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                sloUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn2 = !isCamFlashIsOn2;
        }

        private void BlinkTimerTank_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn3)
            {
                tankUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                tankUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn3 = !isCamFlashIsOn3;
        }

        private void BlinkTimerPMP_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn4)
            {
                pumpUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                pumpUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn4 = !isCamFlashIsOn4;
        }


        private void BlinkTimerSLC_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn5)
            {
                slicerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                slicerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn5 = !isCamFlashIsOn5;
        }


        private void BlinkTimerSRW_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn6)
            {
                screwUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                screwUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn6 = !isCamFlashIsOn6;
        }

        private void BlinkTimerPOR_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn7)
            {
                portionerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                portionerUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn7 = !isCamFlashIsOn7;
        }

        private void BlinkTimerLOC_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn8)
            {
                locUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                locUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn8 = !isCamFlashIsOn8;
        }

        private void BlinkTimerHBY_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn9)
            {
                hbyUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                hbyUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn9 = !isCamFlashIsOn9;
        }


        private void BlinkTimerPFU_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn10)
            {
                pfuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                pfuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn10 = !isCamFlashIsOn10;
        }

        private void BlinkTimerFPU_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn11)
            {
                fpuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                fpuUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn11 = !isCamFlashIsOn11;
        }

        private void BlinkTimerFPP_Tick(object sender, EventArgs e)
        {
            if (isCamFlashIsOn12)
            {
                fppUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
            }
            else
            {
                fppUCIinstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOnPath);
            }

            isCamFlashIsOn12 = !isCamFlashIsOn12;
        }

        #endregion

        #region Label
        private void HopperLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            hopperUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            hopperUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            hopperUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;


        }

        private void HopperLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            hopperUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            hopperUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }

        private void TankLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            tankUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            tankUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            tankUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;


        }
        private void TankLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            tankUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            tankUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }


        private void SLOLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            sloUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            sloUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            sloUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;

            
        }

        private void SLOLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            sloUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            sloUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }

        private void PortionerLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            portionerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;

            portionerUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            portionerUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;

        }

        private void PortionerLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            portionerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            portionerUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }

        private void PMPLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            pumpUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            pumpUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            pumpUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
            pumpUCInstance.labelUserCtrl2.Visibility = Visibility.Visible;
            pumpUCInstance.labelUserCtrl2.MainCanvas.Visibility = Visibility.Visible;
        }

        private void PMPLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            pumpUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            pumpUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;
            pumpUCInstance.labelUserCtrl2.Visibility = Visibility.Hidden;

        }

        private void SLCLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            slicerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            slicerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            slicerUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            slicerUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;

            slicerUCInstance.labelUserCtrl2.Visibility = Visibility.Hidden;
            slicerUCInstance.labelUserCtrl2.MainCanvas.Visibility = Visibility.Hidden;
        }

        private void SLCLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            slicerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            slicerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            slicerUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

            slicerUCInstance.labelUserCtrl2.Visibility = Visibility.Hidden;
            slicerUCInstance.labelUserCtrl2.MainCanvas.Visibility = Visibility.Hidden;
        }

        private void SRWLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            screwUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            screwUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            screwUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
            screwUCInstance.labelUserCtrl2.Visibility = Visibility.Visible;
            screwUCInstance.labelUserCtrl2.MainCanvas.Visibility = Visibility.Visible;
        }

        private void SRWLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            screwUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            screwUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;
            screwUCInstance.labelUserCtrl2.Visibility = Visibility.Hidden;
        }

        private void PORLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            portionerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            portionerUCInstance.labelUserCtrl.Visibility = Visibility.Visible;
            portionerUCInstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void PORLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            portionerUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            portionerUCInstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }

        private void LOCLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            locUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            locUCIinstance.labelUserCtrl.Visibility = Visibility.Visible;
            locUCIinstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void LOCLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            locUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            locUCIinstance.labelUserCtrl.Visibility = Visibility.Hidden;

        }

        private void HBYLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            hbyUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            hbyUCIinstance.labelUserCtrl.Visibility = Visibility.Visible;
            hbyUCIinstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void HBYLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            hbyUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            hbyUCIinstance.labelUserCtrl.Visibility = Visibility.Hidden;
        }

        private void PFULabelVisibility_Checked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            pfuUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            pfuUCIinstance.labelUserCtrl.Visibility = Visibility.Visible;
            pfuUCIinstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void PFULabelVisibility_Unchecked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            pfuUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            pfuUCIinstance.labelUserCtrl.Visibility = Visibility.Hidden;
        }

        private void FPULabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            fpuUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            fpuUCIinstance.labelUserCtrl.Visibility = Visibility.Visible;
            fpuUCIinstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void FPULabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            fpuUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            fpuUCIinstance.labelUserCtrl.Visibility = Visibility.Hidden;
        }

        private void FPPLabelVisibility_Checked(object sender, RoutedEventArgs e)
        {
            fppUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            fppUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            fppUCIinstance.labelUserCtrl.Visibility = Visibility.Visible;
            fppUCIinstance.labelUserCtrl.MainCanvas.Visibility = Visibility.Visible;
        }

        private void FPPLabelVisibility_Unchecked(object sender, RoutedEventArgs e)
        {
            fppUCIinstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            fppUCIinstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            fppUCIinstance.labelUserCtrl.Visibility = Visibility.Hidden;
        }




        #endregion

        #region Lights
        private void TankLight_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            tankUCInstance.isLightOn = true;


        }
        private void TankLight_Unchecked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            tankUCInstance.isLightOn = false;


        }
        private void SLOLights_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            sloUCInstance.isLightOn = true;


        }

        private void SLOLight_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            sloUCInstance.isLightOn = false;


        }
        private void HopperLightChecked_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            hopperUCInstance.isLightOn = true;

        }

        private void HopperLightChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            hopperUCInstance.isLightOn = false;
        }

        private void PortionerLights_Checked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            portionerUCInstance.isLightOn = true;
        }

        private void PortionerLight_Unchecked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            portionerUCInstance.isLightOn = false;
        }

        private void PMPLights_Checked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            pumpUCInstance.isLightOn = true;
        }

        private void PMPLight_Unchecked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            pumpUCInstance.isLightOn = false;
        }

        private void SRWLights_Checked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            screwUCInstance.isLightOn = true;
        }

        private void SRWLight_Unchecked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            screwUCInstance.isLightOn = false;
        }

        private void SLCLights_Checked(object sender, RoutedEventArgs e)
        {
            slicerUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            slicerUCInstance.isLightOn = true;
        }

        private void SLCLight_Unchecked(object sender, RoutedEventArgs e)
        {
            slicerUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            slicerUCInstance.isLightOn = false;
        }

        private void LOCLights_Checked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            locUCIinstance.isLightOn = true;
        }

        private void LOCLight_Unchecked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            locUCIinstance.isLightOn = false;
        }

        private void HBYLights_Checked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            hbyUCIinstance.isLightOn = true;
        }

        private void HBYLight_Unchecked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            hbyUCIinstance.isLightOn = false;
        }

        private void PFULights_Checked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            pfuUCIinstance.isLightOn = true;
        }

        private void PFULight_Unchecked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            pfuUCIinstance.isLightOn = false;
        }

        private void FPULights_Checked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            fpuUCIinstance.isLightOn = true;
        }

        private void FPULight_Unchecked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            fpuUCIinstance.isLightOn = false;
        }

        private void FPPLights_Checked(object sender, RoutedEventArgs e)
        {
            fppUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);
            fppUCIinstance.isLightOn = true;
        }

        private void FPPLight_Unchecked(object sender, RoutedEventArgs e)
        {
            fppUCIinstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
            fppUCIinstance.isLightOn = false;
        }






        #endregion

        #region StartTriggers
        private void HopperStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.StartPadleAnimation();
            SetHOPSpeed();
        }

        private void HopperStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.StopPadleAnimation();
        }

        private void SiloStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.StartPadleAnimation();
            SetSRWSpeed();

        }

        private void SiloStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.StopPadleAnimation();

        }

        private void TankStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.StartPadleAnimation();
            SetTNKSpeed();

        }

        private void TankStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.StopPadleAnimation();
        }

        private void PortionerStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.svgViewbox.Source = new Uri(portionerInit);
        }

        private void PortionerStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            portionerUCInstance.svgViewbox.Source = new Uri(portioner90);
        }

        private void PMPStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.StartSpinning();
            SetPMPSpeed();
            pmpclockwiseRadioButton.IsEnabled = false;
            pmpcounterClockwiseRadioButton.IsEnabled = false;

        }

        private void PMPStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            pumpUCInstance.StopSpinning();
            pmpclockwiseRadioButton.IsEnabled = true;
            pmpcounterClockwiseRadioButton.IsEnabled = true;
        }

        private void SLCStartChecked_Checked(object sender, RoutedEventArgs e)
        {


            slicerUCInstance.slicerAnime.StartAnimations();

        }

        private void SLCStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            slicerUCInstance.slicerAnime.StopAnimations();

        }

        private void SRWStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.StartSpinning();
            SetSRWSpeed();
            srwclockwiseRadioButton.IsEnabled = false;
            srwcounterClockwiseRadioButton.IsEnabled = false;


        }

        private void SRWStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.StopSpinning();
            srwclockwiseRadioButton.IsEnabled = true;
            srwcounterClockwiseRadioButton.IsEnabled = true;
        }


        private void LOCStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.StartAnimation();
        }

        private void LOCStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            locUCIinstance.StopAnimation();

        }

        private void HBYStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.StartSpinning();
            SetSRWSpeed();
            hbyClockwiseRadioButton.IsEnabled = false;
            hbyCounterClockwiseRadioButton.IsEnabled = false;
        }

        private void HBYStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hbyUCIinstance.StopSpinning();
            hbyClockwiseRadioButton.IsEnabled = true;
            hbyCounterClockwiseRadioButton.IsEnabled = true;
        }

        private void PFUStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.StartSpinning();
            SetSRWSpeed();
            pfuClockwiseRadioButton.IsEnabled = false;
            pfuCounterClockwiseRadioButton.IsEnabled = false;
        }

        private void PFUStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            pfuUCIinstance.StopSpinning();
            pfuClockwiseRadioButton.IsEnabled = true;
            pfuCounterClockwiseRadioButton.IsEnabled = true;
        }

        private void FPUStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.StartStirrerRotation();

        }

        private void FPUStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.StopAnimation();

        }

        private void FPUEmptyBtn_Clicked(object sender, RoutedEventArgs e)
        {
            fpuUCIinstance.EmptyMaterial();
        }

        private void FPPStartChecked_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void FPPStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
        }
        #endregion

        #region Speed Variation


        private void srwclockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!screwUCInstance.isAnimationOnGoing)
            {
                screwUCInstance.SetRotationDirection(false);
            }
            else
            {
                MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            }
        }

        private void srwcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!screwUCInstance.isAnimationOnGoing)
            {
                screwUCInstance.SetRotationDirection(true);
            }
            else
            {
                MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            }
        }



        private void pmpcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!pumpUCInstance.isAnimationOngoing)
            {
                pumpUCInstance.SetRotationDirection(true);
            }
            else
            {
                MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            }
        }

        private void pmpclockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!pumpUCInstance.isAnimationOngoing)
            {
                pumpUCInstance.SetRotationDirection(false);
            }
            else
            {
                MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            }
        }


        private void FPPclockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //if (!fppUCIinstance.isAnimationOnGoing)
            //{
            //    fppUCIinstance.SetRotationDirection(false);
            //}
            //else
            //{
            //    MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            //}
        }

        private void FPPcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //    if (!fppUCIinstance.isAnimationOnGoing)
            //    {
            //        fppUCIinstance.SetRotationDirection(true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Stop the rotation berfore changing the rotational direction");
            //    }
        }
        private void LOClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //if (!locUCIinstance.isAnimationOnGoing)
            //{
            //    locUCIinstance.SetRotationDirection(false);
            //}
            //else
            //{
            //    MessageBox.Show("Stop the rotation before changing the rotational direction");
            //}
        }

        private void LOCcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //    if (!locUCIinstance.isAnimationOnGoing)
            //    {
            //        locUCIinstance.SetRotationDirection(true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Stop the rotation before changing the rotational direction");
            //    }
        }
        private void HBYClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!hbyUCIinstance.isAnimationOngoing)
            {
                hbyUCIinstance.SetRotationDirection(false);
            }
            else
            {
                MessageBox.Show("Stop the rotation before changing the rotational direction");
            }
        }

        private void HBYCounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!hbyUCIinstance.isAnimationOngoing)
            {
                hbyUCIinstance.SetRotationDirection(true);
            }
            else
            {
                MessageBox.Show("Stop the rotation before changing the rotational direction");
            }
        }

        private void PFUClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!pfuUCIinstance.isAnimationOngoing)
            {
                pfuUCIinstance.SetRotationDirection(false);
            }
            else
            {
                MessageBox.Show("Stop the rotation before changing the rotational direction");
            }
        }

        private void PFUcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!pfuUCIinstance.isAnimationOngoing)
            {
                pfuUCIinstance.SetRotationDirection(true);
            }
            else
            {
                MessageBox.Show("Stop the rotation before changing the rotational direction");
            }
        }

        private void FPUclockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //if (!fpuUCIinstance.isAnimationOnGoing)
            //{
            //    fpuUCIinstance.SetRotationDirection(false);
            //}
            //else
            //{
            //    MessageBox.Show("Stop the rotation before changing the rotational direction");
            //}
        }

        private void FPUcounterClockwiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //    if (!fpuUCIinstance.isAnimationOnGoing)
            //    {
            //        fpuUCIinstance.SetRotationDirection(true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Stop the rotation before changing the rotational direction");
            //    }
        }





        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numeric input
            e.Handled = !IsTextNumeric(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (int.TryParse(textBox.Text, out int value))
                {
                    if (value < 0)
                    {
                        textBox.Text = "0";
                    }
                    else if (value > 100)
                    {
                        textBox.Text = "100";
                    }
                    // Optionally move the cursor to the end of the text
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        private bool IsTextNumeric(string text)
        {
            return Regex.IsMatch(text, @"^[0-9]+$");
        }




        private void SRWSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
           SetSRWSpeed();
        }


        private void PMPSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            SetPMPSpeed();

        }

        private void HOPSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetHOPSpeed();

        }

        private void SLOSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSLOSpeed();

        }


        private void TNKSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTNKSpeed();

        }

        private void LOCSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetLOCSpeed();

        }

        private void HBYSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetHBYSpeed();

        }

        private void PFUSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPFUSpeed();

        }

        private void FPUSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetFPUSpeed();

        }
        private void FPPSpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetFPPSpeed();

        }

        private void SpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTNKSpeed();

        }


        private void SetSRWSpeed()
        {
            if (int.TryParse(speedTextBoxSRW.Text, out int value))
            {
                if (value < 0)
                {
                    speedTextBoxSRW.Text = "0";
                }
                else if (value > 100)
                {
                    speedTextBoxSRW.Text = "100";
                }
                speedTextBoxSRW.SelectionStart = speedTextBoxSRW.Text.Length;
            }

            if (int.TryParse(speedTextBoxSRW.Text, out int percentage))
            {
                if (screwUCInstance != null && screwUCInstance.isAnimationOnGoing)
                {
                    screwUCInstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetPMPSpeed()
        {

            if (int.TryParse(pmpspeedTextBoxpmp.Text, out int value))
            {
                if (value < 0)
                {
                    pmpspeedTextBoxpmp.Text = "0";
                }
                else if (value > 100)
                {
                    pmpspeedTextBoxpmp.Text = "100";
                }
                pmpspeedTextBoxpmp.SelectionStart = pmpspeedTextBoxpmp.Text.Length;
            }

            if (int.TryParse(pmpspeedTextBoxpmp.Text, out int percentage))
            {
                if (pumpUCInstance != null && pumpUCInstance.isAnimationOngoing)
                {
                    pumpUCInstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetTNKSpeed()
        {

            if (int.TryParse(speedTextBoxTANK.Text, out int value))
            {
                if (value < 0)
                {
                    speedTextBoxTANK.Text = "0";
                }
                else if (value > 100)
                {
                    speedTextBoxTANK.Text = "100";
                }
                speedTextBoxTANK.SelectionStart = speedTextBoxTANK.Text.Length;
            }

            if (int.TryParse(speedTextBoxTANK.Text, out int percentage))
            {
                if (tankUCInstance != null)
                {
                    tankUCInstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetHOPSpeed()
        {

            if (int.TryParse(speedTextBoxHOP.Text, out int value))
            {
                if (value < 0)
                {
                    speedTextBoxHOP.Text = "0";
                }
                else if (value > 100)
                {
                    speedTextBoxHOP.Text = "100";
                }
                speedTextBoxHOP.SelectionStart = speedTextBoxHOP.Text.Length;
            }

            if (int.TryParse(speedTextBoxHOP.Text, out int percentage))
            {
                if (hopperUCInstance != null)
                {
                    hopperUCInstance.SetRotationSpeed(percentage);
                }
            }

        }

        private void SetSLOSpeed()
        {

            if (int.TryParse(speedTextBoxSLO.Text, out int value))
            {
                if (value < 0)
                {
                    speedTextBoxSLO.Text = "0";
                }
                else if (value > 100)
                {
                    speedTextBoxSLO.Text = "100";
                }
                speedTextBoxSLO.SelectionStart = speedTextBoxSLO.Text.Length;
            }

            if (int.TryParse(speedTextBoxSLO.Text, out int percentage))
            {
                if (sloUCInstance != null)
                {
                    sloUCInstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetLOCSpeed()
        {

            if (int.TryParse(locspeedTextBoxpmp.Text, out int value))
            {
                if (value < 0)
                {
                    locspeedTextBoxpmp.Text = "0";
                }
                else if (value > 100)
                {
                    locspeedTextBoxpmp.Text = "100";
                }

                locspeedTextBoxpmp.SelectionStart = locspeedTextBoxpmp.Text.Length;
            }

            if (int.TryParse(locspeedTextBoxpmp.Text, out int percentage))
            {
                if (locUCIinstance != null)
                {
                    locUCIinstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetHBYSpeed()
        {

            if (int.TryParse(hbySpeedTextBox.Text, out int value))
            {
                if (value < 0)
                {
                    hbySpeedTextBox.Text = "0";
                }
                else if (value > 100)
                {
                    hbySpeedTextBox.Text = "100";
                }

                hbySpeedTextBox.SelectionStart = hbySpeedTextBox.Text.Length;
            }

            if (int.TryParse(hbySpeedTextBox.Text, out int percentage))
            {
                if (hbyUCIinstance != null)
                {
                    hbyUCIinstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetPFUSpeed()
        {

            if (int.TryParse(pfuSpeedTextBox.Text, out int value))
            {
                if (value < 0)
                {
                    pfuSpeedTextBox.Text = "0";
                }
                else if (value > 100)
                {
                    pfuSpeedTextBox.Text = "100";
                }

                pfuSpeedTextBox.SelectionStart = pfuSpeedTextBox.Text.Length;
            }

            if (int.TryParse(pfuSpeedTextBox.Text, out int percentage))
            {
                if (pfuSpeedTextBox != null)
                {
                    //pfuUCIinstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetFPUSpeed()
        {

            if (int.TryParse(FPUspeedTextBoxpmp.Text, out int value))
            {
                if (value < 0)
                {
                    FPUspeedTextBoxpmp.Text = "0";
                }
                else if (value > 100)
                {
                    FPUspeedTextBoxpmp.Text = "100";
                }

                FPUspeedTextBoxpmp.SelectionStart = FPUspeedTextBoxpmp.Text.Length;
            }

            if (int.TryParse(FPUspeedTextBoxpmp.Text, out int percentage))
            {
                if (FPUspeedTextBoxpmp != null)
                {
                    //fpuUCIinstance.SetRotationSpeed(percentage);
                }
            }
        }

        private void SetFPPSpeed()
        {

            if (int.TryParse(fppSpeedTextBox.Text, out int value))
            {
                if (value < 0)
                {
                    fppSpeedTextBox.Text = "0";
                }
                else if (value > 100)
                {
                    fppSpeedTextBox.Text = "100";
                }

                fppSpeedTextBox.SelectionStart = fppSpeedTextBox.Text.Length;
            }

            if (int.TryParse(fppSpeedTextBox.Text, out int percentage))
            {
                if (fppSpeedTextBox != null)
                {
                    //fppUCIinstance.SetRotationSpeed(percentage);
                }
            }
        }

        #endregion

    }


}