using SkiaSharp;
using Svg.Skia;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Animation;
using DotNetProjects.SVGImage.SVG.Shapes.Filter;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System.Timers;

namespace AnimPart1.Tank001
{
    /// <summary>
    /// Interaction logic for Tank001.xaml
    /// </summary>
    public partial class Tank001 : UserControl
    {
        Lights.Lights lightUserCtrl;
        Camera.Camera cameraUserCtrl;

        private List<ImageBrush> tankLevelImagesLightOn;
        private List<ImageBrush> tankLevelImagesLightOff;

        private int currentImageIndex;
        private System.Timers.Timer animationTimer;

        public Tank001()
        {
            InitializeComponent();

            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;


            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            LoadBackGroundImage("BackgroundLightOn.svg", "Tank001");

            LoadTankLevelImages("Tank001", "TankLevelsLightOn");
            LoadTankLevelImagesLightOff("Tank001", "TankLevelsLightOff");

        }

        private void LoadTankLevelImages(string folder, string subfolder)
        {
            tankLevelImagesLightOn = new List<ImageBrush>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullFolderPath = System.IO.Path.Combine(baseDirectory, folder, "Images", subfolder);

            foreach (string filePath in Directory.GetFiles(fullFolderPath, "*.svg"))
            {
                tankLevelImagesLightOn.Add(GetSvgImageBrush(filePath));
            }

            // Reverse the order of tankLevelImages
            tankLevelImagesLightOn.Reverse();
        }

        private void LoadTankLevelImagesLightOff(string folder, string subfolder)
        {
            tankLevelImagesLightOff = new List<ImageBrush>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullFolderPath = System.IO.Path.Combine(baseDirectory, folder, "Images", subfolder);

            foreach (string filePath in Directory.GetFiles(fullFolderPath, "*.svg"))
            {
                tankLevelImagesLightOff.Add(GetSvgImageBrush(filePath));
            }

            // Reverse the order of tankLevelImages
            tankLevelImagesLightOff.Reverse();
        }

        private void StartTankLevelAnimation()
        {
            if (tankLevelImagesLightOn.Count == 0)
            {
                MessageBox.Show("No images found for animation.");
                return;
            }

            currentImageIndex = 0;
            TankColumn.Background = tankLevelImagesLightOn[currentImageIndex];

            animationTimer = new System.Timers.Timer(400); // Change image every second
            animationTimer.Elapsed += OnAnimationTimerElapsed;
            animationTimer.Start();
        }

        private void OnAnimationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                currentImageIndex = (currentImageIndex + 1) % tankLevelImagesLightOn.Count;
                TankColumn.Background = tankLevelImagesLightOn[currentImageIndex];
            });
        }

        public void LoadBackGroundImage(string imagePath, string folder)
        {
            try
            {
                // Construct the full path based on the current directory and relative path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = System.IO.Path.Combine(folder, "Images", imagePath);
                string fullPath = System.IO.Path.Combine(baseDirectory, relativePath);

                // Ensure the file exists
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"The file '{fullPath}' was not found.");
                }

                // Handle SVG and other image formats
                if (System.IO.Path.GetExtension(fullPath).ToLower() == ".svg")
                {
                    ImageBrush imageBrush = GetSvgImageBrush(fullPath);
                    TankColumn.Background = imageBrush;
                }
                else
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    ImageBrush imageBrush = new ImageBrush
                    {
                        ImageSource = bitmapImage,
                        Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
                    };
                    TankColumn.Background = imageBrush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        public void ChangeBackgroundImageLights(string imagePath, string folder)
        {
            try
            {
                // Construct the full path based on the current directory and relative path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = System.IO.Path.Combine(folder, "Images", imagePath);
                string fullPath = System.IO.Path.Combine(baseDirectory, relativePath);

                // Ensure the file exists
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"The file '{fullPath}' was not found.");
                }

                // Handle SVG and other image formats
                if (System.IO.Path.GetExtension(fullPath).ToLower() == ".svg")
                {
                    ImageBrush imageBrush = GetSvgImageBrush(fullPath);

                    lightUserCtrl.Background = imageBrush;
                }
                else
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    ImageBrush imageBrush = new ImageBrush
                    {
                        ImageSource = bitmapImage,
                        Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
                    };

                    lightUserCtrl.Background = imageBrush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        public void ChangeBackgroundImageCamera(string imagePath, string folder)
        {
            try
            {
                // Construct the full path based on the current directory and relative path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = System.IO.Path.Combine(folder, "Images", imagePath);
                string fullPath = System.IO.Path.Combine(baseDirectory, relativePath);

                // Ensure the file exists
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"The file '{fullPath}' was not found.");
                }

                // Handle SVG and other image formats
                if (System.IO.Path.GetExtension(fullPath).ToLower() == ".svg")
                {
                    ImageBrush imageBrush = GetSvgImageBrush(fullPath);

                    cameraUserCtrl.Background = imageBrush;
                }
                else
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    ImageBrush imageBrush = new ImageBrush
                    {
                        ImageSource = bitmapImage,
                        Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
                    };

                    cameraUserCtrl.Background = imageBrush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        private ImageBrush GetSvgImageBrush(string svgPath)
        {
            using var svg = new SKSvg();
            svg.Load(svgPath);

            var picture = svg.Picture;
            if (picture == null)
            {
                throw new InvalidOperationException("Failed to load SVG.");
            }

            var skiaBitmap = new SKBitmap((int)picture.CullRect.Width, (int)picture.CullRect.Height);
            using var canvas = new SKCanvas(skiaBitmap);

            var scaleX = 1.0f; // Set initial scale to 1
            var scaleY = 1.0f;

            canvas.Clear(SKColors.Transparent);
            canvas.Scale(scaleX, scaleY);
            canvas.DrawPicture(picture);

            ImageBrush imageBrush = new ImageBrush(skiaBitmap.ToBitmapSource())
            {
                Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
            };
            return imageBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StartTankLevelAnimation();

        }
    }

    public static class SKBitmapExtensions
    {
        public static BitmapSource ToBitmapSource(this SKBitmap skBitmap)
        {
            IntPtr intPtr = skBitmap.GetPixels();
            return BitmapSource.Create(
                skBitmap.Width,
                skBitmap.Height,
                96,
                96,
                System.Windows.Media.PixelFormats.Pbgra32,
                null,
                intPtr,
                skBitmap.RowBytes * skBitmap.Height,
                skBitmap.RowBytes);
        }
    }

}

