using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace App17
{
    public class MyImage : Image
    {
        // インスタンスがドラッグされたときのイベント
        public void OnImageDrug(object sender, ImageDrugEventArgs args)
        {
            var rc = this.Bounds;

            // コールバックから座標取得
            rc.X += args.X;
            rc.Y += args.Y;

            // 取得した座標に移動
            this.Layout(rc);
        }
    }
}
