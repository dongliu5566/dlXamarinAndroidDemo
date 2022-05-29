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

namespace junior
{
    [Activity(Label = "MarqueeActivity")]
    public class MarqueeActivity : Activity, View.IOnClickListener
    {
        private TextView tv_marquee; // 声明一个文本视图对象
        private bool isPaused = false; // 跑马灯文字是否暂停滚动
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.tv_marquee)
            { // 点击了文本视图tv_marquee
                isPaused = !isPaused;
                if (isPaused)
                {
                    tv_marquee.SetFocusable(ViewFocusability.NotFocusable); // 不允许获得焦点
                    tv_marquee.FocusableInTouchMode=false; // 不允许在触摸时获得焦点
                  //  tv_marquee.RequestFocus(FocusSearchDirection.Up);
                }
                else
                {
                    // tv_marquee.setFocusable(true); // 允许获得焦点
                    tv_marquee.SetFocusable(ViewFocusability.Focusable); // 允许获得焦点
                 //   tv_marquee.FocusableInTouchMode(true); // 允许在触摸时获得焦点
                    tv_marquee.FocusableInTouchMode=true; // 允许在触摸时获得焦点
                                                          //   tv_marquee.requestFocus(); // 强制获得焦点，让跑马灯滚起来
                    tv_marquee.RequestFocus(FocusSearchDirection.Forward);
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_marquee);

            tv_marquee = FindViewById<TextView>(Resource.Id.tv_marquee);
            // 给tv_marquee设置点击监听器
            tv_marquee.SetOnClickListener(this);
            tv_marquee.RequestFocus(); // 强制获得焦点，让跑马灯滚起来

        }
    }
}