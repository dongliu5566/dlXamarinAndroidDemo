using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Widget.TextView;
using System.Drawing;
using Android.Content.Res;

namespace app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // 当前的页面布局采用的是res/layout/activity_main.xml
           
            // 获取名叫tv_hello的TextView控件
            TextView tv_hello = FindViewById<TextView>(Resource.Id.tv_hello);
            // 设置TextView控件的文字内容
            tv_hello.SetText("今天天气真热啊，火辣辣的", BufferType.Normal);
            // 设置TextView控件的文字颜色
       //     tv_hello.setTextColor(Color.RED);
            tv_hello.SetTextColor(Android.Graphics.Color.Red);
            // 设置TextView控件的文字大小
            tv_hello.TextSize=30;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}