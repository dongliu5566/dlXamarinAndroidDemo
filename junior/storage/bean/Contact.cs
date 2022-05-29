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
//using String = Java.Lang.String;

namespace storage.bean
{
   public class Contact
    {
        public String contactId;
        public String name;
        public String phone;
        public String email;

        public Contact()
        {
            contactId = "";
            name = "";
            phone = "";
            email = "";

        }
    }
}