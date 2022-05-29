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
   public class CallRecord
    {
        public String name;
        public String phone;
        public int type;
        public String date;
        public long duration;
        public int _new;

        public CallRecord()
        {
            name = "";
            phone = "";
            type = 0;
            date = "";
            duration = 0;
            _new = 0;
        }
    }
}