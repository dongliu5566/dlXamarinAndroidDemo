using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace media
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

            FindViewById(Resource.Id.btn_gallery).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_recycler_view).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_switcher).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_card_view).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_palette).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_ring_tone).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sound_pool).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_audio_track).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_video_view).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_video_controller).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_media_controller).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_custom_controller).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_split_screen).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_pic_in_pic).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_float_window).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_screen_capture).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_screen_record).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_orientation).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_movie_player).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_spannable).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_music_player).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_gallery)
            {
                Intent intent = new Intent(this,typeof(GalleryActivity));
            StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_recycler_view) {
            Intent intent = new Intent(this, typeof(RecyclerViewActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_image_switcher) {
            Intent intent = new Intent(this, typeof(ImageSwitcherActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_card_view) {
            Intent intent = new Intent(this, typeof(CardViewActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_palette) {
            Intent intent = new Intent(this, typeof(PaletteActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_ring_tone) {
            Intent intent = new Intent(this, typeof(RingtoneActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_sound_pool) {
            Intent intent = new Intent(this, typeof(SoundPoolActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_audio_track) {
      //      if (PermissionUtil.checkPermission(this, Manifest.permission.RECORD_AUDIO, Resource.Id.btn_audio_track % 4096)) {
  //  PermissionUtil.goActivity(this, AudioTrackActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_video_view) {
         //   if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_video_view % 4096)) {
 //   PermissionUtil.goActivity(this, VideoViewActivity.class);
   //         }
        } else if (v.Id == Resource.Id.btn_video_controller) {
           // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_video_controller % 4096)) {
//    PermissionUtil.goActivity(this, VideoControllerActivity.class);
  //          }
        } else if (v.Id == Resource.Id.btn_media_controller) {
       //     if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_media_controller % 4096)) {
   // PermissionUtil.goActivity(this, MediaControllerActivity.class);
     //       }
        } else if (v.Id == Resource.Id.btn_custom_controller) {
         //   if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_custom_controller % 4096)) {
  //  PermissionUtil.goActivity(this, CustomControllerActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_split_screen) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.N) {
                Toast.MakeText(this, "分屏功能需要Android7.0或以上版本", ToastLength.Short).Show();
                return;
              }
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_split_screen % 4096)) {
   // PermissionUtil.goActivity(this, SplitScreenActivity.class);
     //       }
        } else if (v.Id == Resource.Id.btn_pic_in_pic) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.O) {
                Toast.MakeText(this, "画中画功能需要Android8.0或以上版本", ToastLength.Short).Show();
                return;
}
           // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_pic_in_pic % 4096)) {
  //  PermissionUtil.goActivity(this, PicInPicActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_float_window) {
            Intent intent = new Intent(this,typeof(FloatWindowActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_screen_capture) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.Lollipop) {
                Toast.MakeText(this, "截屏功能需要Android5.0或以上版本", ToastLength.Short).Show();
                return;
              }
           // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_screen_capture % 4096)) {
  //  PermissionUtil.goActivity(this, ScreenCaptureActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_screen_record) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.Lollipop) {
                Toast.MakeText(this, "录屏功能需要Android5.0或以上版本", ToastLength.Short).Show();
                return;
}
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_screen_record % 4096)) {
//    PermissionUtil.goActivity(this, ScreenRecordActivity.class);
  //          }
        } else if (v.Id == Resource.Id.btn_orientation) {
            Intent intent = new Intent(this, typeof(OrientationActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_movie_player) {
       //     if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_movie_player % 4096)) {
 //   PermissionUtil.goActivity(this, MoviePlayerActivity.class);
   //         }
        } else if (v.Id == Resource.Id.btn_spannable) {
            Intent intent = new Intent(this, typeof(SpannableActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_music_player) {
            if (Build.VERSION.SdkInt<Build.VERSION_CODES.Kitkat) {
                Toast.MakeText(this, "歌词滚动的暂停与恢复功能需要Android4.4或以上版本", ToastLength.Short).Show();
                return;
}
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_music_player % 4096)) {
  //  PermissionUtil.goActivity(this, MusicPlayerActivity.class);
         //   }
        }

         //   throw new System.NotImplementedException();
        }
    }
}