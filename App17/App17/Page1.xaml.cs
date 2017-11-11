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
	public partial class Page1 : ContentView
	{
        public Button PreviousButton;
        public Button BehindButton;

		public Page1 ()
		{
			InitializeComponent ();

            PreviousButton = Button1;
            BehindButton = Button2;

            Editor.Text = "\n";
		}

        private class EditorBehavior : Behavior<Editor>
        {
            protected override void OnAttachedTo(Editor bindable)
            {
                base.OnAttachedTo(bindable);

                bindable.TextChanged += TextChange;
            }

            protected override void OnDetachingFrom(Editor bindable)
            {
                base.OnDetachingFrom(bindable);

                bindable.TextChanged -= TextChange;
            }

            private void TextChange(object sender, EventArgs args)
            {
                var editor = (Editor)sender;
                var len = editor.Text.Length;

                if (len == 0)
                {
                    editor.Text = "\n";
                }
            }
        }
    }
}