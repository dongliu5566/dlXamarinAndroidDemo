using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace junior
{
    [Activity(Label = "ColorActivity")]
    public class ColorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_color);
            // Create your application here

          //  TextView tv_code_six = findViewById(R.id.tv_code_six);
            TextView tv_code_six = FindViewById<TextView>(Resource.Id.tv_code_six);
            // 给文本视图tv_code_six设置背景为透明的绿色，透明就是看不到
            // tv_code_six.setBackgroundColor(0x00ff00);
            tv_code_six.SetBackgroundColor(Android.Graphics.Color.Green);
            // 从布局文件中获取名叫tv_code_eight的文本视图
          //  TextView tv_code_eight = findViewById(R.id.tv_code_eight);
            TextView tv_code_eight = FindViewById<TextView>(Resource.Id.tv_code_eight);
            // 给文本视图tv_code_eight设置背景为不透明的绿色，即正常的绿色
            // tv_code_eight.setBackgroundColor(0xff00ff00);
          //  tv_code_eight.SetBackgroundColor(Android.Graphics.Color.f);
           // tv_code_eight.SetBackgroundColor(Android.Graphics.Color.Argb(255, 0,255, 0));
           tv_code_eight.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF00FF00"));
           // tv_code_eight.SetBackgroundColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.abc_hint_foreground_material_light)));
            //   tv_code_eight.SetBackgroundColor(Android.Graphics.Color.RGBToHSV(255, 0, 255, 0,0.1f,0.1f));
        }
    }
}