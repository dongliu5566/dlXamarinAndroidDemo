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
using junior.util;

namespace junior
{
    [Activity(Label = "ScreenActivity")]
    public class ScreenActivity : Activity
    {
        private TextView tv_screen; // 声明一个文本视图对象
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_screen);
            // 从布局文件中获取名叫tv_screen的文本视图
            tv_screen = FindViewById<TextView>(Resource.Id.tv_screen);
            showScreenInfo();
            // Create your application here
        }

        private void showScreenInfo()
        {
            // 获取手机屏幕的宽度
            int width = Utils.getScreenWidth(this);
            // 获取手机屏幕的高度
            int height = Utils.getScreenHeight(this);
            // 获取手机屏幕的像素密度
            float density = Utils.getScreenDensity(this);
            // 拼接屏幕参数信息的内容文本
            String info = String.Format("当前屏幕的宽度是{0}px，高度是{1}px，像素密度是{2}",
                    width, height, density);
            // 设置文本视图tv_screen的文本内容
            tv_screen.Text=info;
        }
    }
}