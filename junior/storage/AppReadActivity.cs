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

namespace storage
{
    [Activity(Label = "AppReadActivity")]
    public class AppReadActivity : Activity
    {
        private TextView tv_app;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_app_read);
            tv_app = FindViewById<TextView>(Resource.Id.tv_app);
            readAppMemory();
           
        }

        private void readAppMemory()
        {
            String desc = "全局内存中保存的信息如下：";
            // 获取当前应用的Application实例
             MainApplication app = MainApplication.getInstance();
          
            // 获取Application实例中保存的映射全局变量
            Dictionary<String, String> mapParam = app.mInfoMap;
            // 遍历映射全局变量内部的键值对信息
            // foreach (Dictionary<String, String> item_map in mapParam)
            foreach (KeyValuePair <String, String> item_map in mapParam)
            {
                desc = String.Format("{0}\n　{1}的取值为{2}",
                        desc, item_map.Key, item_map.Value);
            }
            if (mapParam.Count <= 0)
            {
                desc = "全局内存中保存的信息为空";
            }
            tv_app.Text=desc;
        }
    }
}