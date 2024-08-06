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
        UC_Portioner portionerUCInstance;
        UC_Screw screwUCInstance;
        UC_Slicer slicerUCInstance;
        UC_Pump pumpUCInstance;

        DispatcherTimer blinkTimer;
        DispatcherTimer blinkTimer2;
        DispatcherTimer blinkTimer3;
        DispatcherTimer blinkTimer4;
        DispatcherTimer blinkTimer5;
        DispatcherTimer blinkTimer6;
        DispatcherTimer blinkTimer7;

        bool isCamFlashIsOn;
        bool isCamFlashIsOn2;
        bool isCamFlashIsOn3;
        bool isCamFlashIsOn4;
        bool isCamFlashIsOn5;
        bool isCamFlashIsOn6;
        bool isCamFlashIsOn7;



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
                column3Row1ContentControl.Content = portionerUCInstance;


                screwUCInstance = new UC_Screw();
                column3Row2ContentControl.Content = screwUCInstance;


                slicerUCInstance = new UC_Slicer();
                column2ContentControl.Content = slicerUCInstance;

                pumpUCInstance = new UC_Pump();
                column1ContentControl.Content = pumpUCInstance;

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

            SetSliderValue(tnkspeedSlider, 100);
            SetSliderValue(speedSliderSLO, 100);
            SetSliderValue(speedSliderHOP, 100);
            SetSliderValue(speedSliderpmp, 100);
            SetSliderValue(speedSliderSRW, 100);

        }


        private void SetSliderValue(Slider slider, double newValue)
        {
            // Ensure the value is within the defined range
            if (newValue >= slider.Minimum && newValue <= slider.Maximum)
            {
                slider.Value = newValue;
            }
            else
            {
                // Handle out-of-range values if necessary
                throw new ArgumentOutOfRangeException(nameof(newValue), "Value is out of range for the slider.");
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

        #endregion

        #region DepenLights
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




        #endregion

        private void HopperStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.StartPadleAnimation();
        }

        private void HopperStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.StopPadleAnimation();
        }

        private void SiloStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.StartPadleAnimation();

        }

        private void SiloStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.StopPadleAnimation();

        }

        private void TankStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.StartPadleAnimation();

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

        }

        private void SLCStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void SRWStartChecked_Checked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.StartSpinning();
            srwclockwiseRadioButton.IsEnabled = false;
            srwcounterClockwiseRadioButton.IsEnabled = false;


        }

        private void SRWStartChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            screwUCInstance.StopSpinning();
            srwclockwiseRadioButton.IsEnabled = true;
            srwcounterClockwiseRadioButton.IsEnabled = true;
        }


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
    }


}