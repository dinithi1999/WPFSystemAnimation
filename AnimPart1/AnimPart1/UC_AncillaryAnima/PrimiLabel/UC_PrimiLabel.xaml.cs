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

namespace AnimPart1.UC_AncillaryAnima.Lights
{
    /// <summary>
    /// Interaction logic for UC_PrimiLabel.xaml
    /// </summary>
    public partial class UC_PrimiLabel : UserControl
    {
        public UC_PrimiLabel()
        {
            InitializeComponent();
        }


        private void LabelIconCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Visibility = Visibility.Hidden;
        }
    }
}
