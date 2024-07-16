using AnimPart1.UC_DepenAnima.UC_Hopper;
using AnimPart1.UC_DepenAnima.UC_SLO;
using AnimPart1.UC_DepenAnima.UC_TNK;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

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


        DispatcherTimer blinkTimer;
        DispatcherTimer blinkTimer2;
        DispatcherTimer blinkTimer3;

        bool isCamFlashIsOn;
        bool isCamFlashIsOn2;
        bool isCamFlashIsOn3;


        const string LightOnPath = "pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOn.svg";
        const string LightOffPath = "pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOff.svg";
        const string CameraOffPath = "pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg";
        const string CameraOnPath = "pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOn.svg";

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

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

       



        #region DepenCamera
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
            // Stop blinking and show the LightOff image
            blinkTimer2.Stop();
            sloUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri(CameraOffPath);
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
        #endregion

        #region DepenLabel
        private void HopperLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            hopperUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
        }

        private void HopperLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            hopperUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
        }

        private void TankLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            tankUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
        }
        private void TankLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            tankUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
        }


        private void SLOLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Visible;
            sloUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Visible;
        }

        private void SLOLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
            sloUCInstance.cameraUserCtrl.svgViewbox.Visibility = Visibility.Hidden;
        }
        #endregion

        #region DepenLights
        private void TankLight_Checked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);

        }
        private void TankLight_Unchecked(object sender, RoutedEventArgs e)
        {
            tankUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);

        }
        private void SLOLights_Checked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);

        }

        private void SLOLight_Unchecked(object sender, RoutedEventArgs e)
        {
            sloUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);

        }
        private void HopperLightChecked_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);

        }

        private void HopperLightChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
        } 
        #endregion

    }


}