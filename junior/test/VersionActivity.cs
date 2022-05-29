using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Content.PM.PackageManager;

namespace test
{
    [Activity(Label = "VersionActivity")]
    public class VersionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_version);
            ImageView iv_icon = FindViewById<ImageView>(Resource.Id.iv_icon);
            TextView tv_desc = FindViewById<TextView>(Resource.Id.tv_desc);
            iv_icon.SetImageResource(Resource.Mipmap.ic_launcher);
            try
            {
                // 先获取当前应用的包名，再根据包名获取详细的应用信息
             //   PackageInfo pi = getPackageManager().getPackageInfo(getPackageName(), 0);
                PackageInfo pi = PackageManager.GetPackageInfo(PackageName, 0);
                String desc = String.Format("App名称为：{0}\nApp版本号为：{1}\nApp版本名称为：{2}",
                   //    getResources().getString(R.string.app_name), pi.versionCode, pi.versionName);
                   Resources.GetString(Resource.String.app_name), pi.VersionCode, pi.VersionName);
                   tv_desc.Text= desc;
            }
            catch (NameNotFoundException e)
            {
                tv_desc.Text = e.StackTrace;
               //     e.printStackTrace();
            }
            // Create your application here
        }
    }
}