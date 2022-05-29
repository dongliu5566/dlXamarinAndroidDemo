using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using middle.util;
using static Android.Views.View;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using static Android.Widget.TextView;
//using Android.Support.V7.App;

namespace middle 
{
    [Activity(Label = "ActJumpActivity")]
    public class ActJumpActivity : Activity, IOnClickListener
    {
        private  static String TAG = "ActJumpActivity";
        private TextView tv_life; // 声明一个文本视图对象
        private static String mStr = "";

        private void refreshLife(String desc)
        { // 刷新生命周期的日志信息
            Log.Debug(TAG, desc);
            mStr = String.Format("{0}{1} {2} {3}\r\n", mStr, DateUtil.getNowTime(), TAG, desc);
            //  tv_life.Text=mStr;
            tv_life.SetText(mStr, BufferType.Normal);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_act_jump);
            FindViewById(Resource.Id.btn_act_next).SetOnClickListener(this);
            // 从布局文件中获取名叫tv_life的文本视图
            tv_life = FindViewById<TextView>(Resource.Id.tv_life);
            refreshLife("onCreate");
            // Create your application here
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_act_next)
            {
                // 准备跳到下个活动页面ActNextActivity
                Intent intent = new Intent(this, typeof(ActNextActivity));
                // 期望接收下个页面的返回数据
                StartActivityForResult(intent, 0);
            }
        }
       
        //public override void StartActivityForResult(Intent intent, int requestCode, Bundle options)
        //{
        //    // 等效  //   onActivityResult    ;
        //    base.StartActivityForResult(intent, requestCode, options);
        //    String nextLife = intent.GetStringExtra("life");
        //    refreshLife("\n" + nextLife);
        //    refreshLife("onActivityResult");
        //}
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        { // 接收返回数据
            base.OnActivityResult(requestCode, resultCode, data);
            String nextLife = data.GetStringExtra("life");
            refreshLife("\n" + nextLife);
            refreshLife("onActivityResult");
        }
        protected override void OnStart()
        { // 开始活动页面
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


        protected void onRestart()
        { // 重启活动页面
            refreshLife("onRestart");
         
            base.OnRestart();
        }


        protected void  onDestroy()
        { // 销毁活动页面
            refreshLife("onDestroy");
          
            base.OnDestroy();
        }

    }
}