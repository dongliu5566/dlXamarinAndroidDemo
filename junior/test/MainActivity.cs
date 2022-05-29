using Android.App;
using Android.Content;
using Android.OS;
//using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity , IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
       
            FindViewById(Resource.Id.btn_version).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_encrypt).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_version)
            {
                Intent intent = new Intent(this,typeof(VersionActivity));
                 StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_encrypt) {
            Intent intent = new Intent(this,typeof(EncryptActivity));
            StartActivity(intent);
           }
        }
    }
}