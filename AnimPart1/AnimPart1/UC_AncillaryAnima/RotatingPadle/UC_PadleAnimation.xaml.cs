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
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimPart1.UC_AncillaryAnima.Rotating_Padle
{
    /// <summary>
    /// Interaction logic for UC_PadleAnimation.xaml
    /// </summary>
    public partial class UC_PadleAnimation : UserControl
    {
        public UC_PadleAnimation()
        {
            InitializeComponent();

            svgViewbox.Source = new Uri("pack://application:,,,/UC_AncillaryAnima/RotatingPadle/Images/padle.svg");

            // Start the spinning animation
            StartSpinning();
        }

        public void StartSpinning()
        {
            var storyboard = (Storyboard)this.Resources["SpinStoryboard"];
            storyboard.Begin();
        }
    }
}
