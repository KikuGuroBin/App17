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
	public partial class TabEX : ContentPage
	{
        public Dictionary<int, View> ContentViews;

		public TabEX ()
		{
			InitializeComponent ();

            ContentViews = new Dictionary<int, View>();

            var children = Pages.Children;
            
            for (var i = 0; i < children.Count; i++)
            {
                ContentViews.Add(i + 1, children.ElementAt(i));
            }

            NavPage1.PreviousButton.Clicked += async (s, e) =>
            {
                var rc = new Rectangle(0, Height * 0.3, Width * 0.4, Height * 0.4);
                NavPage1.LayoutTo(rc);
                
                rc.X = Width * 0.6;
                await NavPage2.LayoutTo(rc);

                rc = new Rectangle(-Width, 0, Width, Height);
                NavPage1.LayoutTo(rc);

                rc.X = 0;
                await NavPage2.LayoutTo(rc);
            };

            NavPage1.BehindButton.Clicked += async (s, e) => 
            {
                /*
                var rc = new Rectangle(0, Height * 0.3, Width * 0.4, Height * 0.4);
                NavPage1.LayoutTo(rc);
                */

                MovingView(NavPage1, 250, 0, Height * 0.3, Width * 0.4, Height * 0.4);

                /*
                rc.X = Width * 0.6;
                await NavPage2.LayoutTo(rc);
                */

                await AsyncMovingView(NavPage2, 250, Width * 0.6, Height * 0.3, Width * 0.4, Height * 0.4);

                /*
                rc = new Rectangle(-Width, 0, Width, Height);
                NavPage1.LayoutTo(rc);
                */

                MovingView(NavPage1, 250, -Width, 0, Width, Height);

                /*
                rc.X = 0;
                await NavPage2.LayoutTo(rc);
                */

                await AsyncMovingView(NavPage2, 250, 0, 0, Width, Height);
            };

            NavPage2.PreviousButton.Clicked += async (s, e) =>
            {
                var rc = new Rectangle(Width * 0.6, Height * 0.3, Width * 0.4, Height * 0.4);
                NavPage2.LayoutTo(rc);

                rc.X = 0;
                await NavPage1.LayoutTo(rc);

                rc = new Rectangle(Width, 0, Width, Height);
                NavPage2.LayoutTo(rc);

                rc.X = 0;
                await NavPage1.LayoutTo(rc);
            };

            NavPage2.BehindButton.Clicked += async (s, e) =>
            {
                var rc = new Rectangle(Width * 0.6, Height * 0.3, Width * 0.4, Height * 0.4);
                NavPage2.LayoutTo(rc);

                rc.X = 0;
                await NavPage3.LayoutTo(rc);

                rc = new Rectangle(0, 0, Width, Height);
                NavPage2.LayoutTo(rc);

                rc.X = -Width;
                await NavPage3.LayoutTo(rc);
            };
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            
            NavPage1.WidthRequest = width;
            NavPage2.WidthRequest = width;

            NavPage1.HeightRequest = height;
            NavPage2.HeightRequest = height;

            var rc = NavPage2.Bounds;
            rc.X = width;
            NavPage2.LayoutTo(rc);

            rc.X = width * 2;
            NavPage3.LayoutTo(rc);
        }

        /// <summary>
        /// Rectangleインスタンス生成用
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        private Rectangle SetRectangle(Rectangle rc, params double[] bounds)
        {
            for (var i = 0; i < bounds.Length; i++)
            {
                var d = bounds[i];

                if (d != -1)
                {
                    switch (i)
                    {
                        case 0:
                            rc.X = d;
                            break;
                        case 1:
                            rc.Y = d;
                            break;
                        case 2:
                            rc.Width = d;
                            break;
                        case 3:
                            rc.Height = d;
                            break;
                    }
                }
            }

            return rc;
        }


        /// <summary>
        /// ビュー用アニメーション
        /// </summary>
        /// <param name="view">
        /// アニメーションの対象となるビュー
        /// </param>
        /// <param name="time">
        /// アニメーションの時間
        /// </param>
        /// <param name="bounds">
        /// 
        /// </param>
        private void MovingView(View view, uint time = 250, params double[] bounds)
        {
            var rc = SetRectangle(view.Bounds, bounds);
            
            view.LayoutTo(rc, time);
        }

        /// <summary>
        /// 非同期ビュー用アニメーション
        /// </summary>
        /// <param name="view"></param>
        /// <param name="time"></param>
        /// <param name="bounds"></param>
        /// <returns>
        /// アニメーションの終了
        /// </returns>
        private async Task<bool> AsyncMovingView(View view, uint time = 250, params double[] bounds)
        {
            var rc = SetRectangle(view.Bounds, bounds);

            await view.LayoutTo(rc, time);

            return true;
        }
    }
}