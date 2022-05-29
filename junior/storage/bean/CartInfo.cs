using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace storage.bean
{
  public  class CartInfo
    {
        public long rowid;
        public int xuhao;
        public long goods_id;
        public int count;
        public String update_time;

        public CartInfo()
        {
            rowid = 0L;
            xuhao = 0;
            goods_id = 0L;
            count = 0;
            update_time = "";
        }
    }
}