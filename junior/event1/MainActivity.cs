using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace event1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViewById(Resource.Id.btn_key_soft).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_key_hard).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_volume_set).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_gesture_detector).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_view_flipper).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_banner_flipper).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_event_dispatch).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_event_intercept).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_touch_single).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_touch_multiple).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_signature).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_custom_scroll).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_disallow_scroll).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_drawer_layout).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pull_refresh).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_change).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_cut).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_meitu).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_gl_line).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_gl_globe).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_gl_panorama).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_key_soft)
            {
                Intent intent = new Intent(this, typeof(KeySoftActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_key_hard)
            {
                Intent intent = new Intent(this, typeof(KeyHardActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_volume_set)
            {
                Intent intent = new Intent(this, typeof(VolumeSetActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_gesture_detector)
            {
                Intent intent = new Intent(this, typeof(GestureDetectorActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_view_flipper)
            {
                Intent intent = new Intent(this, typeof(ViewFlipperActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_banner_flipper)
            {
                Intent intent = new Intent(this, typeof(BannerFlipperActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_event_dispatch)
            {
                Intent intent = new Intent(this, typeof(EventDispatchActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_event_intercept)
            {
                Intent intent = new Intent(this, typeof(EventInterceptActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_touch_single)
            {
                Intent intent = new Intent(this, typeof(TouchSingleActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_touch_multiple)
            {
                Intent intent = new Intent(this, typeof(TouchMultipleActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_signature)
            {
                //   if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_signature % 4096)) {
                // PermissionUtil.goActivity(this, SignatureActivity.class);
                //       }
            }
            else if (v.Id == Resource.Id.btn_custom_scroll)
            {
                Intent intent = new Intent(this, typeof(CustomScrollActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_disallow_scroll)
            {
                Intent intent = new Intent(this, typeof(DisallowScrollActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_drawer_layout)
            {
                Intent intent = new Intent(this, typeof(DrawerLayoutActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_pull_refresh)
            {
                Intent intent = new Intent(this, typeof(PullRefreshActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_image_change)
            {
                //   if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_image_change % 4096)) {
                //   PermissionUtil.goActivity(this, ImageChangeActivity.class);
                //   }
            }
            else if (v.Id == Resource.Id.btn_image_cut)
            {
                //   if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_image_cut % 4096)) {
                //    PermissionUtil.goActivity(this, ImageCutActivity.class);
                //          }
            }
            else if (v.Id == Resource.Id.btn_meitu)
            {
                // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_meitu % 4096)) {
                // PermissionUtil.goActivity(this, MeituActivity.class);
                //       }
            }
            else if (v.Id == Resource.Id.btn_gl_line)
            {
                Intent intent = new Intent(this, typeof(GlLineActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_gl_globe)
            {
                Intent intent = new Intent(this, typeof(GlGlobeActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_gl_panorama)
            {
                Intent intent = new Intent(this, typeof(GlPanoramaActivity));
                StartActivity(intent);
            }

        }
        private bool needExit = false; // 是否需要退出App
                                          // 在发生物理按键动作时触发
        public  bool OnKeyDown(Keycode keyCode, KeyEvent  event1)
          {
          //  if (keyCode == KeyEvent.KEYCODE_BACK)  //java写法
             if (keyCode == Keycode.Back)
            { // 按下返回键
                if (needExit)
                {
                    Finish(); // 关闭当前页面
                }
                needExit = true;
                Toast.MakeText(this, "再按一次返回键退出!", ToastLength.Short).Show();
                return true;
            }
            else
            {
                return base.OnKeyDown(keyCode, event1);
        }
    }
}
}
