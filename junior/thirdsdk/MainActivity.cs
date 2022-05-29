using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace thirdsdk
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

            FindViewById(Resource.Id.btn_map_baidu).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_map_gaode).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_share_qq).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_share_wx).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_alipay).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_tts_language).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_tts_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_voice_recognize).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_voice_compose).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_rating_bar).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_take_tax).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);



        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_map_baidu)
            {
               // if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, Resource.Id.btn_map_baidu % 4096))
               // {
                 //   PermissionUtil.goActivity(this, MapBaiduActivity.class);
               //  }
            } else if (v.Id == Resource.Id.btn_map_gaode) {
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, Resource.Id.btn_map_gaode % 4096)) {
    // PermissionUtil.goActivity(this, MapGaodeActivity.class);
      //      }
        } else if (v.Id == Resource.Id.btn_share_qq) {
            Intent intent = new Intent(this,typeof(ShareQQActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_share_wx) {
            Toast.MakeText(this, "微信分享请移步weixin模块", ToastLength.Long).Show();
            } else if (v.Id == Resource.Id.btn_alipay) {
            Intent intent = new Intent(this,typeof(AlipayActivity));
            StartActivity(intent);
         } else if (v.Id == Resource.Id.btn_wxpay) {
            Toast.MakeText(this, "微信支付请移步weixin模块", ToastLength.Long).Show();
           } else if (v.Id == Resource.Id.btn_tts_language) {
            Intent intent = new Intent(this,typeof(TtsLanguageActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_tts_read) {
            Intent intent = new Intent(this, typeof(TtsReadActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_voice_recognize) {
       //     if (PermissionUtil.checkPermission(this, Manifest.permission.RECORD_AUDIO, Resource.Id.btn_voice_recognize % 4096)) {
   // PermissionUtil.goActivity(this, VoiceRecognizeActivity.class);
     //       }
        } else if (v.Id == Resource.Id.btn_voice_compose) {
            Intent intent = new Intent(this, typeof(VoiceComposeActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_rating_bar) {
            Intent intent = new Intent(this, typeof(RatingBarActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_take_tax) {
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, Resource.Id.btn_take_tax % 4096)) {
   // PermissionUtil.goActivity(this, TakeTaxActivity.class);
     //       }
        }
        }
    }
}