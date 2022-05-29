using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Java.Lang;
using Android.Content;

namespace mixture
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity , IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViewById(Resource.Id.btn_assets_text).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_assets_image).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_web_local).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_web_span).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_web_browser).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_web_script).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_jni_cpu).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_jni_secret).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_wifi_info).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_wifi_connect).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_wifi_ap).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_bluetooth_trans).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_netbios).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_wifi_share).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pdf_render).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_ebook_reader).SetOnClickListener(this);
           // mHandler.postDelayed(mImportService, 100);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private Handler mHandler = new Handler();
//        private Runnable mImportService = new Runnable()=> {
    
//        public void run()
//        {
//            Intent intent = new Intent(this,typeof(ImportDeviceService));
//            StartService(intent);
//    }
//};
public void OnClick(View v)
        {
           
        }
    }
}