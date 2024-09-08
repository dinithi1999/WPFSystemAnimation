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

namespace AnimPart1.UC_OtherAnima.Pipes
{
    /// <summary>
    /// Interaction logic for UserControlBluePipes.xaml
    /// </summary>
    public partial class UserControlBluePipes : UserControl
    {
        public UserControlBluePipes()
        {
            InitializeComponent();
        }

        private void StartPippeAnimation()
        {
            var piplePulses = (Storyboard)this.Resources["pulse1Animation"];
            piplePulses.Begin();

        }
    }
}
