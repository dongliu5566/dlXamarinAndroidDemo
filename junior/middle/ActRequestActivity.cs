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
    [Activity(Label = "ActRequestActivity")]
    public class ActRequestActivity : Activity, IOnClickListener
    {
        private EditText et_request; // 声明一个编辑框对象
        private TextView tv_request; // 声明一个文本视图对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_act_request)
            {
                // 创建一个新意图
                Intent intent = new Intent();
                // 设置意图要跳转的活动类
                intent.SetClass(this,typeof(ActResponseActivity));
            // 往意图存入名叫request_time的字符串
               // intent.putExtra("request_time", DateUtil.getNowTime());
                intent.PutExtra("request_time", DateUtil.getNowTime());
                // 往意图存入名叫request_content的字符串
                intent.PutExtra("request_content", et_request.Text);
            // 期望接收下个页面的返回数据
            StartActivityForResult(intent, 0);
    }
}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_act_request);
            FindViewById(Resource.Id.btn_act_request).SetOnClickListener(this);
            // 从布局文件中获取名叫et_request的编辑框
            et_request = FindViewById<EditText>(Resource.Id.et_request);
            // 从布局文件中获取名叫tv_request的文本视图
            tv_request = FindViewById<TextView>(Resource.Id.tv_request);
            // Create your application here
        }

        //StartActivityForResult OnActivityResult
        protected override void OnActivityResult(int requestCode,Android.App.Result resultCode, Intent data) 
        { // 接收返回数据
            base.OnActivityResult(requestCode, resultCode, data);
          //  base.StartActivityForResult(requestCode, resultCode, data);
            if (data != null)
            {
                // 从意图中取出名叫response_time的字符串
                String response_time = data.GetStringExtra("response_time");
                // 从意图中取出名叫response_content的字符串
                String response_content = data.GetStringExtra("response_content");
                String desc = String.Format("收到返回消息：\n应答时间为{0}\n应答内容为{1}",
                        response_time, response_content);
                // 把返回消息的详情显示在文本视图上
                tv_request.Text=desc;
            }
        }
    }
}