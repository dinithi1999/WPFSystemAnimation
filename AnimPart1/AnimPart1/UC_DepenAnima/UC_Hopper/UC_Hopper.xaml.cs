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
        private Dictionary<int, List<Uri>> tankLevelImagesLightOn;
        private Dictionary<int, List<Uri>> tankLevelImagesLightOff;
        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;
        private int currentTankLevel; // Keep track of the current tank level

        public UC_Hopper()
        {
            InitializeComponent();

            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            padle = new UC_PadleAnimation();
            PadleColumn.Content = padle;

            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_Hopper/Images/DepenBackgroundBlueBorder.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_DepenAnima/UC_Hopper/Images/BackgroundLightOff.svg");

            // Initialize the dictionaries
            tankLevelImagesLightOn = LoadTankLevelImages("UC_DepenAnima/UC_Hopper/Images/TankLevelsLightOn");
            tankLevelImagesLightOff = LoadTankLevelImages("UC_DepenAnima/UC_Hopper/Images/TankLevelsLightOff");

            currentImageIndex = 0;
            animationTimer = new System.Timers.Timer(500); // Set the interval to 500ms
            animationTimer.Elapsed += OnAnimationTimerElapsed;

            // Initialize background images
            currentTankLevel = 60; // Assuming initial tank level is 60
            SetTankLevelImage(currentTankLevel);

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

        private Dictionary<int, List<Uri>> LoadTankLevelImages(string folder)
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
            Application.Current.Dispatcher.Invoke(() =>
            {
                SetTankLevelImage(currentTankLevel); // Use the current tank level
                currentImageIndex = (currentImageIndex + 1) % (tankLevelImagesLightOn[currentTankLevel].Count); // Toggle images based on the current tank level
            });
        }

        public void SetTankLevelImage(int tankLevel)
        {
            currentTankLevel = tankLevel; // Update the current tank level
            var images = isLightOn ? tankLevelImagesLightOn : tankLevelImagesLightOff;
            if (images.TryGetValue(tankLevel, out var levelImages))
            {
                var imageUri = levelImages[currentImageIndex % levelImages.Count];
                svgViewbox.Source = imageUri;
            }
        }
    }
}
