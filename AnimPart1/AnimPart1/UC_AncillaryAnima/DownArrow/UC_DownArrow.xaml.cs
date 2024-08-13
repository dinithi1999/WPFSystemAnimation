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

namespace AnimPart1.UC_AncillaryAnima.DownArrow
{
    /// <summary>
    /// Interaction logic for UC_DownArrow.xaml
    /// </summary>
    public partial class UC_DownArrow : UserControl
    {
        public UC_DownArrow()
        {
            InitializeComponent();

            var arrowDown = (Storyboard)this.Resources["GreenArrowDown"];

            arrowDown.Begin();
        }
    }
}
