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
using xBindDataExample.Models;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

//using xBindDataExample.Models //add this namespace to this .cs
namespace xBindDataExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Book> Books;

        public MainPage()
        {
            this.InitializeComponent();
            Books = BookManager.GetBooks(); // This will return a list of books
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //e will give us the clicked item 
            // We will convert into an item of type book
            var book = (Book)e.ClickedItem; //Now we have the instance of book that was clicked on in our grid view
            ResultTextBlock.Text = "You selected " + book.Title;
        }
    }
}
