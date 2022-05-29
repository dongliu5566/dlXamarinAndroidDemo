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
    [Activity(Label = "PxActivity")]
    public class PxActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_px);
            // Create your application here
            int dip_10 = Utils.dip2px(this, 10L);
            // 从布局文件中获取名叫tv_padding的文本视图
            //   TextView tv_padding = findViewById(R.id.tv_padding);
            TextView tv_padding = FindViewById<TextView>(Resource.Id.tv_padding);
            // 设置该文本视图的内部文字与控件四周的间隔大小
            // tv_padding.setPadding(dip_10, dip_10, dip_10, dip_10);
            tv_padding.SetPadding(dip_10, dip_10, dip_10, dip_10);
        }
    }
}