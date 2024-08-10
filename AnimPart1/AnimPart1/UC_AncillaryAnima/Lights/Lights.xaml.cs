using System.Windows.Controls;
using System.Windows;

namespace AnimPart1.Lights
{
    /// <summary>
    /// Interaction logic for Lights.xaml
    /// </summary>
    public partial class Lights : UserControl
    {

        public Lights()
        {
            InitializeComponent();
        }

        private void LighticonCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            svgViewbox.Visibility = Visibility.Hidden;
        }

     
    }
}
