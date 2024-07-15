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

namespace AnimPart1.Tank001
{
    /// <summary>
    /// Interaction logic for Tank001.xaml
    /// </summary>
    public partial class Tank001 : UserControl
    {
        Lights.Lights userControl2;

        public Tank001()
        {
            InitializeComponent();

            userControl2 = new Lights.Lights();
            lightColumn.Content = userControl2;

            LoadBackGroundImage("BackgroundLightOn.svg", "Tank001");
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

        public void LoadBackGroundImage2(string imagePath, string folder)
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
                    lightColumn.Background = imageBrush;
                }
                else
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    ImageBrush imageBrush = new ImageBrush
                    {
                        ImageSource = bitmapImage,
                        Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
                    };
                    lightColumn.Background = imageBrush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }
        // Helper method to get dimensions of an SVG image





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
                    userControl2.Background = imageBrush;
                }
                else
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    ImageBrush imageBrush = new ImageBrush
                    {
                        ImageSource = bitmapImage,
                        Stretch = Stretch.Uniform // Set to Uniform or UniformToFill based on your requirement
                    };
                    userControl2.Background = imageBrush;
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

