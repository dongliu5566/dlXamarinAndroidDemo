using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using string1 = System.String;

namespace storage
{
   public  class MainApplication : Application
    {
        private readonly static string1 TAG = "MainApplication";
        // 声明一个当前应用的静态实例
        private static MainApplication mApp;
        // 声明一个公共的信息映射对象，可当作全局变量使用
        public Dictionary<string1, string1> mInfoMap = new Dictionary<string1, string1>();

        // 声明一个公共的图标映射对象，
        public Dictionary<Long, Bitmap> mIconMap = new Dictionary<Long, Bitmap>();


     
       public override void OnCreate()
        {
            base.OnCreate();
            // 在打开应用时对静态的应用实例赋值
            mApp = this;
            Log.Debug(TAG, "onCreate");
        }
     
      public override void OnTerminate()
        {
            Log.Debug(TAG, "onTerminate");
            base.OnTerminate();
        }

        // 利用单例模式获取当前应用的唯一实例
        public static MainApplication getInstance()
        {
            return mApp;
        }
    }
}