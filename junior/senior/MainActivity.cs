using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace senior
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
            FindViewById(Resource.Id.btn_date_picker).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_time_picker).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_base_adapter).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_list_view).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_list_cart).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_grid_view).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_grid_channel).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_view_pager).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_title_strip).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_tab_strip).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_launch_simple).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_fragment_static).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_fragment_dynamic).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_launch_improve).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_broad_temp).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_broad_system).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_alarm).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_month_picker).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_calendar).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_vibrator).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_schedule).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_date_picker)
            {
                Intent intent = new Intent(this, typeof(DatePickerActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_time_picker)
            {
                Intent intent = new Intent(this, typeof(TimePickerActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_base_adapter)
            {
                Intent intent = new Intent(this, typeof(BaseAdapterActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_list_view)
            {
                Intent intent = new Intent(this, typeof(ListViewActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_list_cart)
            {
                Intent intent = new Intent(this, typeof(ShoppingCartActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_grid_view)
            {
                Intent intent = new Intent(this, typeof(GridViewActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_grid_channel)
            {
                Intent intent = new Intent(this, typeof(ShoppingChannelActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_view_pager)
            {
                Intent intent = new Intent(this, typeof(ViewPagerActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_title_strip)
            {
                Intent intent = new Intent(this, typeof(PagerTitleStripActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_tab_strip)
            {
                Intent intent = new Intent(this, typeof(PagerTabStripActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_launch_simple)
            {
                Intent intent = new Intent(this, typeof(LaunchSimpleActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_fragment_static)
            {
                Intent intent = new Intent(this, typeof(FragmentStaticActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_fragment_dynamic)
            {
                Intent intent = new Intent(this, typeof(FragmentDynamicActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_launch_improve)
            {
                Intent intent = new Intent(this, typeof(LaunchImproveActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_broad_temp)
            {
                Intent intent = new Intent(this, typeof(BroadTempActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_broad_system)
            {
                Intent intent = new Intent(this, typeof(BroadSystemActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_alarm)
            {
                Intent intent = new Intent(this, typeof(AlarmActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_month_picker)
            {
                Intent intent = new Intent(this, typeof(MonthPickerActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_calendar)
            {
                Intent intent = new Intent(this, typeof(CalendarActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_vibrator)
            {
                Intent intent = new Intent(this, typeof(VibratorActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_schedule)
            {
                Intent intent = new Intent(this, typeof(ScheduleActivity));
                StartActivity(intent);
            }
        }
    }
}