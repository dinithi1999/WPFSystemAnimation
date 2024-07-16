using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using AnimPart1.UC_DepenAnima.UC_Hopper;
using AnimPart1.UC_DepenAnima.UC_SLO;
using AnimPart1.UC_DepenAnima.UC_TNK;

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

        CurrentState level  = CurrentState.eighty;

        DispatcherTimer blinkTimer;
        bool isCamFlashIsOn;

       
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
                blinkTimer.Tick += BlinkTimer_Tick;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            toggleButton.Background = new SolidColorBrush(Colors.Green);


        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // Handle toggle button unchecked event
            ToggleButton toggleButton = sender as ToggleButton;
            toggleButton.Background = new SolidColorBrush(Colors.Red);


        }


        private void HopperLightChecked_Checked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOnPath);

        }

        private void HopperLightChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            hopperUCInstance.lightUserCtrl.svgViewbox.Source = new Uri(LightOffPath);
        }


        private void BlinkTimer_Tick(object sender, EventArgs e)
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
            hopperUCInstance.cameraUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Camera/Images/CameraFlashOff.svg");
        }


        private void HopperLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void HopperLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TankLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void TankLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {

        }


        private void TankCamera_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Camera_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SLOCamera_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SLOCamera_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void SLOLights_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SLOLight_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SLOLabelVislibility_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SLOLabelVislibility_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TankLight_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void TankLight_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }

    enum CurrentState
    {
       eighty,
       seventy
    }
}