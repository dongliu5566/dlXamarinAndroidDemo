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

namespace storage.util
{
    public class SharedUtil
    {
        private static SharedUtil mUtil; // 声明一个共享参数工具类的实例
        private static ISharedPreferences mShared; // 声明一个共享参数的实例

        // 通过单例模式获取共享参数工具类的唯一实例
        public static SharedUtil getIntance(Context ctx)
        {
            if (mUtil == null)
            {
                mUtil = new SharedUtil();
            }
            // 从share.xml中获取共享参数对象
         //   mShared = ctx.GetSharedPreferences("share", Context.MODE_PRIVATE);
            mShared = ctx.GetSharedPreferences("share", FileCreationMode.Private);
            return mUtil;
        }
    }
}