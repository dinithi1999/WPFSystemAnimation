using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.ScrewRotation
{
    public partial class UC_ScrewRotation : UserControl
    {
        private const double BaseDurationSeconds = 2.0;
        public DoubleAnimation animation;
        public DoubleAnimation animation2;

        public Storyboard spinStoryboard;
        public Storyboard spinStoryboard2;

        public double rotateFrom =360 ;
        public double rotateT0 = 0;

        public bool isAntiClockWise = false;

        public UC_ScrewRotation()
        {
            InitializeComponent();
           
            spinStoryboard = (Storyboard)this.Resources["RotateStoryboard"];
            spinStoryboard2 = (Storyboard)this.Resources["RotateStoryboardStars"];

            animation = spinStoryboard.Children[0] as DoubleAnimation;
            animation2 = spinStoryboard2.Children[0] as DoubleAnimation;

        }

        public void StartSpinning()
        {
            animation.From = rotateFrom;
            animation.To = rotateT0;

            animation2.From = rotateFrom;
            animation2.To = rotateT0;

            if (spinStoryboard != null)
            {
                spinStoryboard.Begin();
                spinStoryboard2.Begin();
            }

        }

        public void StopSpinning()
        {

            if (spinStoryboard != null)
            {
                spinStoryboard.Stop();
                spinStoryboard2.Stop();

            }

        }


        public void SetRotationDirection(bool isAnticlockwise)
        {

            isAntiClockWise = isAnticlockwise;

            if (spinStoryboard != null)
            {
                if (animation != null)
                {
                    if (isAnticlockwise)
                    {
                        rotateFrom = 360;
                        rotateT0 = 0;
                    }
                    else
                    {
                        rotateFrom = 0;
                        rotateT0 = 360;
                    }
                }
            }
        }

        public void SetRotationSpeed(int percentage)
        {

            if (percentage == 0)
            {
                percentage = 100; //for 100 no rotation, this is a bug need to fix

            }
            else if (percentage == 100)
            {
                percentage = 99; // need to rewrite the code, 100 srew not rotating
            }

            // Ensure percentage is between 0 and 100
            percentage = Math.Max(0, Math.Min(100, percentage));

            // Calculate duration based on percentage
            double speedFactor = 100 - percentage; // Higher percentage means slower speed
            double newDurationSeconds = BaseDurationSeconds * (speedFactor / 100.0);


            var spinStoryboard = (Storyboard)this.Resources["RotateStoryboard"];
            if (spinStoryboard != null)
            {
                var animation = spinStoryboard.Children[0] as DoubleAnimation;

                if (animation != null)
                {

                    animation.Duration = TimeSpan.FromSeconds(newDurationSeconds);

                    spinStoryboard.Begin();
                }
            }
        }
    }
}
