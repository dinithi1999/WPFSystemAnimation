using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
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
using AnimPart1.UC_AncillaryAnima.Lights;


namespace AnimPart1.UC_AncillaryAnima.LOCAnimation
{
    /// <summary>
    /// Interaction logic for UC_LOC.xaml
    /// </summary>
    public partial class UC_LOC : UserControl
    {
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;

        public UC_Label labelUserCtrl;


        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "PMP-XXX";
        public bool isLightOn;
        public bool isAnimationOngoing;

        public UC_LOC()
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
            //if (isLightOn)
            //{
            //    lightUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOff.svg");
            //    isLightOn = false;
            //}
            //else
            //{
            //    lightUserCtrl.svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/Lights/Images/LightOn.svg");
            //    isLightOn = true;
            //}
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
    }
}
