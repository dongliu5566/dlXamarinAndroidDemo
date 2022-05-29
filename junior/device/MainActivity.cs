using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace device
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

            FindViewById( Resource.Id.btn_turn_view).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_turn_surface).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_camera_info).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_photograph).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_turn_texture).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_shooting).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_seekbar).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_volume).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_audio).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_video).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_sensor).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_acceleration).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_light).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_direction).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_step).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_gyroscope).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_location_setting).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_location_begin).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_nfc).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_infrared).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_bluetooth).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_navigation).SetOnClickListener(this);
            FindViewById( Resource.Id.btn_wechat).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [System.Obsolete]
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_turn_view)
            {
                Intent intent = new Intent(this,typeof(TurnViewActivity));
                StartActivity(intent);
            } 
            else if (v.Id == Resource.Id.btn_turn_surface) 
            {
                Intent intent = new Intent(this, typeof(TurnSurfaceActivity));
                 StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_camera_info)
            {
             
               // if (PermissionUtil.checkPermission(this, Manifest.permission.CAMERA, R.id.btn_camera_info % 4096)) {
               //  PermissionUtil.goActivity(this, CameraInfoActivity.class);
            }
            else if (v.Id == Resource.Id.btn_photograph) {
            // if (PermissionUtil.checkPermission(this, Manifest.permission.CAMERA, R.id.btn_photograph % 4096)) {
            //   PermissionUtil.goActivity(this, PhotographActivity.class);
           //  }
             } else if (v.Id == Resource.Id.btn_turn_texture) {
            Intent intent = new Intent(this,typeof(TurnTextureActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_shooting) {
            //if (Build.VERSION.SDK_INT<Build.VERSION_CODES.LOLLIPOP) {
            //    Toast.makeText(MainActivity.this, "Andorid版本低于5.0无法使用camera2",
            //            Toast.LENGTH_SHORT).show();
          //  } else if (PermissionUtil.checkPermission(this, Manifest.permission.CAMERA, R.id.btn_shooting % 4096)) {
         //      PermissionUtil.goActivity(this, ShootingActivity.class);
          //  }
        } else if (v.Id == Resource.Id.btn_seekbar) {
            Intent intent = new Intent(this, typeof(SeekbarActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_volume) {
            Intent intent = new Intent(this, typeof(VolumeActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_audio) {
         //   if (PermissionUtil.checkPermission(this, Manifest.permission.RECORD_AUDIO, R.id.btn_audio % 4096)) {
    //    PermissionUtil.goActivity(this, AudioActivity.class);
      //      }
        //} else if (v.Id() == R.id.btn_video) {
        //    if (PermissionUtil.checkMultiPermission(this, new String[] {
        //            Manifest.permission.RECORD_AUDIO, Manifest.permission.CAMERA}, R.id.btn_video % 4096)) {
        //        PermissionUtil.goActivity(this, VideoActivity.class);
        //    }
        } else if (v.Id == Resource.Id.btn_sensor) {
            Intent intent = new Intent(this,typeof(SensorActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_acceleration) {
            Intent intent = new Intent(this,typeof(AccelerationActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_light) {
    //        if (PermissionUtil.checkWriteSettings(this, R.id.btn_light % 4096)) {
    //PermissionUtil.goActivity(this, LightActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_direction) {
            Intent intent = new Intent(this,typeof(DirectionActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_step) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.Kitkat) {
                Toast.MakeText(this, "计步器需要Android4.4或以上版本",
                        ToastLength.Short).Show();
                  } else {
                Intent intent = new Intent(this,typeof(StepActivity));
                StartActivity(intent);
              }
        } else if (v.Id == Resource.Id.btn_gyroscope) {
            Intent intent = new Intent(this,typeof(GyroscopeActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_location_setting) {
            Intent intent = new Intent(this,typeof(LocationSettingActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_location_begin) {
        //    if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, R.id.btn_location_begin % 4096)) {
             // PermissionUtil.goActivity(this, LocationActivity.class);
           // }
        } else if (v.Id == Resource.Id.btn_nfc) {
            Intent intent = new Intent(this,typeof(NfcActivity));
            StartActivity(intent);
         } else if (v.Id == Resource.Id.btn_infrared) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.Kitkat) {
                Toast.MakeText(this, "红外遥控需要Android4.4或以上版本",
                       ToastLength.Short).Show();
              } else {
                Intent intent = new Intent(this, typeof(InfraredActivity));
                StartActivity(intent);
            }
        } else if (v.Id == Resource.Id.btn_bluetooth) {
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M) {
                // Android6.0之后使用蓝牙需要定位权限
               // if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, R.id.btn_bluetooth % 4096)) {
      //  PermissionUtil.goActivity(this, BluetoothActivity.class);
        //        }
          //  } else {
            //    PermissionUtil.goActivity(this, BluetoothActivity.class);
           // }
        } else if (v.Id == Resource.Id.btn_navigation) {
      //      if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, R.id.btn_navigation % 4096)) {
  //  PermissionUtil.goActivity(this, NavigationActivity.class);
    //        }
        } else if (v.Id== Resource.Id.btn_wechat) {
            Intent intent = new Intent(this,typeof(WeChatActivity));
            StartActivity(intent);
        }
        }
    }
}