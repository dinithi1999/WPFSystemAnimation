﻿using AnimPart1.UC_AncillaryAnima.Label;
using System;
using System.Collections.Generic;
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

namespace AnimPart1.UC_PrimiAnima.UC_Slicer
{
    /// <summary>
    /// Interaction logic for UC_Slicer.xaml
    /// </summary>
    public partial class UC_Slicer : UserControl
    {

        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_Label labelUserCtrl;

        private Dictionary<int, List<Uri>> hoppersLevelImagesLightOn;
        private Dictionary<int, List<Uri>> hopperLevelImagesLightOff;

        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;

        private int currentHopperLevel; // Keep track of the current tank level

        public string labelName = "Slicer 00X";
        public ICommand ToggleLightCommand { get; }


        public UC_Slicer()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

      
            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;

            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerMarquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerbackground.svg");
          
            // Start the animation timer
        }


        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
        }


        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            ;
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ;

        }
    }
}
