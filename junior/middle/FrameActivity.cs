using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;
using middle.util; 
using static Android.App.ActionBar;
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "FrameActivity")]
    public class FrameActivity : Activity, IOnClickListener
    {
        private FrameLayout fl_content; // 声明一个框架布局对象

        // 定义一个颜色数组
        public Color[] mColorArray = {
            Color.Black,Color.White,Color.Red,Color.Yellow,Color.Green,
            Color.Blue,Color.Cyan,Color.Magenta,Color.Gray,Color.DarkGray
           
    };
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_add_frame)
            {
                Random ran = new Random();
                int random = ran.Next(0, 10);
                // int random = (int)(Math.random() * 10 % 10);
                // 创建一个新的视图对象
                View vv = new View(this);
                // 把该视图的背景设置为随机颜色
                vv.SetBackgroundColor(mColorArray[random]);
                // 声明一个布局参数，其中宽度与上级持平，高度为随机高度
                LinearLayout.LayoutParams ll_params = new LinearLayout.LayoutParams(
                //       LayoutParams.MATCH_PARENT, Utils.dip2px(this, (random + 1) * 30));
                LayoutParams.MatchParent, Utils.dip2px(this, (random + 1) * 30));
                // 给该视图设置布局参数
                //  vv.SetLayoutParams(ll_params);
                vv.LayoutParameters= ll_params;
                //// 设置该视图的长按监听器
                //vv.setOnLongClickListener(new OnLongClickListener() {
                // vv.SetOnLongClickListener()
                vv.LongClick += (s, e) =>
                  {
                      fl_content.RemoveView(vv);
                       // return true;
                  };
                //public boolean onLongClick(View vvv)
                //{
                //    // 一旦监听到长按事件，就从相对布局中删除该视图
                //    fl_content.removeView(vvv);
                //    return true;
                //}
              

            }

        }
     

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_frame);
            // 从布局文件中获取名叫fl_content的框架布局
            fl_content = FindViewById<FrameLayout>(Resource.Id.fl_content);
            FindViewById(Resource.Id.btn_add_frame).SetOnClickListener(this);
           
        }
    }
}