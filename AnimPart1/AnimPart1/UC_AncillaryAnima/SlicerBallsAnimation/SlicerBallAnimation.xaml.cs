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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            StartAnimations();
        }

        private void StartAnimations()
        {
            var fallingStoryboard = (Storyboard)this.Resources["FallingAnimation"];

            fallingStoryboard.Begin();
            
        }
    }
}
