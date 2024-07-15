using SkiaSharp;
using Svg.Skia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimPart1.Camera
{
    /// <summary>
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : UserControl
    {
        public Camera()
        {
            InitializeComponent();

            ChangeBackgroundImageLights("CameraFlashOn.svg", "Camera");

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
