using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using middle.util;
using static Android.Views.View;
using static Android.Widget.TextView;

namespace middle 
{
    [Activity(Label = "ActNextActivity")]
    public class ActNextActivity : AppCompatActivity, IOnClickListener
    {
        private  static String TAG = "ActNextActivity";
        private TextView tv_life; // 声明一个文本视图对象
        private String mStr = "";

        private void refreshLife(String desc)
        { // 刷新生命周期的日志信息
            Log.Debug(TAG, desc);
            mStr = String.Format("{0}    {1} {2} {3}\r\n", mStr, DateUtil.getNowTime(), TAG, desc);
            // tv_life.Text=mStr;
            tv_life.SetText(mStr, BufferType.Normal);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_act_pre)
            {
                Intent intent = new Intent(); // 创建一个新意图
                intent.PutExtra("life", mStr); // 把字符串参数塞给意图
           //     SetResult(Activity.RESULT_OK, intent); // 携带意图返回前一个页面
             
               SetResult(Android.App.Result.Ok, intent); // 携带意图返回前一个页面
                Finish(); // 关闭当前页面
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_act_next);
            FindViewById(Resource.Id.btn_act_pre).SetOnClickListener(this);
            // 从布局文件中获取名叫tv_life的文本视图
            tv_life = FindViewById<TextView>(Resource.Id.tv_life);
            refreshLife("onCreate");
            // Create your application here
        }


        protected override void OnStart()
        { // 开始活动
            refreshLife("onStart");
            base.OnStart();
        }


        protected override void OnStop()
        { // 停止活动页面
            refreshLife("onStop");
            base.OnStop();
        }


        protected override void OnResume()
        { // 恢复活动页面
            refreshLife("onResume");
            base.OnResume();
        }


        protected override void OnPause()
        { // 暂停活动页面
            refreshLife("onPause");
           
            base.OnPause();
        }


        protected override void OnRestart()
        { // 重启活动页面
            refreshLife("onRestart");
            base.OnRestart();
        }


        protected override void OnDestroy()
        { // 销毁活动页面
            refreshLife("onDestroy");
         
            base.OnDestroy();
        }
    }
}