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
using custom.bean;
using custom.util;

namespace custom
{
    [Activity(Label = "AppInfoActivity")]
    public class AppInfoActivity : Activity
    {
        private readonly static String TAG = "AppInfoActivity";
        private ListView lv_appinfo; // 声明一个列表视图对象

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_app_info);
            // 从布局文件中获取名叫lv_appinfo的列表视图
            lv_appinfo = FindViewById<ListView>(Resource.Id.lv_appinfo);
            initTypeSpinner();
            // Create your application here
        }

        private void initTypeSpinner()
        {
            ArrayAdapter<String> typeAdapter = new ArrayAdapter<String>(this,
            Resource.Layout.item_select, typeArray);
            Spinner sp_list = FindViewById<Spinner>(Resource.Id.sp_type);
            sp_list.Prompt="请选择应用类型";
            sp_list.Adapter=typeAdapter;
            //   sp_list.setOnItemSelectedListener(new TypeSelectedListener());
            sp_list.ItemSelected += Sp_list_ItemSelected;
            sp_list.SetSelection(0);
        }

        private void Sp_list_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           //  List<AppInfo> appinfoList = AppUtil.getAppInfo(AppInfoActivity.this, e.Id);
            //List<AppInfo> appinfoList = AppUtil.getAppInfo(Android.Content.Context, e.Id);
            //// 构建一个应用信息的列表适配器
            //AppInfoAdapter adapter = new AppInfoAdapter(AppInfoActivity.this, appinfoList);
            // 给lv_appinfo设置应用信息列表适配器
         //   lv_appinfo.Adapter=adapter;
        }

        private String[] typeArray = { "所有应用", "联网应用" };
    }
}