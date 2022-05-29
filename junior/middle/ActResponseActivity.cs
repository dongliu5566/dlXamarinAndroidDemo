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
using static Android.Widget.TextView;

namespace middle 
{
    [Activity(Label = "ActResponseActivity")]
    public class ActResponseActivity : Activity, IOnClickListener
    {
        private EditText et_response; // 声明一个编辑框对象
        private TextView tv_response; // 声明一个文本视图对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_act_response)
            {
                Intent intent = new Intent(); // 创建一个新意图
                Bundle bundle = new Bundle(); // 创建一个新包裹
                                              // 往包裹存入名叫response_time的字符串
                bundle.PutString("response_time", DateUtil.getNowTime());
                // 往包裹存入名叫response_content的字符串
                bundle.PutString("response_content", et_response.Text);
                intent.PutExtras(bundle); // 把快递包裹塞给意图
               //  SetResult(Activity.RESULT_OK, intent); // 携带意图返回前一个页面
                SetResult(Result.Ok, intent); // 携带意图返回前一个页面
                Finish(); // 关闭当前页面
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_act_response);
            FindViewById(Resource.Id.btn_act_response).SetOnClickListener(this);
            // 从布局文件中获取名叫et_response的编辑框
            et_response = FindViewById<EditText>(Resource.Id.et_response);
            // 从布局文件中获取名叫tv_response的文本视图
            tv_response = FindViewById<TextView>(Resource.Id.tv_response);
            // 从前一个页面传来的意图中获取快递包裹
         //   Bundle bundle = getIntent().getExtras();
            Bundle bundle = Intent.Extras;
            // 从包裹中取出名叫request_time的字符串
            String request_time = bundle.GetString("request_time");
            // 从包裹中取出名叫request_content的字符串
            String request_content = bundle.GetString("request_content");
            String desc = String.Format("收到请求消息：\n请求时间为{0}\n请求内容为{1}",
                    request_time, request_content);
            // 把请求消息的详情显示在文本视图上
            tv_response.SetText(desc,BufferType.Normal);
            // Create your application here
        }
    }
}