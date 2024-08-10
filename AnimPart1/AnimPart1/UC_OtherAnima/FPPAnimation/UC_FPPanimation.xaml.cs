using AnimPart1.UC_AncillaryAnima.FPUAnimation;
using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimPart1.UC_AncillaryAnima.FPPAnimation
{
    /// <summary>
    /// Interaction logic for UC_FPAAnimation.xaml
    /// </summary>
    public partial class UC_FPPAnimation : UserControl
    {
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl;
        public UC_Label labelUserCtrl;
        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "PMP-XXX";
        public bool isLightOn;
        public bool isAnimationOngoing;

        public UC_FPPAnimation()
        {
            InitializeComponent();
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
                    item.Header = "Updated Option 1"; 

                    if (isLightOn)
                    {
                        item.Header = "Light Off"; 
                    }
                    else
                    {
                        item.Header = "Light on"; 
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
            isAnimationOngoing = true;
        }

        public void StopSpinning()
        {
            uC_ScrewRotation.StopSpinning();
            isAnimationOngoing = false;
        }

        public void SetRotationDirection(bool clockwise)
        {
            uC_ScrewRotation.SetRotationDirection(clockwise);
        }

        public void SetRotationSpeed(int percentage)
        {
            if (isAnimationOngoing)
            {
                uC_ScrewRotation.SetRotationSpeed(percentage);
            }
        }

        public static implicit operator UC_FPPAnimation(UC_FPUAnimation v)
        {
            throw new NotImplementedException();
        }
    }
}
