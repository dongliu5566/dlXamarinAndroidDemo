using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace performance
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

            FindViewById(Resource.Id.btn_include_one).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_include_two).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_screen_suitable).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_window_style).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_remove_task).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_logout_service).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_refer_strong).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_refer_weak).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_thread_pool).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_schedule_pool).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_battery_info).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_power_saving).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_alarm_idle).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_lru_cache).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_cache).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_include_one)
            {
                Intent intent = new Intent(this,typeof(IncludeOneActivity));
            StartActivity(intent);
            } else if (v.Id  == Resource.Id.btn_include_two) {
            Intent intent = new Intent(this, typeof(IncludeTwoActivity) );
            StartActivity(intent);
            } else if (v.Id  == Resource.Id.btn_screen_suitable) {
            Intent intent = new Intent(this, typeof(ScreenSuitableActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_window_style) {
            Intent intent = new Intent(this, typeof(WindowStyleActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_remove_task) {
            Intent intent = new Intent(this, typeof(RemoveTaskActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_logout_service) {
            Intent intent = new Intent(this, typeof(LogoutServiceActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_refer_strong) {
            Intent intent = new Intent(this, typeof(ReferStrongActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_refer_weak) {
            Intent intent = new Intent(this, typeof(ReferWeakActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_thread_pool) {
            Intent intent = new Intent(this, typeof(ThreadPoolActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_schedule_pool) {
            Intent intent = new Intent(this, typeof(SchedulePoolActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_battery_info) {
            Intent intent = new Intent(this, typeof(BatteryInfoActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_power_saving) {
            Intent intent = new Intent(this, typeof(PowerSavingActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_alarm_idle) {
            Intent intent = new Intent(this, typeof(AlarmIdleActivity) );
            StartActivity(intent);
        } else if (v.Id  == Resource.Id.btn_lru_cache) {
            Intent intent = new Intent(this, typeof(LruCacheActivity) );
            startActivity(intent);
        } else if (v.Id  == Resource.Id.btn_image_cache) {
            Intent intent = new Intent(this, ImageCacheActivity );
            startActivity(intent);
        }
        }
    }
}