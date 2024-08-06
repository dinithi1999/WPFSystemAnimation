﻿using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.Rotating_Padle
{
    public partial class UC_PadleAnimation : UserControl
    {

        private const double BaseDurationSeconds = 1.0;

        public UC_PadleAnimation()
        {
            InitializeComponent();

        }

        public void StartSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["SpinStoryboard"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Begin();

            }
            else
            {
                // Handle null storyboard (e.g., log error, throw exception, etc.)
            }

         
        }

        public void StopSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["SpinStoryboard"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Stop();
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


            var spinStoryboard = (Storyboard)this.Resources["SpinStoryboard"];
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

