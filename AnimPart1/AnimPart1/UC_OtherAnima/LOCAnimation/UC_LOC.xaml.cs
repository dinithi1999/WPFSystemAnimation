using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace AnimPart1.UC_AncillaryAnima.LOCAnimation
{
    /// <summary>
    /// Interaction logic for UC_LOC.xaml
    /// </summary>
    public partial class UC_LOC : UserControl
    {
        public Lights.Lights lightUserCtrl;
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl2;

        public UC_Label labelUserCtrl;


        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "LOC-XXX";
        public bool isLightOn;
        public bool isAnimationOngoing;

        Storyboard collectorMovement;
        DoubleAnimation collectorAnimation;

        Storyboard collectorCarrierTextMovement;
        DoubleAnimation collectorTEXTAnimation;

        double destinationXPos = 0;

        private bool isAnimationOnGoing;

    

        public UC_LOC()
        {

            InitializeComponent();

            lightUserCtrl = new Lights.Lights();
            lightColumn.Content = lightUserCtrl;

            cameraUserCtrl = new Camera.Camera();
            CameraColumn.Content = cameraUserCtrl;

            labelUserCtrl = new UC_Label();
            labelColumn.Content = labelUserCtrl;
            labelUserCtrl.labelName.Text = labelName;
            labelUserCtrl.levelPercentage.Visibility = Visibility.Hidden;



        }



        public void StartAnimation()
        {
            collectorMovement = (Storyboard)this.Resources["CollectorMovement"];
            collectorAnimation = (DoubleAnimation)collectorMovement.Children[0]; 

            collectorCarrierTextMovement = (Storyboard)this.Resources["CollectortextboxMovement"];
            collectorTEXTAnimation = (DoubleAnimation)collectorCarrierTextMovement.Children[0];


            MainWindow.arrowUpDownHBY.Visibility = Visibility.Hidden;
            MainWindow.arrowUCIinstance.Visibility = Visibility.Hidden;
            MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner0.svg");
            MainWindow.ChangeVisibilityOfPortionerArrow(false);

            isAnimationOngoing = true;

            if (collectorMovement != null && collectorAnimation != null && collectorCarrierTextMovement != null && collectorTEXTAnimation != null)
            {
                collectorAnimation.From = translateTransformCollector.X;
                collectorAnimation.To = destinationXPos;

                collectorTEXTAnimation.From = translateTransformCollectortexybox.X;
                collectorTEXTAnimation.To = destinationXPos;

                collectorMovement.Completed += CollectorMovement_Completed;


                collectorMovement.Begin();
                collectorCarrierTextMovement.Begin();


            }

        }


        public void StopAnimation()
        {
            isAnimationOngoing = false;

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

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Content.ToString();

                switch (selectedValue)
                {
                    case "0 ":
                        destinationXPos = -0;
                        break;

                    case "1":
                        destinationXPos = -60;
                        break;

                    case "2":
                        destinationXPos = -120;
                        break;

                    case "3":
                        destinationXPos = -180;
                        break;

                    case "4":
                        destinationXPos = -240;
                        break;

                    case "5":
                        destinationXPos = -300;
                        break;

                    case "6":
                        destinationXPos = -365;
                        break;

                    case "7":
                        destinationXPos = -425;
                        break;

                    case "8":
                        destinationXPos = -485;
                        break;

                    case "9":
                        destinationXPos = -545;
                        break;

                    case "10":

                        destinationXPos = -600;

                        break;

                    default:
                        // Handle any unexpected cases
                        break;
                }
            }
        }

        private void CollectorMovement_Completed(object sender, EventArgs e)
        {
            if (destinationXPos == -300)
            {
                MainWindow.arrowUCIinstance.Visibility = Visibility.Visible;

            }else if (destinationXPos == -600)
            {
                MainWindow.arrowUpDownHBY.Visibility = Visibility.Visible;

            }
            else if(destinationXPos == -425)
            {
                //just below slicer
            }else if(destinationXPos == -60)
            {
                MainWindow.portionerUCInstance.svgViewbox.Source = new Uri("pack://application:,,,/UC_PrimiAnima/UC_Portioner/Images/portioner180.svg");
                MainWindow.ChangeVisibilityOfPortionerArrow(true);
            }
        }
    }


}
