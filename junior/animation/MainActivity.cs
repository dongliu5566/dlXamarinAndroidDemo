using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace animation
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

            FindViewById(Resource.Id.btn_frame_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_gif).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_fade_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_tween_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_swing_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_anim_set).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_banner_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_object_anim).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_object_group).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_interpolator).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_vector_drawable).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_vector_smile).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_vector_hook).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pay_success).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pie).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_expand).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_scroller).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_shutter).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_mosaic).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_yingji).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [System.Obsolete]
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_frame_anim)
            {
                Intent intent = new Intent(this,typeof(FrameAnimActivity));
                StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_gif) {
            Intent intent = new Intent(this,typeof(GifActivity));
            StartActivity(intent);
         } else if (v.Id == Resource.Id.btn_fade_anim) {
            Intent intent = new Intent(this, typeof(FadeAnimActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_tween_anim) {
            Intent intent = new Intent(this, typeof(TweenAnimActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_swing_anim) {
            Intent intent = new Intent(this, typeof(SwingAnimActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_anim_set) {
            Intent intent = new Intent(this, typeof(AnimSetActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_banner_anim) {
            Intent intent = new Intent(this, typeof(BannerAnimActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_object_anim) {
            Intent intent = new Intent(this, typeof(ObjectAnimActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_object_group) {
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Kitkat) {
                Intent intent = new Intent(this,typeof(ObjectGroupActivity));
                StartActivity(intent);
            } else {
                Toast.MakeText(this, "属性动画的暂停与恢复功能需要Android4.4或以上版本", ToastLength.Short).Show();
            }
        } else if (v.Id == Resource.Id.btn_interpolator) {
            Intent intent = new Intent(this,typeof(InterpolatorActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_vector_drawable) {
            Intent intent = new Intent(this, typeof(VectorDrawableActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_vector_smile) {
            Intent intent = new Intent(this, typeof(VectorSmileActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_vector_hook) {
            Intent intent = new Intent(this, typeof(VectorHookActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_pay_success) {
            Intent intent = new Intent(this, typeof(PaySuccessActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_pie) {
            Intent intent = new Intent(this, typeof(PieActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_expand) {
            Intent intent = new Intent(this, typeof(ExpandActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_scroller) {
            Intent intent = new Intent(this, typeof(ScrollerActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_shutter) {
            Intent intent = new Intent(this, typeof(ShutterActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_mosaic) {
            Intent intent = new Intent(this, typeof(MosaicActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_yingji) {
             //   if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN_MR2)
                 if (Build.VERSION.SdkInt >= Build.VERSION_CODES.JellyBeanMr2) {
                Intent intent = new Intent(this,typeof(YingjiActivity));
                StartActivity(intent);
            } else {
                Toast.MakeText(this, "播放动感影集需要Android4.3或以上版本", ToastLength.Short).Show();
}
        }
        }
    }
}