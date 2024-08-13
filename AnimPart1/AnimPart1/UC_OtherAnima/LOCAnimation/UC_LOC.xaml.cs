using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace AnimPart1.UC_AncillaryAnima.LOCAnimation
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
        public bool isAnimationOngoing;

        Storyboard collectorMovement;
        DoubleAnimation collectorAnimation;

        Storyboard collectorCarrierTextMovement;
        DoubleAnimation collectorTEXTAnimation;


        DispatcherTimer timer;
        private bool isAnimationOnGoing;

        private List<int> predefinedValues = new List<int>
        {
            0, -82, -164, 246, -328, -410, -492, -574, -656, -738,
            -820, -900
        };

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

          

        }


        public void StartAnimation()
        {
            // Start the Storyboard (which starts the animation)

            // Retrieve the Storyboard and the animation
            collectorMovement = (Storyboard)this.Resources["CollectorMovement"];
            collectorAnimation = (DoubleAnimation)collectorMovement.Children[0]; // Assuming it's the first child

            collectorCarrierTextMovement = (Storyboard)this.Resources["CollectortextboxMovement"];
            collectorTEXTAnimation = (DoubleAnimation)collectorMovement.Children[0]; // Assuming it's the first child

            isAnimationOngoing = true;

            if (collectorMovement != null && collectorAnimation != null)
            {
                collectorMovement.Begin();
                collectorCarrierTextMovement.Begin();

                timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(50) // Increase frequency for better detection
                };
                timer.Tick += OnTimerTick;
                timer.Start();
            }
            else
            {
                // Handle the case where the resources were not found
                MessageBox.Show("Storyboard or DoubleAnimation not found in resources.");
            }
            // Add an event handler to track progress
        }

        
        public void StopAnimation()
        {
            isAnimationOngoing = false;
            timer.Stop(); // Stop the timer if animation is paused

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (collectorMovement != null && translateTransformCollector != null)
            {
                // Get the current X value of the TranslateTransform
                double currentXValue = translateTransformCollector.X;

                // Round the current X value to the nearest integer
                int roundedValue = (int)Math.Round(currentXValue);
                Debug.WriteLine(roundedValue);

                // Check if roundedValue is in the predefined set of values or less than or equal to -900
                if (roundedValue <= -900 || predefinedValues.Contains(roundedValue))
                {
                    collectorMovement.Pause();
                    collectorCarrierTextMovement.Pause();
                    timer.Stop(); // Stop the timer if animation is paused
                }
            }
            else
            {
                // Handle the case where the resources are still not initialized
                MessageBox.Show("Storyboard or TranslateTransform is null.");
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
    }


}
