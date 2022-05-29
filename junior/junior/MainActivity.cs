using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace junior
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        /// <summary>
        /// https://www.cnblogs.com/nightswatch/p/4276840.html
        /// Mono for android，Xamarin点击事件的多种写法
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //   FindViewById<Button>(Resource.Id.btn_px).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_px).SetOnClickListener(this);
            // findViewById(R.id.btn_color).setOnClickListener(this);
            FindViewById(Resource.Id.btn_color).SetOnClickListener(this);
            //    findViewById(R.id.btn_screen).setOnClickListener(this);
            FindViewById(Resource.Id.btn_screen).SetOnClickListener(this);
            //findViewById(R.id.btn_margin).setOnClickListener(this);
            FindViewById(Resource.Id.btn_margin).SetOnClickListener(this);
            //findViewById(R.id.btn_gravity).setOnClickListener(this);
            FindViewById(Resource.Id.btn_gravity).SetOnClickListener(this);
            //findViewById(R.id.btn_scroll).setOnClickListener(this);
            FindViewById(Resource.Id.btn_scroll).SetOnClickListener(this);
            //findViewById(R.id.btn_marquee).setOnClickListener(this);
            FindViewById(Resource.Id.btn_marquee).SetOnClickListener(this);
            //findViewById(R.id.btn_bbs).setOnClickListener(this);
            FindViewById(Resource.Id.btn_bbs).SetOnClickListener(this);
            //findViewById(R.id.btn_click).setOnClickListener(this);
            FindViewById(Resource.Id.btn_click).SetOnClickListener(this);
            //findViewById(R.id.btn_scale).setOnClickListener(this);
            FindViewById(Resource.Id.btn_scale).SetOnClickListener(this);
            //findViewById(R.id.btn_capture).setOnClickListener(this);
            FindViewById(Resource.Id.btn_capture).SetOnClickListener(this);
            //findViewById(R.id.btn_icon).setOnClickListener(this);
            FindViewById(Resource.Id.btn_icon).SetOnClickListener(this);
            //findViewById(R.id.btn_state).setOnClickListener(this);
            FindViewById(Resource.Id.btn_state).SetOnClickListener(this);
            //findViewById(R.id.btn_shape).setOnClickListener(this);
            FindViewById(Resource.Id.btn_shape).SetOnClickListener(this);
            //findViewById(R.id.btn_nine).setOnClickListener(this);
            FindViewById(Resource.Id.btn_nine).SetOnClickListener(this);
            //findViewById(R.id.btn_calculator).setOnClickListener(this);
            FindViewById(Resource.Id.btn_calculator).SetOnClickListener(this);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            // throw new System.NotImplementedException();
            if (v.Id == Resource.Id.btn_px)
            {
                Intent intent = new Intent(this, typeof(PxActivity));
                StartActivity(intent);

            }
            else if (v.Id == Resource.Id.btn_color)
            {
                Intent intent = new Intent(this, typeof(ColorActivity));
                      StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_margin)
            {
                Intent intent = new Intent(this, typeof(MarginActivity));
                 StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_gravity)
            {
               Intent intent = new Intent(this, typeof(GravityActivity));
                StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_scroll)
            {
            Intent intent = new Intent(this, typeof(ScrollActivity));
             StartActivity(intent);
            }

            else if (v.Id == Resource.Id.btn_marquee)
            {
                Intent intent = new Intent(this, typeof(MarqueeActivity));
                 StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_bbs)
            {
                Intent intent = new Intent(this, typeof(BbsActivity));
                StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_click)
            {
                Intent intent = new Intent(this, typeof(ClickActivity));
                    StartActivity(intent);
             }

            else if (v.Id== Resource.Id.btn_scale)
            {
                Intent intent = new Intent(this, typeof(ScaleActivity));
                 StartActivity(intent);
             }

            else if (v.Id == Resource.Id.btn_capture)
            {
                Intent intent = new Intent(this, typeof(CaptureActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_icon)
            {
                Intent intent = new Intent(this, typeof(IconActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_state)
            {
                Intent intent = new Intent(this, typeof(StateActivity));
                  StartActivity(intent);
             }

            else if (v.Id == Resource.Id.btn_shape)
            {
                Intent intent = new Intent(this, typeof(ShapeActivity));
                  StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_nine)
            {
                Intent intent = new Intent(this, typeof(NineActivity));
                  StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_calculator)
            {
                Intent intent = new Intent(this, typeof(CalculatorActivity));
                 StartActivity(intent);
             }

}
    }
}