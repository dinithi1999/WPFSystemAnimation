using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimPart1.UC_AncillaryAnima.Rotating_Padle
{
    public partial class UC_PadleAnimation : UserControl
    {
        public UC_PadleAnimation()
        {
            InitializeComponent();
        }

        public void StartSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["SpinStoryboard"];
            var spinStoryboard2 = (Storyboard)this.Resources["SpinStoryboard2"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Begin();
            }
            else
            {
                // Handle null storyboard (e.g., log error, throw exception, etc.)
            }

            if (spinStoryboard2 != null)
            {
                spinStoryboard2.Begin(); // Start the storyboard for arrows
            }
            else
            {
                // Handle null storyboard (e.g., log error, throw exception, etc.)
            }
        }

        public void StopSpinning()
        {
            var spinStoryboard = (Storyboard)this.Resources["SpinStoryboard"];
            var spinStoryboard2 = (Storyboard)this.Resources["SpinStoryboard2"];

            if (spinStoryboard != null)
            {
                spinStoryboard.Stop();
            }

            if (spinStoryboard2 != null)
            {
                spinStoryboard2.Stop(); // Stop the storyboard for arrows
            }
        }
    }
}

