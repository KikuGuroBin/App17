using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App17
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentView
	{
        public Button PreviousButton;
        public Button BehindButton;

        public Page3 ()
		{
			InitializeComponent ();

            PreviousButton = Button1;
            BehindButton = Button2;
		}
	}
}