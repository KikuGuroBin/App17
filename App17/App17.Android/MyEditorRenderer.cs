using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using App17;
using App17.Droid;

[assembly : ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace App17.Droid
{
    public class MyEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            KeyPress += (s, k) => 
            {
                System.Diagnostics.Debug.WriteLine("deg : MyEditorRenderer.KeyPress");
            };
        }
    }
}