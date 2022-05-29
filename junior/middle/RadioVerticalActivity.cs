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
using static Android.Widget.RadioGroup;

namespace middle 
{
    [Activity(Label = "RadioVerticalActivity")]
    public class RadioVerticalActivity : Activity, IOnCheckedChangeListener
    {
        private TextView tv_marry; // 声明一个文本视图对象
        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            if (checkedId == Resource.Id.rb_married)
            {
                tv_marry.Text="哇哦，祝你早生贵子";
            }
            else if (checkedId == Resource.Id.rb_unmarried)
            {
                tv_marry.Text="哇哦，你的前途不可限量";
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_radio_vertical);
            // 从布局文件中获取名叫tv_marry的文本视图
            tv_marry = FindViewById<TextView>(Resource.Id.tv_marry);
            // 从布局文件中获取名叫rg_marry的单选组
            RadioGroup rg_marry = FindViewById<RadioGroup>(Resource.Id.rg_marry);
            // 给rg_marry设置单选监听器，一旦用户点击组内的单选按钮，就触发监听器的onCheckedChanged方法
            rg_marry.SetOnCheckedChangeListener(this);
            // Create your application here
        }
    }
}