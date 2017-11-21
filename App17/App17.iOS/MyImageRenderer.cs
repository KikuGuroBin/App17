﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using App17;
using App17.iOS;

//
[assembly:ExportRenderer(typeof(MyImage), typeof(MyImageRenderer))]
namespace App17.iOS
{
    /// <summary>
    /// MyImageインスタンスのレンダラー
    /// </summary>
    public class MyImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;

            // MyImageインスタンスの現在の座標
            var newPoint = touch.LocationInView(this);

            // MyImageインスタンスの前回の座標
            var previousPoint = touch.PreviousLocationInView(this);

            // 差分を計算
            nfloat dx = newPoint.X - previousPoint.X;
            nfloat dy = newPoint.Y - previousPoint.Y;

            // コールバック
            var el = this.Element as MyImage;
            el.OnImageDrug(el, new ImageDrugEventArgs(el, dx, dy));
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
        }
    }
}