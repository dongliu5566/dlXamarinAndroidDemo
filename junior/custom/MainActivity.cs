using Android.App;
using Android.Content;
using Android.OS;

using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace custom
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FindViewById(Resource.Id.btn_custom_property).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_measure_text).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_measure_layout).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_on_measure).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_on_layout).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_show_draw).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_runnable).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pull_refresh).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_circle_animation).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_window).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_dialog_date).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_dialog_multi).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_notify_simple).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_notify_counter).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_notify_progress).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_notify_custom).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_service_normal).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_bind_immediate).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_bind_delay).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_notify_service).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_app_info).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_traffic_info).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_mobile_assistant).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_custom_property)
            {
                Intent intent = new Intent(this,typeof(CustomPropertyActivity));
                  StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_measure_text) {
            Intent intent = new Intent(this, typeof(MeasureTextActivity));
            StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_measure_layout) {
            Intent intent = new Intent(this, typeof(MeasureLayoutActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_on_measure) {
            Intent intent = new Intent(this, typeof(OnMeasureActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_on_layout) {
            Intent intent = new Intent(this, typeof(OnLayoutActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_show_draw) {
            Intent intent = new Intent(this,typeof(ShowDrawActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_runnable) {
            Intent intent = new Intent(this,typeof(RunnableActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_pull_refresh) {
            Intent intent = new Intent(this, typeof(PullRefreshActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_circle_animation) {
            Intent intent = new Intent(this, typeof(CircleAnimationActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_window) {
            Intent intent = new Intent(this, typeof(WindowActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_dialog_date) {
            Intent intent = new Intent(this, typeof(DialogDateActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_dialog_multi) {
            Intent intent = new Intent(this, typeof(DialogMultiActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_notify_simple) {
            Intent intent = new Intent(this, typeof(NotifySimpleActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_notify_counter) {
            Intent intent = new Intent(this, typeof(NotifyCounterActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_notify_progress) {
            Intent intent = new Intent(this, typeof(NotifyProgressActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_notify_custom) {
            Intent intent = new Intent(this, typeof(NotifyCustomActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_service_normal) {
            Intent intent = new Intent(this, typeof(ServiceNormalActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_bind_immediate) {
            Intent intent = new Intent(this, typeof(BindImmediateActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_bind_delay) {
            Intent intent = new Intent(this, typeof(BindDelayActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_notify_service) {
            Intent intent = new Intent(this, typeof(NotifyServiceActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_app_info) {
            Intent intent = new Intent(this, typeof(AppInfoActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_traffic_info) {
            Intent intent = new Intent(this, typeof(TrafficInfoActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_mobile_assistant) {
            Intent intent = new Intent(this, typeof(MobileAssistantActivity));
            StartActivity(intent);
        }
        }
    }
}