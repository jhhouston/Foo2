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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UserControlDataTemplate
{
    public sealed partial class ContactTemplate : UserControl
    {
        //Whenever one of the controls on the ContactTemplate.xaml page needs to get data its going to get data of type contact and its going to get it from the DataContext for this user control.
        //Data Contacts for the user control will be passed in from the MainPage.xaml it will be whatever gets passed in in data template
        //Treat this as template code add to cheat sheet


        public Models.Contact Contact { get { return this.DataContext as Models.Contact; } }

        public ContactTemplate()
        {
            this.InitializeComponent();

            //Boilerplate code add to cheat sheet
            //whenever the data context is changed  (this Lamda expression) will call the Bindings.Update()
            //this is saying generated go out and update the data you are bound to. 
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}
