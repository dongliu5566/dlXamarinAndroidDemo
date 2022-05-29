using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace storage.util 
{
    public class Utils
    {
        // 根据手机的分辨率从 dp 的单位 转成为 px(像素)
        public static int dip2px(Context context, float dpValue)
        {
            // 获取当前手机的像素密度
            // final float scale = context.GetResources().getDisplayMetrics().density;
               float scale = context.Resources.DisplayMetrics.Density;
            return (int)(dpValue * scale + 0.5f); // 四舍五入取整
        }

        // 根据手机的分辨率从 px(像素) 的单位 转成为 dp
        public static int px2dip(Context context, float pxValue)
        {
            // 获取当前手机的像素密度
          //  final float scale = context.getResources().getDisplayMetrics().density;
           float scale = context.Resources.DisplayMetrics.Density;
            return (int)(pxValue / scale + 0.5f); // 四舍五入取整
        }

        // 获得屏幕的宽度
        public static int getScreenWidth(Context ctx)
        {
            // 从系统服务中获取窗口管理器
            //  WindowManager wm = (WindowManager)ctx.getSystemService(Context.WINDOW_SERVICE);
            IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            DisplayMetrics dm = new DisplayMetrics();
            // 从默认显示器中获取显示参数保存到dm对象中
              wm.DefaultDisplay.GetMetrics(dm);
            return dm.WidthPixels; // 返回屏幕的宽度数值
          
        }

        // 获得屏幕的高度
        public static int getScreenHeight(Context ctx)
        {
            // 从系统服务中获取窗口管理器
            IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            DisplayMetrics dm = new DisplayMetrics();
            // 从默认显示器中获取显示参数保存到dm对象中
          //  wm.getDefaultDisplay().getMetrics(dm);
            wm.DefaultDisplay.GetMetrics(dm);
           return dm.HeightPixels; // 返回屏幕的高度数值
        }

        // 获得屏幕的像素密度
        public static float getScreenDensity(Context ctx)
        {
            // 从系统服务中获取窗口管理器
           // IWindowManager wm = (IWindowManager)ctx.getSystemService(Context.WINDOW_SERVICE);
            IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            DisplayMetrics dm = new DisplayMetrics();
            // 从默认显示器中获取显示参数保存到dm对象中
            //  wm.getDefaultDisplay().getMetrics(dm);
            wm.DefaultDisplay.GetMetrics(dm);
            // return dm.density; // 返回屏幕的像素密度数值
            return dm.Density;
        }
    }
}