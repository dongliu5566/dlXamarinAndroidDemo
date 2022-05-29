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
using middle.util;
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "RelativeCodeActivity")]
    public class RelativeCodeActivity : Activity, IOnClickListener
    {
        private RelativeLayout rl_content; // 声明一个相对布局对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_add_left)
            {
           //     addNewView(RelativeLayout.LEFT_OF, RelativeLayout.ALIGN_TOP, v.getId());
               // addNewView(RelativeLayout.LE, RelativeLayout.ALIGN_TOP, v.getId());
            }
            //else if (v.getId() == R.id.btn_add_above)
            //{
            //    addNewView(RelativeLayout.ABOVE, RelativeLayout.ALIGN_LEFT, v.getId());
            //}
            //else if (v.getId() == R.id.btn_add_right)
            //{
            //    addNewView(RelativeLayout.RIGHT_OF, RelativeLayout.ALIGN_BOTTOM, v.getId());
            //}
            //else if (v.getId() == R.id.btn_add_below)
            //{
            //    addNewView(RelativeLayout.BELOW, RelativeLayout.ALIGN_RIGHT, v.getId());
            //}
            //else if (v.getId() == R.id.btn_add_center)
            //{
            //    addNewView(RelativeLayout.CENTER_IN_PARENT, -1, rl_content.getId());
            //}
            //else if (v.getId() == R.id.btn_add_parent_left)
            //{
            //    addNewView(RelativeLayout.ALIGN_PARENT_LEFT, RelativeLayout.CENTER_VERTICAL, rl_content.getId());
            //}
            //else if (v.getId() == R.id.btn_add_parent_top)
            //{
            //    addNewView(RelativeLayout.ALIGN_PARENT_TOP, RelativeLayout.CENTER_HORIZONTAL, rl_content.getId());
            //}
            //else if (v.getId() == R.id.btn_add_parent_right)
            //{
            //    addNewView(RelativeLayout.ALIGN_PARENT_RIGHT, -1, rl_content.getId());
            //}
            //else if (v.getId() == R.id.btn_add_parent_bottom)
            //{
            //    addNewView(RelativeLayout.ALIGN_PARENT_BOTTOM, -1, rl_content.getId());
            //}
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_relative_code);
            // 从布局文件中获取名叫rl_content的相对布局
            rl_content = FindViewById<RelativeLayout>(Resource.Id.rl_content);
            // 下面通过不同按钮演示在相对布局内部的指定位置添加子视图
            FindViewById(Resource.Id.btn_add_left).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_above).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_right).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_below).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_center).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_parent_left).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_parent_top).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_parent_right).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_add_parent_bottom).SetOnClickListener(this);

        }


        // 通过代码在相对布局下面添加新视图，referId代表参考对象的编号
        private void addNewView(int firstAlign, int secondAlign, int referId)
        {
        //    // 创建一个新的视图对象
        //    View v = new View(this);
        //    // 把该视图的背景设置为半透明的绿色
        //    //  v.SetBackgroundColor(0xaa66ff66);
        //    v.SetBackgroundColor(Android.Graphics.Color.Green);
        //    // 声明一个布局参数，其中宽度为100p，高度也为100dp
        //    RelativeLayout.LayoutParams rl_params = new RelativeLayout.LayoutParams(
        //            Utils.dip2px(this, 100), Utils.dip2px(this, 100));
        //    // 给布局参数添加第一个相对位置的规则，firstAlign代表位置类型，referId代表参考对象
        //    rl_params.AddRule(firstAlign, referId);
        //    if (secondAlign >= 0)
        //    {
        //        // 如果存在第二个相对位置，则同时给布局参数添加第二个相对位置的规则
        //        rl_params.AddRule(secondAlign, referId);
        //    }
        //    // 给该视图设置布局参数
        //    v.SetLayoutParams(rl_params);
        //    // 设置该视图的长按监听器
        //    v.SetOnLongClickListener(new IOnLongClickListener()=>{

        //    };
        //   // {
        //   // // 在用户长按该视图时触发
        //   // public bool onLongClick(View vv)
        //   // {
        //   //     // 一旦监听到长按事件，就从相对布局中删除该视图
        //   //     rl_content.RemoveView(vv);
        //   //     return true;
        //   // }
        //   //});
        //// 往相对布局中添加该视图
        //rl_content.addView(v);
    }
}
}