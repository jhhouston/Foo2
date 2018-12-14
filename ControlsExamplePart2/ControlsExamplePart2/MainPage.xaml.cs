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

namespace ControlsExamplePart2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary> 
        /// New Array of strings selection items forMyAutoSuggestBox_TextChanged()
        /// </summary>
        private string[] selectedItems = new string[] {"Ferdinand","Frank","Frida","Nigel","Tag","Tanya","Tanner","Todd"};

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MyCalanderView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            //Give me all the selected dates for the calanderView (The sender), Then we project out of those selections the (Month/Day) as a string          
            var selectedDates = sender.SelectedDates.Select(p => p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();
            var values = string.Join(",", selectedDates);    //Add them to an array (put in array so that I an use sting.join method where you just separate with a comma)
            CalenderViewResultBlockTextBlock.Text = values; // set joined string as text property to the textblock
            
        }

        private void InnerFlyoutButton_Click(object sender, RoutedEventArgs e)
        {
            //hiding flyout when button clicked
            MyFlyout.Hide(); //XAML page  <Flyout x:Name="MyFlyout">
        }

        /// <summary>
        /// How this class works: private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        /// 
        /// first the code:
        /// ----var autoSuggestBox = (AutoSuggestBox)sender;
        /// ----var filtered = selectedItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
        /// ----autoSuggestBox.ItemsSource = filtered;
        /// 
        /// How it works:
        ///  //narrowing down selection as we type sender is an AutoSuggestBox
        ///  
        //--------var autoSuggestBox = (AutoSuggestBox)sender;

        //Where clause on array of strings from the selection items on line 28 from  private string[] selectedItems = new string[] {"Ferdinand","Frank","Frida","Nigel","Tag","Tanya","Tanner","Todd"};
        //filter list by looking for items that start with whatever text was typed into the autoSuggestBox, then we call to array on it 

        //--------var filtered = selectedItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();

        //and we will use  that filtered box to pass it to the items source of our autoSuggestbox, now you will see a little menu pop up with all the filtered items that we can choose from.

        //---------autoSuggestBox.ItemsSource = filtered;
        /// </summary>
        /// 
    //Issues-- This code only does proper search with capital letter because of how array was hard coded.
        private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectedItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }
    }
}
