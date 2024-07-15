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
    }
}
