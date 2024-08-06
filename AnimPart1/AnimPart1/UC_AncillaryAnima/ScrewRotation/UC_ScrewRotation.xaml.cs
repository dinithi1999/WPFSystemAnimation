using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.ScrewRotation
{
    public partial class UC_ScrewRotation : UserControl
    {
        public UC_ScrewRotation()
        {
            InitializeComponent();
        }

        public void StartSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["RotateStoryboard"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Begin();

            }

        }

        public void StopSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["RotateStoryboard"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Stop();
            }

        }


        public void SetRotationDirection(bool clockwise)
        {
            var spinStoryboard = (Storyboard)this.Resources["RotateStoryboard"];
            if (spinStoryboard != null)
            {
                var animation = spinStoryboard.Children[0] as DoubleAnimation;

                if (animation != null)
                {
                    if (clockwise)
                    {
                        animation.From = 360;
                        animation.To = 0;
                    }
                    else
                    {
                        animation.From = 0;
                        animation.To = 360;
                    }
                }
            }
        }
    }
}
