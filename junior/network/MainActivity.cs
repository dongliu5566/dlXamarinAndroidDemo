using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;
using Android.Content.PM;

namespace network
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
            FindViewById(Resource.Id.btn_message).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_progress_dialog).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_progress_text).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_progress_circle).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_async_task).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_intent_service).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_connect).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_json_parse).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_json_convert).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_http_request).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_http_image).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_download_apk).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_download_image).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_file_save).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_file_select).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_upload_http).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_net_address).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_socket).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_apk_info).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_app_store).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_fold_list).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_qqchat).SetOnClickListener(this);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == Resource.Id.btn_http_request % 4096)
            {
                //  if (grantResults[0] == PackageManager.PERMISSION_GRANTED)
                if (grantResults[0] == Permission.Granted)
                {
                    //    PermissionUtil.goActivity(this,typeof(HttpRequestActivity));
                }
                else
                {
                    Toast.MakeText(this, "需要允许定位权限才能开始定位噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_file_save % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    // PermissionUtil.goActivity(this, FileSaveActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能保存文件噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_file_select % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    //   PermissionUtil.goActivity(this, FileSelectActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能打开文件噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_upload_http % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    //   PermissionUtil.goActivity(this, UploadHttpActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能上传文件噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_apk_info % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    //  PermissionUtil.goActivity(this, ApkInfoActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能查找安装包噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_app_store % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    //  PermissionUtil.goActivity(this, AppStoreActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能升级应用噢", ToastLength.Short).Show();
                }
            }
            else if (requestCode == Resource.Id.btn_qqchat % 4096)
            {
                if (grantResults[0] == Permission.Granted)
                {
                    //   PermissionUtil.goActivity(this, QQLoginActivity.class);
                }
                else
                {
                    Toast.MakeText(this, "需要允许SD卡权限才能开始聊天噢", ToastLength.Short).Show();
                }

            }
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_message)
            {
                Intent intent = new Intent(this,typeof(MessageActivity));
               StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_progress_dialog)
            {
               Intent intent = new Intent(this, typeof(ProgressDialogActivity));
               StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_progress_text)
            {
               Intent intent = new Intent(this, typeof(ProgressTextActivity));
               StartActivity(intent);
             }
            else if (v.Id == Resource.Id.btn_progress_circle) 
            {
               Intent intent = new Intent(this, typeof(ProgressCircleActivity));
              StartActivity(intent);
            }
             else if (v.Id == Resource.Id.btn_async_task) 
            {
                Intent intent = new Intent(this, typeof(AsyncTaskActivity));
                StartActivity(intent);
            }
             else if (v.Id == Resource.Id.btn_intent_service) 
            {
               Intent intent = new Intent(this, typeof(IntentServiceActivity));
               StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_connect) 
            {
              Intent intent = new Intent(this,typeof(ConnectActivity));
              StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_json_parse)
            {
              Intent intent = new Intent(this, typeof(JsonParseActivity));
              StartActivity(intent);
              } else if (v.Id == Resource.Id.btn_json_convert) 
            {
             //    Intent intent = new Intent(this, JsonConvertActivity.class);
            //  StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_http_request) {
    //        if (PermissionUtil.checkPermission(this, Manifest.permission.ACCESS_FINE_LOCATION, Resource.Id.btn_http_request % 4096)) {
    //PermissionUtil.goActivity(this, HttpRequestActivity.class);
           // }
           }
            else if (v.Id == Resource.Id.btn_http_image)
            {
            Intent intent = new Intent(this, typeof(HttpImageActivity));
            StartActivity(intent);
           }
            else if (v.Id == Resource.Id.btn_download_apk) 
            {
              Intent intent = new Intent(this,typeof(DownloadApkActivity));
              StartActivity(intent);
           } 
            else if (v.Id == Resource.Id.btn_download_image) 
            {
            Intent intent = new Intent(this, typeof(DownloadImageActivity));
            StartActivity(intent);
           }
            else if (v.Id == Resource.Id.btn_file_save) 
            {
           // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_file_save % 4096)) {
         //   PermissionUtil.goActivity(this, FileSaveActivity.class);
         //    }
             } else if (v.Id == Resource.Id.btn_file_select) {
       //     if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_file_select % 4096)) {
    //   PermissionUtil.goActivity(this, FileSelectActivity.class);
       //}
         } else if (v.Id == Resource.Id.btn_upload_http)
            {
          //  if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_upload_http % 4096)) {
    //   PermissionUtil.goActivity(this, UploadHttpActivity.class);
       //      }
      } else if (v.Id == Resource.Id.btn_net_address) 
            {
            Intent intent = new Intent(this, typeof(NetAddressActivity));
            StartActivity(intent);
         } else if (v.Id == Resource.Id.btn_socket) {
            Intent intent = new Intent(this,typeof(SocketActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_apk_info) {
           // if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_apk_info % 4096)) {
  //  PermissionUtil.goActivity(this, ApkInfoActivity.class);
    //        }
        } else if (v.Id == Resource.Id.btn_app_store) {
       //     if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_app_store % 4096)) {
    //   PermissionUtil.goActivity(this, AppStoreActivity.class);
      //}
        } 
            else if (v.Id == Resource.Id.btn_fold_list)
            {
            Intent intent = new Intent(this,typeof(FoldListActivity));
            StartActivity(intent);
        } else if (v.Id == Resource.Id.btn_qqchat) {
      //      if (PermissionUtil.checkPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE, Resource.Id.btn_qqchat % 4096)) {
   // PermissionUtil.goActivity(this, QQLoginActivity.class);
     //       }
        }
        }
    }

}