using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;
using Uri1 = Android.Net.Uri;
namespace middle 
{
    [Activity(Label = "ActUriActivity")]
    public class ActUriActivity : Activity, IOnClickListener
    {
        private EditText et_phone; // 声明一个编辑框对象

        public void OnClick(View v)
        {
            // 获取编辑框的输入文本
            String phone = et_phone.Text;
            if (v.Id == Resource.Id.btn_call)
            { // 点击了直接拨号按钮
              // 拨号功能还需在AndroidManifest.xml中添加拨号权限配置
                Intent intent = new Intent(); // 创建一个新意图
            //    intent.setAction(Intent.ACTION_CALL); // 设置意图动作为直接拨号
                intent.SetAction(Intent.ActionCall); // 设置意图动作为直接拨号
                                                     // Uri uri = Uri.parse("tel:" + phone); // 声明一个拨号的Uri
                Uri1 uri = Uri1.Parse("tel:" + phone); // 声明一个拨号的Uri
                intent.SetData(uri); // 设置意图前往的路径
                StartActivity(intent); // 启动意图通往的活动页面
            }
            else if (v.Id == Resource.Id.btn_dial)
            { // 点击了准备拨号按钮
              // 拨号功能还需在AndroidManifest.xml中添加拨号权限配置
                Intent intent = new Intent(); // 创建一个新意图
             // intent.SetAction(Intent.ACTION_DIAL); // 设置意图动作为准备拨号
                intent.SetAction(Intent.ActionDial); // 设置意图动作为准备拨号
                Uri1 uri = Uri1.Parse("tel:" + phone); // 声明一个拨号的Uri
                intent.SetData(uri); // 设置意图前往的路径
                StartActivity(intent); // 启动意图通往的活动页面
            }
            else if (v.Id == Resource.Id.btn_sms)
            { // 点击了发送短信按钮
              // 发送短信还需在AndroidManifest.xml中添加发短信的权限配置
                Intent intent = new Intent(); // 创建一个新意图
               // intent.setAction(Intent.ACTION_SENDTO); // 设置意图动作为发短信
                intent.SetAction(Intent.ActionSend); // 设置意图动作为发短信
                Uri1 uri = Uri1.Parse("smsto:" + phone); // 声明一个发送短信的Uri
                intent.SetData(uri); // 设置意图前往的路径
                StartActivity(intent); // 启动意图通往的活动页面
            }

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_act_uri);
            FindViewById(Resource.Id.btn_call).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_dial).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sms).SetOnClickListener(this);
            // 从布局文件中获取名叫et_phone的编辑框
            et_phone = FindViewById<EditText>(Resource.Id.et_phone);
           
        }
    }
}