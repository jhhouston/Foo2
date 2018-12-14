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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LaboriousLayoutChallange
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Coffee : Page
    {
        //used for display method line 63
        //will keep selected text from each method to pass to display method
        private string _roast;
        private string _sweetener;
        private string _cream;

        public Coffee()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Goal of this code is to retrieve selections and put them back together so user can see in ResultTextBlock 
        /// </summary>      

        //_________________Menu Flyout events____________________________________//

        

        private void Roast_Click(object sender, RoutedEventArgs e)
        {
            //use sender for the click event to tell us which menu item was selected
            //cast to type menu flyout item as who is sending it
            var selected = (MenuFlyoutItem)sender;
            _roast = selected.Text;
            displayResult();
            

        }

        private void Sweetneer_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _sweetener = selected.Text;
            displayResult();
        }

        private void Cream_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _cream = selected.Text;
            displayResult();
        }

        //all 3 methods need to call a common helper method to assemble result message that is printed to screen
        private void displayResult()
        {
            //decision making process:
            if (_roast == "None" || String.IsNullOrEmpty(_roast))
            {
                ResultTextBlock.Text = "None";
                //return out of method
                return;
            }
            //need to pass data to display result need to keep state between all 3 button clicks, which is why we have private variables see line 26
            ResultTextBlock.Text = _roast;

            //check both sweetener and cream
            if (_cream !="None" && !String.IsNullOrEmpty(_cream))
            {
                //+= b/c we want to make sure to add on what ever the roast was
                ResultTextBlock.Text += "+" + _cream;
            }

            if (_sweetener !="None" && !String.IsNullOrEmpty(_sweetener))
            {
                //+= b/c we want to make sure to add on what ever the sweetener was
                ResultTextBlock.Text += "+" + _sweetener;
            }

        }



        //_________________Menu Flyout events end____________________________________//
    }
}
