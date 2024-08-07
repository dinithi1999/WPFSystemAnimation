using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.SlicerBallsAnimation
{
    public partial class SlicerBallAnimation : UserControl
    {
        public SlicerBallAnimation()
        {
            InitializeComponent();
        }

     

        public void StartAnimations()
        {
            svgViewboxRedBall1.Visibility = Visibility.Visible;
            svgViewboxRedBall2.Visibility = Visibility.Visible;

            // Get the storyboards
            var redBall1FallingAnimation = (Storyboard)this.Resources["RedBall1FallingAnimation"];
            var firsrOrangeBallFallingAnimation = (Storyboard)this.Resources["FirsrOrangeBallFallingAnimation"];
            var redBall2FallingAnimation = (Storyboard)this.Resources["RedBall2FallingAnimation"];
            var orangeBallsDroppingOutOfSlicerAnimation = (Storyboard)this.Resources["OrangeBallsDroppingOutOfSlicerAnimation"];
            var secondOrangeBallFallingAnimation = (Storyboard)this.Resources["SecondOrangeBallFallingAnimation"];

            // Set up the Completed events for the storyboards
            //redBall1FallingAnimation.Completed += (s, e) =>
            //{
            //    // Begin the second animation after the first one completes
            //    firsrOrangeBallFallingAnimation.Begin();
            //    secondOrangeBallFallingAnimation.Begin();

            //};

            // Start the first animation
            redBall1FallingAnimation.Begin();
            redBall2FallingAnimation.Begin();
            orangeBallsDroppingOutOfSlicerAnimation.Begin();

            firsrOrangeBallFallingAnimation.Begin();
            secondOrangeBallFallingAnimation.Begin();


        }

        public void StopAnimations()
        {
            svgViewboxRedBall1.Visibility = Visibility.Hidden;
            svgViewboxRedBall2.Visibility = Visibility.Hidden;

            // Get the storyboards
            var redBall1FallingAnimation = (Storyboard)this.Resources["RedBall1FallingAnimation"];
            var firsrOrangeBallFallingAnimation = (Storyboard)this.Resources["FirsrOrangeBallFallingAnimation"];
            var redBall2FallingAnimation = (Storyboard)this.Resources["RedBall2FallingAnimation"];
            var orangeBallsDroppingOutOfSlicerAnimation = (Storyboard)this.Resources["OrangeBallsDroppingOutOfSlicerAnimation"];
            var secondOrangeBallFallingAnimation = (Storyboard)this.Resources["SecondOrangeBallFallingAnimation"];

        
            redBall1FallingAnimation.Stop();
            redBall2FallingAnimation.Stop();
            orangeBallsDroppingOutOfSlicerAnimation.Stop();

            firsrOrangeBallFallingAnimation.Stop();
            secondOrangeBallFallingAnimation.Stop();


        }
    }
}
