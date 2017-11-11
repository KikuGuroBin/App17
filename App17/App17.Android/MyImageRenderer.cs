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

[assembly:ExportRenderer(typeof(MyImage), typeof(MyImageRenderer))]
namespace App17.Droid
{
    public class MyImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            Touch += System.Diagnostics.Debug.WriteLine("aaaa"); 
        }
    }
}