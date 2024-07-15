using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AnimPart1.Tank001.Tank001 tank001Control;

        CurrentState level  = CurrentState.eighty;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                tank001Control = new AnimPart1.Tank001.Tank001();

                //// Set alignment properties
                //tank001Control.HorizontalAlignment = HorizontalAlignment.non;
                //tank001Control.VerticalAlignment = VerticalAlignment.Stretch;

                // Add Tank001 to ContentControl in the third column of the Grid
                ThirdColumn.Content = tank001Control;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            // Handle toggle button checked event
            ToggleButton toggleButton = sender as ToggleButton;
            toggleButton.Background = new SolidColorBrush(Colors.Green);


            MessageBox.Show($"{toggleButton.Content} is ON");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // Handle toggle button unchecked event
            ToggleButton toggleButton = sender as ToggleButton;
            toggleButton.Background = new SolidColorBrush(Colors.Red);


            MessageBox.Show($"{toggleButton.Content} is OFF");
        }


        private void HopperLightChecked_Checked(object sender, RoutedEventArgs e)
        {
            tank001Control.ChangeBackgroundImageLights("LightOn.svg", "Lights");
        }

        private void HopperLightChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            tank001Control.ChangeBackgroundImageLights("LightOff.svg", "Lights");
        }


        private void HopperCameraChecked_Checked(object sender, RoutedEventArgs e)
        {
            tank001Control.ChangeBackgroundImageCamera("CameraFlashOn.svg", "Camera");

        }

        private void HopperCameraChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            tank001Control.ChangeBackgroundImageCamera("CameraFlashOff.svg", "Camera");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }

    enum CurrentState
    {
       eighty,
       seventy
    }
}