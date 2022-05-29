using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using custom.bean;
//using String1[] = System.Collections.Generic.iList<String>

namespace custom.util
{
    public class AppUtil
    {
        // 获取已安装的应用信息队列
        public static List<AppInfo> getAppInfo(Context ctx, int type)
        {
             List<AppInfo> appList = new List<AppInfo>();
            SparseIntArray siArray = new SparseIntArray();
            // 获得应用包管理器
            PackageManager pm = ctx.PackageManager;
            PackageInfoFlags flags = new PackageInfoFlags();
            // 获取系统中已经安装的应用列表
            IList<ApplicationInfo> installList = pm.GetInstalledApplications(
                     
                      PackageInfoFlags.Permissions);
            for (int i = 0; i < installList.Count; i++)
            {
                ApplicationInfo item = installList[i];
                // 去掉重复的应用信息
            //    if (siArray.indexOfKey(item.uid) >= 0)
                if (siArray.IndexOfKey(item.Uid) >= 0)
                   {
                    continue;
                }
                // 往siArray中添加一个应用编号，以便后续的去重校验
                //  siArray.put(item.uid, 1);
                siArray.Put(item.Uid, 1);
                try
                {
                    // 获取该应用的权限列表
                   IList<String> permissions = pm.GetPackageInfo(item.PackageName,
                          //  PackageManager.GET_PERMISSIONS).requestedPermissions;
                          PackageInfoFlags.Permissions).RequestedPermissions;
               if (permissions == null)
                    {
                        continue;
                    }
                    bool isQueryNetwork = false;
                    foreach (String permission in permissions)
                    {
                        // 过滤那些具备上网权限的应用
                        if (permission.Equals("android.permission.INTERNET"))
                        {
                            isQueryNetwork = true;
                            break;
                        }
                    }
                    // 类型为0表示所有应用，为1表示只要联网应用
                    if (type == 0 || (type == 1 && isQueryNetwork))
                    {
                        AppInfo app = new AppInfo();
                        app.uid = item.Uid; // 获取应用的编号
                        app.label = item.LoadLabel(pm); // 获取应用的名称
                        app.package_name = item.PackageName; // 获取应用的包名
                        app.icon = item.LoadIcon(pm); // 获取应用的图标
                        appList.Add(app);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);  
                    continue;
                }
            }
            return appList;  // 返回去重后的应用包队列
        }

        // 填充应用的完整信息。主要做两个事情：其一是补充应用的图标字段，其二是将列表按照流量排序
        public static List<AppInfo> fillAppInfo(Context ctx, List<AppInfo> originArray)
        {
          //  List<AppInfo> fullArray = (List<AppInfo>)originArray.clone();
            List<AppInfo> fullArray = (List<AppInfo>)originArray;
           // PackageManager pm = ctx.getPackageManager();
            PackageManager pm = ctx.PackageManager;
            // 获取系统中已经安装的应用列表
         //   List<ApplicationInfo> installList = pm.GetInstalledApplications(PackageManager.PERMISSION_GRANTED);
            IList<ApplicationInfo> installList = pm.GetInstalledApplications(PackageInfoFlags.Permissions);
            for (int i = 0; i < fullArray.Count; i++)
            {
                AppInfo app = fullArray[i];
                foreach (ApplicationInfo item in installList)
                {
                    if (app.uid == item.Uid)
                    {
                        // 填充应用的图标信息。因为数据库没保存图标的位图，所以取出数据库记录之后还要补上图标数据
                        app.icon = item.LoadIcon(pm);
                        break;
                    }
                }
                //   fullArray.set(i, app);
                fullArray.Add(app);
            }
            // 各应用按照流量大小降序排列
        //    Collections.sort(fullArray, new Comparator<AppInfo>() {
        //    @Override
        //    public int compare(AppInfo o1, AppInfo o2)
        //    {
        //        return (o1.traffic < o2.traffic) ? 1 : -1;
        //    }
        //});
        return fullArray;
    }

}
}