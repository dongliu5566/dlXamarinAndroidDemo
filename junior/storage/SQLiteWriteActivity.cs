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

namespace storage
{
    [Activity(Label = "SQLiteWriteActivity")]
    public class SQLiteWriteActivity : Activity
    {
      //  private UserDBHelper mHelper; // 声明一个用户数据库帮助器的对象
        private EditText et_name;
        private EditText et_age;
        private EditText et_height;
        private EditText et_weight;
       // private boolean bMarried = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}