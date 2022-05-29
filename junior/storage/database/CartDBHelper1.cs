using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace storage.database
{
  public  class CartDBHelper1 : SQLiteOpenHelper
    {
        private static readonly String TAG = "CartDBHelper";
        private static readonly String DB_NAME = "cart.db"; // 数据库的名称
        private static readonly int DB_VERSION = 1; // 数据库的版本号
        private static CartDBHelper mHelper = null; // 数据库帮助器的实例
        private SQLiteDatabase mDB = null; // 数据库的实例
        private static readonly  String TABLE_NAME = "cart_info"; // 表的名称

        private Context context;
        private int version;
        private CartDBHelper1(Context context1, int version) : base(context1, DB_NAME, null, DB_VERSION)
        {
          //  super(context, DB_NAME, null, version);
        }

        public CartDBHelper1(Context context1, string name, SQLiteDatabase.ICursorFactory factory, int version) : base(context1, DB_NAME, factory, DB_VERSION)
        {
           
            context = context1;

        }
        public override void OnCreate(SQLiteDatabase db)
        {
           
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
           
        }
    }
}