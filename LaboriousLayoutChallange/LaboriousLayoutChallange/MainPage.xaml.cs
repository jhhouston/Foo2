using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaboriousLayoutChallange
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //-> Here in constructor access My.Frame.Navigate method this should load in page 1
            MainFrame.Navigate(typeof(Donut));
        }
     
        private void Donut_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Donut));
        }

        private void Coffee_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Coffee));
        }

        private void Schedule_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Schedule));
        }

        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Complete));
        }
    }
}
