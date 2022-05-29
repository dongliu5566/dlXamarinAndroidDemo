using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace custom.bean
{
  public  class AppInfo
    {
        public int uid;
        public String label;
        public String package_name;
        public Drawable icon;
        public long traffic;

        public long rowid;
        public int xuhao;
        public int month;
        public int day;
        public String icon_path;

        public AppInfo()
        {
            uid = 0;
            label = "";
            package_name = "";
            icon = null;
            traffic = 0;

            rowid = 0;
            xuhao = 0;
            month = 0;
            day = 0;
            icon_path = "";
        }

    }
}