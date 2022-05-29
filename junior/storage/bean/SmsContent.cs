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
   public class SmsContent
    {
        public String address;
        public String person;
        public String body;
        public String date;
        public int type;

        public SmsContent()
        {
            address = "";
            person = "";
            body = "";
            date = "";
            type = 0;
        }
    }
}