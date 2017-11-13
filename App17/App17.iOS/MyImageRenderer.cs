using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using App17;
using App17.iOS;

[assembly:ExportRenderer(typeof(MyImage), typeof(MyImageRenderer))]
namespace App17.iOS
{
    public class MyImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
        }
    }
}