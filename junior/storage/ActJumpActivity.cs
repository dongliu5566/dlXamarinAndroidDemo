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
using storage.util;
using static Android.Views.View;

namespace storage
{
    [Activity(Label = "ActJumpActivity")]
    public class ActJumpActivity : Activity, IOnClickListener
    {
        private readonly static String TAG = "ActJumpActivity";
        private TextView tv_life; // 声明一个文本视图对象
        private String mStr = "";

        private void refreshLife(String desc)
        { // 刷新生命周期的日志信息
            Log.Debug(TAG, desc);
            Console.WriteLine("cw:"+desc);
        
            mStr = String.Format("{0}{1}{2} {3}\n", mStr, DateUtil.getNowDateTime1(), TAG, desc);
            tv_life.Text = mStr;
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

      
       protected void onResume()
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

       
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        { // 接收返回数据
            base.OnActivityResult(requestCode, resultCode, data);
            String nextLife = data.GetStringExtra("life");
            refreshLife("\n" + nextLife);
            refreshLife("onActivityResult");
        }
    }
}