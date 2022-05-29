using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
//using Android.Graphics.Drawables;
//using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using static Android.Resource;

namespace junior
{
    [Activity(Label = "IconActivity")]
    public class IconActivity : Activity, View.IOnClickListener
    {
        private Button btn_icon; // 声明一个按钮对象
        private Drawable drawable; // 声明一个图形对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_left)
            {
                // 设置按钮控件btn_icon内部文字左边的图标
              //  btn_icon.setCompoundDrawables(drawable, null, null, null);
                btn_icon.SetCompoundDrawables(drawable, null, null, null);
            }
            else if (v.Id == Resource.Id.btn_top)
            {
                // 设置按钮控件btn_icon内部文字上方的图标
                btn_icon.SetCompoundDrawables(null, drawable, null, null);
            }
            else if (v.Id == Resource.Id.btn_right)
            {
                // 设置按钮控件btn_icon内部文字右边的图标
                btn_icon.SetCompoundDrawables(null, null, drawable, null);
            }
            else if (v.Id == Resource.Id.btn_bottom)
            {
                // 设置按钮控件btn_icon内部文字下方的图标
                btn_icon.SetCompoundDrawables(null, null, null, drawable);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_icon);
            // 从布局文件中获取名叫btn_icon的按钮控件
            btn_icon = FindViewById<Button>(Resource.Id.btn_icon);
            // 从资源文件ic_launcher.png中获取图形对象
           // drawable = getResources().getDrawable(R.mipmap.ic_launcher);
            drawable = Resources.GetDrawable(Resource.Mipmap.ic_launcher);
            // 设置图形对象的矩形边界大小，注意必须设置图片大小，否则不会显示图片
            // drawable.SetBounds(0, 0, drawable.getMinimumWidth(), drawable.getMinimumHeight());
            drawable.SetBounds(0, 0, drawable.MinimumWidth, drawable.MinimumHeight);
            // 下面通过四个按钮，分别演示左、上、右、下四个方向的图标效果
            FindViewById(Resource.Id.btn_left).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_top).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_right).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_bottom).SetOnClickListener(this);
        }
    }
}