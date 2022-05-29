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
    [Activity(Label = "ShapeActivity")]
    public class ShapeActivity : Activity, View.IOnClickListener
    {
        private View v_content; // 声明一个视图对象
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_rect)
            { // 点击了按钮btn_rect
              // 把矩形形状设置为v_content的背景
                v_content.SetBackgroundResource(Resource.Drawable.shape_rect_gold);
            }
            else if (v.Id == Resource.Id.btn_oval)
            { // 点击了按钮btn_oval
              // 把椭圆形状设置为v_content的背景
                v_content.SetBackgroundResource(Resource.Drawable.shape_oval_rose);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_shape);
            // 从布局文件中获取名叫v_content的视图
            v_content = FindViewById<View>(Resource.Id.v_content);
            // 给btn_rect设置点击监听器
            FindViewById(Resource.Id.btn_rect).SetOnClickListener(this);
            // 给btn_oval设置点击监听器
            FindViewById(Resource.Id.btn_oval).SetOnClickListener(this);
            // Create your application here
        }
    }
}