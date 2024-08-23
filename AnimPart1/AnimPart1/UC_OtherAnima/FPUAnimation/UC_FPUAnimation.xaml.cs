using AnimPart1.UC_AncillaryAnima.Label;
using AnimPart1.UC_AncillaryAnima.PrimiLabel;
using AnimPart1.UC_AncillaryAnima.ScrewRotation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.FPUAnimation
{
    /// <summary>
    /// Interaction logic for UC_FPUAnimation.xaml
    /// </summary>
    public partial class UC_FPUAnimation : UserControl
    {
        public Camera.Camera cameraUserCtrl;
        public UC_PrimiLabel labelUserCtrl2;
        public Lights.Lights lightUserCtrl;

        public UC_Label labelUserCtrl;


        UC_ScrewRotation uC_ScrewRotation;

        public string labelName = "FPU-XXX";
        public bool isLightOn;
        public bool isAnimationOngoing;
        bool isCmeraOn;

        Storyboard obj1;

        Storyboard rotateStirrer;
        Storyboard obj2;
        Storyboard obj3;
        Storyboard obj4;

        DoubleAnimation angleAnimation;
        DoubleAnimation angleAnimation2;
        DoubleAnimation angleAnimation3;
        DoubleAnimation angleAnimation4;
        DoubleAnimation angleAnimation5;

        public static readonly RoutedUICommand FPULighCommand = new RoutedUICommand("", "FPULighCommand", typeof(UC_FPUAnimation));
        public static readonly RoutedUICommand FPUCameraCommand = new RoutedUICommand("", "FPUCameraCommand", typeof(UC_FPUAnimation));
        public static readonly RoutedUICommand FPUEmtpyMaterialCommand = new RoutedUICommand("", "FPUEmtpyMaterialCommand", typeof(UC_FPUAnimation));
        public static readonly RoutedUICommand FPUStartAimationCameraCommand = new RoutedUICommand("", "FPUStartAimationCameraCommand", typeof(UC_FPUAnimation));

        public UC_FPUAnimation()
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


            // Set the Source properties for the SvgViewbox controls
            backgroundSvg.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/marquee.svg");
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/background.svg");

          

            rotateStirrer = (Storyboard)this.FindResource("RotateStirrerStoryboard");

            obj1 = (Storyboard)this.FindResource("Obj1StirringStoryBoard");
            obj2 = (Storyboard)this.FindResource("Obj2StirringStoryBoard");
            obj3 = (Storyboard)this.FindResource("Obj3StirringStoryBoard");
            obj4 = (Storyboard)this.FindResource("Obj4StirringStoryBoard");

            obj1.Completed += Storyboard_Completed;

            CommandBindings.Add(new CommandBinding(FPULighCommand, Option1_Click));
            CommandBindings.Add(new CommandBinding(FPUCameraCommand, Option2_Click));
            CommandBindings.Add(new CommandBinding(FPUEmtpyMaterialCommand, Option3_Click));
            CommandBindings.Add(new CommandBinding(FPUStartAimationCameraCommand, Option4_Click));

        }

      
     
       

        public void StartStirrerRotation()
        {

            isAnimationOngoing = true;
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/background.svg");


            svgViewboxoBj1.Visibility = Visibility.Visible;
            svgViewboxoBj2.Visibility = Visibility.Visible;
            svgViewboxoBj3.Visibility = Visibility.Visible;
            svgViewboxoBj4.Visibility = Visibility.Visible;

            rotateStirrer.RepeatBehavior = RepeatBehavior.Forever;
            obj1.RepeatBehavior = RepeatBehavior.Forever;
            obj2.RepeatBehavior = RepeatBehavior.Forever;
            obj3.RepeatBehavior = RepeatBehavior.Forever;
            obj4.RepeatBehavior = RepeatBehavior.Forever;


            rotateStirrer.Begin();

            obj1.Begin();

            obj2.Begin();

            obj3.Begin();

            obj4.Begin();

            angleAnimation = (DoubleAnimation)obj1.Children[0];
            angleAnimation.From = 360;
            angleAnimation.To = 330;
            angleAnimation.AutoReverse = true;

            obj1.Begin();

            // Apply the same to the other Storyboards
            angleAnimation2 = (DoubleAnimation)obj2.Children[0];
            angleAnimation2.From = 360;
            angleAnimation2.To = 345;
            angleAnimation2.AutoReverse = true;

            obj2.Begin();

            angleAnimation3 = (DoubleAnimation)obj3.Children[0];
            angleAnimation3.From = 360;
            angleAnimation3.To = 340;
            angleAnimation3.AutoReverse = true;

            obj3.Begin();

            angleAnimation4 = (DoubleAnimation)obj4.Children[0];
            angleAnimation4.From = 360;
            angleAnimation4.To = 350;
            angleAnimation4.AutoReverse = true;

            obj4.Begin();

            angleAnimation5 = (DoubleAnimation)rotateStirrer.Children[0];
            angleAnimation5.From = 0;
            angleAnimation5.To = 180;
            angleAnimation5.Duration = new Duration(TimeSpan.FromSeconds(4));

            angleAnimation5.AutoReverse = false;

            rotateStirrer.Begin();

        }
        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            backgroundSvg.Visibility = Visibility.Visible;
            this.Focus();
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

                    if (isLightOn)
                    {
                        item.Header = "Light Off";
                    }
                    else
                    {
                        item.Header = "Light on";
                    }
                } else if (item.Name == "menuItem2")
                {
                    if (isCmeraOn) {

                        item.Header = "Camera Off";

                    }
                    else
                    {
                        item.Header = "Camera On";
                    }

                }
                else if (item.Name == "menuItem4")
                {
                    if (isAnimationOngoing)
                    {

                        item.Header = "Stop Stirring";

                    }
                    else
                    {
                        item.Header = "Start Stirring";
                    }

                }
                else if (item.Name == "menuItem3")
                {

                    item.Header = "Empty Materials";

                }

                contextMenu.IsOpen = true;
            }
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

            ToggleLight();

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {

            if (!isCmeraOn)
            {
                MainWindow.blinkTimer11.Start();
            }
            else
            {
                MainWindow.blinkTimer11.Stop();

            }

            isCmeraOn = !isCmeraOn;
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            EmptyMaterial();
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {

            if (!isAnimationOngoing) {

                StartStirrerRotation();
            }
            else
            {
                StopAnimation();
            }
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

      

        public void StopAnimation()
        {

            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/background.svg");

            obj1.Stop();
            obj2.Stop();
            obj3.Stop();
            obj4.Stop();
            rotateStirrer.Stop();
            BackgroundGrid2RotateTransform.Angle = 0;
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
       
        public void EmptyMaterial()
        {
            // Stop any ongoing animations
            obj1.Stop();
            obj2.Stop();
            obj3.Stop();
            obj4.Stop();
            rotateStirrer.Stop();
          
            // Make sure the SVG elements are visible
            svgViewboxoBj1.Visibility = Visibility.Visible;
            svgViewboxoBj2.Visibility = Visibility.Visible;
            svgViewboxoBj3.Visibility = Visibility.Visible;
            svgViewboxoBj4.Visibility = Visibility.Visible;

            // Set the initial state
            BackgroundGrid2RotateTransform.Angle = -60;
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/RemovingMaterials.svg");

            // Modify the animations to run only once
            angleAnimation = (DoubleAnimation)obj1.Children[0];
            angleAnimation.From = 360;
            angleAnimation.To = 220;
            obj1.RepeatBehavior = new RepeatBehavior(1);  // Run once
            angleAnimation.AutoReverse = false;

            obj1.Begin();

            // Apply the same to the other Storyboards
             angleAnimation2 = (DoubleAnimation)obj2.Children[0];
            angleAnimation2.From = 360;
            angleAnimation2.To = 250;
            obj2.RepeatBehavior = new RepeatBehavior(1);  // Run once
            angleAnimation2.AutoReverse = false;

            obj2.Begin();

             angleAnimation3 = (DoubleAnimation)obj3.Children[0];
            angleAnimation3.From = 360;
            angleAnimation3.To = 250;
            obj3.RepeatBehavior = new RepeatBehavior(1);  // Run once
            angleAnimation3.AutoReverse = false;

            obj3.Begin();

             angleAnimation4 = (DoubleAnimation)obj4.Children[0];
            angleAnimation4.From = 360;
            angleAnimation4.To = 250;
            obj4.RepeatBehavior = new RepeatBehavior(1);  // Run once
            angleAnimation4.AutoReverse = false;

            obj4.Begin();

            angleAnimation5 = (DoubleAnimation)rotateStirrer.Children[0];
            angleAnimation5.From = 0;
            angleAnimation5.To = 120;
            angleAnimation5.Duration = new Duration(TimeSpan.FromSeconds(1));
            rotateStirrer.RepeatBehavior = new RepeatBehavior(1);  // Run once
            angleAnimation5.AutoReverse = false;

            rotateStirrer.Begin();
        }




        private void Storyboard_Completed(object sender, EventArgs e)
        {
           
            svgViewbox.Source = new Uri("pack://application:,,,/UC_OtherAnima/FPUAnimation/Images/Empty.svg");
            BackgroundGrid2RotateTransform.Angle = 0;

            svgViewboxoBj1.Visibility = Visibility.Collapsed;
            svgViewboxoBj2.Visibility = Visibility.Collapsed;
            svgViewboxoBj3.Visibility = Visibility.Collapsed;
            svgViewboxoBj4.Visibility = Visibility.Collapsed;

            rotateStirrer.Stop();
        }
    }
}
