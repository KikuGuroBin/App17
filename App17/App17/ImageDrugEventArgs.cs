using System;
using System.Collections.Generic;
using System.Text;

namespace App17
{
    public class ImageDrugEventArgs
    {
        /// <summary>
        /// MyImageインスタンスのX座標
        /// </summary>
        public double X;

        /// <summary>
        /// MyImageインスタンスのY座標
        /// </summary>
        public double Y;

        public ImageDrugEventArgs(object sender, double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}