using SkiaSharp;
using Svg.Skia;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Windows.Media.Imaging;
using SkiaSharp;
using System.IO;
using System.Windows;

namespace AnimPart1.Lights
{
    /// <summary>
    /// Interaction logic for Lights.xaml
    /// </summary>
    public partial class Lights : UserControl
    {

        private ImageBrush lightOnBrush;
        private ImageBrush lightOffBrush;

        public Lights()
        {
            InitializeComponent();
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
                    MainCanvas.Background = GetSvgImageBrush(fullPath);
                }
                else
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    MainCanvas.Background = imageBrush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        private void LoadSvgImages()
        {
            lightOnBrush = GetSvgImageBrush("Images/LightBulbOn.svg");
            lightOffBrush = GetSvgImageBrush("Images/LightBulbOff.svg");
            //LightBulbImage.Source = lightOffBrush.ImageSource;
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

            var skiaBitmap = new SKBitmap((int)Width, (int)Height);
            using var canvas = new SKCanvas(skiaBitmap);

            var scaleX = (float)Width / picture.CullRect.Width;
            var scaleY = (float)Height / picture.CullRect.Height;
            var scale = Math.Min(scaleX, scaleY);

            canvas.Clear(SKColors.Transparent);
            canvas.Scale(scale);
            canvas.DrawPicture(picture);

            IntPtr intPtr = skiaBitmap.GetPixels();
            BitmapSource bitmapSource = BitmapSource.Create(
                skiaBitmap.Width,
                skiaBitmap.Height,
                96,
                96,
                System.Windows.Media.PixelFormats.Pbgra32,
                null,
                intPtr,
                skiaBitmap.RowBytes * skiaBitmap.Height,
                skiaBitmap.RowBytes);

            return new ImageBrush(bitmapSource);
        }

        public void TurnOn()
        {
            //LightBulbImage.Source = lightOnBrush.ImageSource;
        }

        public void TurnOff()
        {
            //LightBulbImage.Source = lightOffBrush.ImageSource;
        }
    }
}
