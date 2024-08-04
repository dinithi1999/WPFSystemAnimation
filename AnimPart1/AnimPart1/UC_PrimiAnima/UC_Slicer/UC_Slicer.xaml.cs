using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.Lights;
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
        public UC_PrimiLabel labelUserCtrl2;
        public UC_Label labelUserCtrl;



        private int currentImageIndex;
        private System.Timers.Timer animationTimer;
        public bool isLightOn;

        private int currentHopperLevel; // Keep track of the current tank level

        public string labelName = "SLC XXX";
        public ICommand ToggleLightCommand { get; }


        public UC_Slicer()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

      
            labelUserCtrl2 = new UC_PrimiLabel();
            labelColumn2.Content = labelUserCtrl2;

            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;

            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerMarquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Slicer/Images/slicerbackground.svg");
          
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
