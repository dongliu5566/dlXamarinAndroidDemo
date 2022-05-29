using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using junior.util;

namespace junior
{
    [Activity(Label = "BbsActivity")]
    public class BbsActivity : Activity, View.IOnClickListener, View.IOnLongClickListener
    {
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.tv_control || v.Id == Resource.Id.tv_bbs)
            {
                // 生成一个0到4之间的随机数
                // int random = (int)(Math.random() * 10) % 5;
                Random ran = new Random();
                int random = ran.Next(0,4);
                // 拼接聊天的文本内容
                string newStr = string.Format("{0}\n{1} {2}",
                        tv_bbs.Text, DateUtil.getNowDateTime1(), mChatStr[random]);
                // 设置文本视图tv_bbs的文本内容
                tv_bbs.Text=newStr;
            }
        }

        public bool OnLongClick(View v)
        {
            if (v.Id == Resource.Id.tv_control || v.Id == Resource.Id.tv_bbs)
            {
                tv_bbs.Text="";
            }
            return true;
        }
        private TextView tv_bbs; // 声明一个文本视图对象
        private TextView tv_control; // 声明一个文本视图对象
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_bbs);
            // Create your application here
            tv_control = FindViewById<TextView>(Resource.Id.tv_control);
            // 给tv_control设置点击监听器
            tv_control.SetOnClickListener(this);
            // 给tv_control设置长按监听器
            tv_control.SetOnLongClickListener(this);
            // 从布局文件中获取名叫tv_bbs的文本视图
            tv_bbs = FindViewById<TextView>(Resource.Id.tv_bbs);
            // 给tv_bbs设置点击监听器
            tv_bbs.SetOnClickListener(this);
            // 给tv_bbs设置长按监听器
            tv_bbs.SetOnLongClickListener(this);
            // 设置tv_bbs内部文字的对齐方式为靠左且靠下
            //   tv_bbs.SetGravity(Gravity.LEFT | Gravity.BOTTOM);
            tv_bbs.Gravity = GravityFlags.Left| GravityFlags.Bottom;// (Gravity.LEFT | Gravity.BOTTOM);
            // 设置tv_bbs高度为八行文字那么高
            tv_bbs.SetLines(8);
          
            // 设置tv_bbs最多显示八行文字
            tv_bbs.SetMaxLines(8);
            // 设置tv_bbs内部文本的移动方式为滚动形式
           // tv_bbs.SetMovementMethod(new ScrollingMovementMethod());
            tv_bbs.MovementMethod = new ScrollingMovementMethod();

        }

        private string[] mChatStr = {"你吃饭了吗？", "今天天气真好呀。","我中奖啦！", "我们去看电影吧", "晚上干什么好呢？",};

    }
}