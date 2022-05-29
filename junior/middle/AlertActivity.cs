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
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "AlertActivity")]
    public class AlertActivity : Activity, IOnClickListener
    {
        private TextView tv_alert; // 声明一个文本视图对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_alert)
            {
                // 创建提醒对话框的建造器
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                // 给建造器设置对话框的标题文本
                // builder.setTitle("尊敬的用户");
                builder.SetTitle("尊敬的用户");
             
                // 给建造器设置对话框的信息文本
                builder.SetMessage("你真的要卸载我吗？");
                // 给建造器设置对话框的肯定按钮文本及其点击监听器
                //    builder.SetPositiveButton("残忍卸载", new DialogInterface.OnClickListener() {
                builder.SetPositiveButton("残忍卸载", (s, e) =>
                {
                    //  Toast.MakeText(this, "虽然依依不舍，但是只能离开了", ToastLength.Short).Show();
                    tv_alert.Text="虽然依依不舍，但是只能离开了";
                });

                //        @Override
                //        public void onClick(DialogInterface dialog, int which)
                //        {
                //            tv_alert.setText("虽然依依不舍，但是只能离开了");
                //        }
                //    });
                //    // 给建造器设置对话框的否定按钮文本及其点击监听器
                builder.SetNegativeButton("我再想想", (s, e) =>
                {

                    tv_alert.Text = "让我再陪你三百六十五个日夜";

                });
            // 根据建造器完成提醒对话框对象的构建
            AlertDialog alert = builder.Create();
            // 在界面上显示提醒对话框
            alert.Show();
        }


        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_alert);
            // 给btn_alert设置点击监听器，一旦用户点击按钮，就触发监听器的onClick方法
            FindViewById(Resource.Id.btn_alert).SetOnClickListener(this);
            // 从布局文件中获取名叫tv_alert的文本视图
            tv_alert = FindViewById<TextView>(Resource.Id.tv_alert);

        }
    }
}