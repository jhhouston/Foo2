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

namespace HambergerHavenChallange
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
            MyFrame.Navigate(typeof(Financial));
            TitleTextBlock.Text = "Financial"; //will appear as page title
            BackButton.Visibility = Visibility.Collapsed;//managing state of back button
            Financial.IsSelected = true; // even if we are not clicking on the list box item it will still show it as current selected page.

        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <summary>
            ///     Decision making based on menu item selected
            /// </summary>
            
            if (Financial.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;//managing state of back button

                MyFrame.Navigate(typeof(Financial));
                TitleTextBlock.Text = "Financial"; //will appear as page title
            }
            else if (Food.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;//managing state of back button
                MyFrame.Navigate(typeof(Food));
                TitleTextBlock.Text = "Food"; //will appear as page title
                
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            //When someone selects the Hamburger menu we want to show or hide the menu.

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (FinancialListBoxItem.IsSelected)
            //{
            //    //ResultTextBlock.Text = "Financial";
            //}
            //else if (FoodListBoxItem.IsSelected)
            //{
            //    //ResultTextBlock.Text = "Food";
            //}
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                Financial.IsSelected = true; // even if we are not clicking on the list box item it will still show it as current selected page.
            }
        }

      
    }
}
