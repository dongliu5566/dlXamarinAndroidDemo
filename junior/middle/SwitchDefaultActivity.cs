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
using static Android.Widget.CompoundButton;

namespace middle 
{
    [Activity(Label = "SwitchDefaultActivity")]
    public class SwitchDefaultActivity : Activity, IOnCheckedChangeListener
    {
        private Switch sw_status; // 声明一个开关按钮对象
        private TextView tv_result; // 声明一个文本视图对象

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            refreshResult();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_switch_default);
            // 从布局文件中获取名叫sw_status的开关按钮
            sw_status = FindViewById<Switch>(Resource.Id.sw_status);
            // 从布局文件中获取名叫tv_result的文本视图
            tv_result = FindViewById<TextView>(Resource.Id.tv_result);
            // 给开关按钮设置选择监听器，一旦用户点击它，就触发监听器的onCheckedChanged方法
            sw_status.SetOnCheckedChangeListener(this);
            refreshResult();
            // Create your application here
        }

        private void refreshResult()
        {
            //  throw new NotImplementedException();
            String result = String.Format("Switch按钮的状态是{0}",
                (sw_status.Checked) ? "开" : "关");
            tv_result.Text=result;
        }
    }
}