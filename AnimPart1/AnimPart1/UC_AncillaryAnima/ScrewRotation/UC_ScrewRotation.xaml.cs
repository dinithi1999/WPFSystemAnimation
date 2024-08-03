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

            Loaded += UC_ScrewRotation_Loaded;

        }

        private void UC_ScrewRotation_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.Resources["RotateStoryboard"];
            storyboard.Begin();
        }
    }
}
