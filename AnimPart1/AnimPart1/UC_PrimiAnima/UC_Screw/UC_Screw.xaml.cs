using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AnimPart1.UC_AncillaryAnima.Lights;
using AnimPart1.UC_AncillaryAnima.Label;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_PrimiAnima.UC_Screw
{
    /// <summary>
    /// Interaction logic for UC_Screw.xaml
    /// </summary>
    public partial class UC_Screw : UserControl
    {

        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public UC_Label labelUserCtrl;

        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "SRW-XXX";
        public bool isLightOn;
        public bool isAnimationOnGoing;


        public UC_Screw()
        {
            InitializeComponent();


            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;


            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            uC_ScrewRotation = new UC_ScrewRotation();
            PadleColumn.Content = uC_ScrewRotation;
            uC_ScrewRotation.backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwRotatingPart.svg");

            labelUserCtrl2 = new UC_PrimiLabel();
            labelColumn2.Content = labelUserCtrl2;


            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;

            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwmarquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Screw/Images/screwBackground.svg");
        }

        
     
        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
        }


        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Collapsed;
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var contextMenu = (ContextMenu)this.Resources["ContextMenu1"];

            foreach (MenuItem item in contextMenu.Items)
            {
                if (item.Name == "menuItem1")
                {
                    item.Header = "Updated Option 1"; // Update header text

                    if (isLightOn)
                    {
                        item.Header = "Light Off"; // Update header text
                    }
                    else
                    {
                        item.Header = "Light on"; // Update header text
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

        public void StartSpinning()
        {
            uC_ScrewRotation.StartSpinning();
            isAnimationOnGoing = true;
        }

        public void StopSpinning()
        {
            uC_ScrewRotation.StopSpinning();
            isAnimationOnGoing = false;
        }

        public void SetRotationDirection(bool clockwise)
        {
            uC_ScrewRotation.SetRotationDirection(clockwise);
        }

        public void SetRotationSpeed(int percentage)
        {
            if (isAnimationOnGoing)
            {
                uC_ScrewRotation.SetRotationSpeed(percentage);
            }       
        }


    }
}
