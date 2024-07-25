using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.Rotating_Padle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace AnimPart1.UC_DepenAnima.UC_Hopper
{
    public partial class UC_Hopper : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        UC_PadleAnimation padle;
        public UC_Label labelUserCtrl;

        private Dictionary<int, List<Uri>> hoppersLevelImagesLightOn;
        private Dictionary<int, List<Uri>> hopperLevelImagesLightOff;

        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;

        private int currentHopperLevel; // Keep track of the current tank level

        public string labelName = "Hopper 00X";

        public UC_Hopper()
        {
            InitializeComponent();

            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            padle = new UC_PadleAnimation();
            PadleColumn.Content = padle;

            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;



            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_Hopper/Images/DepenBackgroundBlueBorder.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_Hopper/Images/BackgroundLightOff.svg");

            // Initialize the dictionaries
            hoppersLevelImagesLightOn = LoadHopperLevelImages("UC_DepenAnima/UC_Hopper/Images/TankLevelsLightOn");
            hopperLevelImagesLightOff = LoadHopperLevelImages("UC_DepenAnima/UC_Hopper/Images/TankLevelsLightOff");

            currentImageIndex = 0;
            animationTimer = new System.Timers.Timer(1); // Set the interval to 500ms
            animationTimer.Elapsed += OnAnimationTimerElapsed;

            // Initialize background images
            currentHopperLevel = 30; // Assuming initial tank level is 60
            SetHopperLevelImage(currentHopperLevel);


            // Start the animation timer
            animationTimer.Start();
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
        }

        private Dictionary<int, List<Uri>> LoadHopperLevelImages(string folder)
        {
            var imagesDict = new Dictionary<int, List<Uri>>();
            var directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            foreach (var file in Directory.GetFiles(directory, "*.svg"))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
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
            if (currentHopperLevel != 0)
            {

                Application.Current.Dispatcher.Invoke(() =>
                {
                    SetHopperLevelImage(currentHopperLevel); // Use the current tank level
                    currentImageIndex = (currentImageIndex + 1) % (hoppersLevelImagesLightOn[currentHopperLevel].Count); // Toggle images based on the current tank level
                });
            }
            else {
                TankMaterialsEmpty();

            }
        }

        public void SetHopperLevelImage(int tankLevel)
        {
            currentHopperLevel = tankLevel; // Update the current tank level
            labelUserCtrl.levelPercentage.Text =currentHopperLevel.ToString() +"%";

           if (tankLevel >= 20) {

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

            var images = isLightOn ? hoppersLevelImagesLightOn : hopperLevelImagesLightOff;
            if (images.TryGetValue(tankLevel, out var levelImages))
            {
                var imageUri = levelImages[currentImageIndex % levelImages.Count];
                svgViewbox.Source = imageUri;

            }
            else {

                TankMaterialsEmpty();


            }
        }

        public void StartPadleAnimation()
        {
            padle.StartSpinning();
            labelUserCtrl.blinkTimerOperationOn.Start();
            labelUserCtrl.svgViewboxYellowIcon.Visibility = Visibility.Visible;

        }

        public void StopPadleAnimation()
        {
            padle.StopSpinning();
            labelUserCtrl.blinkTimerOperationOn.Stop();

        }
        private void TankMaterialsEmpty()
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                svgViewbox.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_Hopper/Images/TankLevelsLightOn/empty.svg");

                labelUserCtrl.svgViewboxRedIcon.Visibility = Visibility.Visible;
                labelUserCtrl.svgViewboxWarningIcon.Visibility = Visibility.Visible;
                labelUserCtrl.svgViewboxGeerIcon.Visibility = Visibility.Visible;

                labelUserCtrl.svgViewboxGreenIcon.Visibility = Visibility.Hidden;
                labelUserCtrl.svgViewboxYellowIcon.Visibility = Visibility.Hidden;
            });



            padle.StopSpinning();
        }


        private void DataBasevalue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataBasevalue.SelectedItem != null)
            {
                int selectedValue = Convert.ToInt32((dataBasevalue.SelectedItem as ComboBoxItem).Content);
                SetHopperLevelImage(selectedValue);
            }
        }

    }
}
