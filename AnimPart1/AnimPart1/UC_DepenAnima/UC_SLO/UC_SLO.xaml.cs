using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.Rotating_Padle;
using AnimPart1.UC_PrimiAnima.UC_Pump;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimPart1.UC_DepenAnima.UC_SLO
{
    /// <summary>
    /// Interaction logic for UC_SLO.xaml
    /// </summary>
    public partial class UC_SLO : UserControl
    {

        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_Label labelUserCtrl;
        UC_PadleAnimation padle;

        private Dictionary<int, List<Uri>> siloLevelImagesLightOn;
        private Dictionary<int, List<Uri>> siloLevelImagesLightOff;

        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;
        private bool isCameraOn;
        private int currentSiloLevel; // Keep track of the current tank level

        public string labelName = "SLO-XXX";
        private bool isAnimationOnGoing;

        public static readonly RoutedUICommand SLOLighCommand = new RoutedUICommand("", "SLOLighCommand", typeof(UC_SLO));
        public static readonly RoutedUICommand SLOCameraCommand = new RoutedUICommand("", "SLOCameraCommand", typeof(UC_SLO));
        public static readonly RoutedUICommand SLOStartAimationCameraCommand = new RoutedUICommand("", "SLOStartAimationCameraCommand", typeof(UC_SLO));


        public UC_SLO()
        {
            InitializeComponent();

            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;


            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            backgroundSvg.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_SLO/Images/DepenBackgroundBlueBorder.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_SLO/Images/BackgroundLightOff.svg");

            padle = new UC_PadleAnimation();
            PadleColumn.Content = padle;


            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;

            // Initialize the dictionaries
            siloLevelImagesLightOn = SiloTankLevelImages("UC_DepenAnima/UC_SLO/Images/TankLevelsLightOn");
            siloLevelImagesLightOff = SiloTankLevelImages("UC_DepenAnima/UC_SLO/Images/TankLevelsLightOff");

            currentImageIndex = 0;
            animationTimer = new System.Timers.Timer(100); // Set the interval to 500ms
            animationTimer.Elapsed += OnAnimationTimerElapsed;

            // Initialize background images
            currentSiloLevel = 50; // Assuming initial tank level is 60
            SetSiloLevelImage(currentSiloLevel);

            // Start the animation timer
            animationTimer.Start();

            CommandBindings.Add(new CommandBinding(SLOLighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(SLOCameraCommand, Option2_Click));
            //CommandBindings.Add(new CommandBinding(HBYOpenValveCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(SLOStartAimationCameraCommand, Option4_Click));
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCameraOn)
            {
                MainWindow.blinkTimer2.Start();
            }
            else
            {
                MainWindow.blinkTimer2.Stop();
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
                StartPadleAnimation();
            }
            else
            {
                StopPadleAnimation();
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

        private Dictionary<int, List<Uri>> SiloTankLevelImages(string folder)
        {
            var imagesDict = new Dictionary<int, List<Uri>>();
            var directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            foreach (var file in Directory.GetFiles(directory, "*.svg"))
            {
                var fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                if (int.TryParse(fileName, out int level))
                {
                    if (!imagesDict.ContainsKey(level))
                    {
                        imagesDict[level] = new List<Uri>();
                    }
                    imagesDict[level].Add(new Uri(file, UriKind.Absolute));
                }
            }
            return imagesDict;
        }

        private void OnAnimationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (currentSiloLevel != 0)
            {
                Application.Current.Dispatcher.Invoke(() =>
                  {
                      SetSiloLevelImage(currentSiloLevel); // Use the current tank level
                      currentImageIndex = (currentImageIndex + 1) % (siloLevelImagesLightOn[currentSiloLevel].Count); // Toggle images based on the current tank level
                  });
            }
            else
            {
                TankMaterialsEmpty();
            }
        }

     

        public void SetSiloLevelImage(int tankLevel)
        {
            currentSiloLevel = tankLevel;
            labelUserCtrl.levelPercentage.Text = currentSiloLevel.ToString() + "%";

            if (tankLevel >= 20)
            {

                labelUserCtrl.svgViewboxGreenIcon.Visibility = Visibility.Visible;

                labelUserCtrl.svgViewboxRedIcon.Visibility = Visibility.Hidden;

                if (tankLevel == 20)
                {
                    labelUserCtrl.svgViewboxWarningIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    labelUserCtrl.svgViewboxWarningIcon.Visibility = Visibility.Hidden;

                }

                labelUserCtrl.svgViewboxGeerIcon.Visibility = Visibility.Hidden;

            }
            else
            {
                TankMaterialsEmpty();
            }

            var images = isLightOn ? siloLevelImagesLightOn : siloLevelImagesLightOff;
            if (images.TryGetValue(tankLevel, out var levelImages))
            {
                var imageUri = levelImages[currentImageIndex % levelImages.Count];
                svgViewbox.Source = imageUri;
            }
            else
            {
                TankMaterialsEmpty();
            }
        }

        public void StartPadleAnimation()
        {
            padle.StartSpinning();
            isAnimationOnGoing = true;
            labelUserCtrl.blinkTimerOperationOn.Start();
            labelUserCtrl.svgViewboxYellowIcon.Visibility = Visibility.Visible;
        }

        public void StopPadleAnimation()
        {
            padle.StopSpinning();
            isAnimationOnGoing = false;
            labelUserCtrl.blinkTimerOperationOn.Stop();

        }

        private void DataBasevalue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataBasevalue.SelectedItem != null)
            {
                int selectedValue = Convert.ToInt32((dataBasevalue.SelectedItem as ComboBoxItem).Content);
                SetSiloLevelImage(selectedValue);
            }
        }
        private void TankMaterialsEmpty()
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                svgViewbox.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_SLO/Images/TankLevelsLightOn/empty.svg");

                labelUserCtrl.svgViewboxRedIcon.Visibility = Visibility.Visible;
                labelUserCtrl.svgViewboxWarningIcon.Visibility = Visibility.Visible;
                labelUserCtrl.svgViewboxGeerIcon.Visibility = Visibility.Visible;

                labelUserCtrl.svgViewboxGreenIcon.Visibility = Visibility.Hidden;
                labelUserCtrl.svgViewboxYellowIcon.Visibility = Visibility.Hidden;
            });



            padle.StopSpinning();
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
                        item.Icon = "pack://application:,,,/Images/lightOn.svg";

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
                    if (isAnimationOnGoing)
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

        public void SetRotationSpeed(int percentage)
        {
            if (isAnimationOnGoing)
            {
                padle.SetRotationSpeed(percentage);
            }
        }
    }
}
