using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Text;
using Java.Util;

namespace storage.util 
{
    public class DateUtil
    {
        public static String getNowDateTime()
        {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");
            return sdf.Format(new Date());
        }

        public static String getNowDateTime1()
        {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            return sdf.Format(new Date());
        }

        public static String getNowTime()
        {
            SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
            return sdf.Format(new Date());
        }
    }
}