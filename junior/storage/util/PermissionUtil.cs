using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
//using Java.Security;

namespace storage.util
{
    public class PermissionUtil
    {
        private readonly static String TAG = "PermissionUtil";

        // 检查某个权限。返回true表示已启用该权限，返回false表示未启用该权限
        public static bool checkPermission(Activity act, String permission, int requestCode)
        {
            Log.Debug(TAG, "checkPermission: " + permission);
            bool result = true;
            // 只对Android6.0及以上系统进行校验
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M)
            {
                // 检查当前App是否开启了名称为permission的权限
                //   int check = ContextCompat.checkSelfPermission(act, permission);
                Permission check = ContextCompat.CheckSelfPermission(act, permission);
                 //  if (check != PackageManager.PERMISSION_GRANTED)
                if (check != Permission.Granted)
                {
                    // 未开启该权限，则请求系统弹窗，好让用户选择是否立即开启权限
                    ActivityCompat.RequestPermissions(act, new String[] { permission }, requestCode);
                    result = false;
                }
            }
            return result;
        }
    }
}