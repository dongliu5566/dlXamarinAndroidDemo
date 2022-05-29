using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using storage.bean;
using static Android.Database.Sqlite.SQLiteDatabase;

using Android.Content;
using System.Runtime.CompilerServices;
//using Android.Database.Sqlite.SQLiteDatabase;
//using Android.Database.Sqlite.SQLiteOpenHelper;

namespace storage.database
{

   public class CartDBHelper :  SQLiteOpenHelper
    {
       private static readonly  String TAG = "CartDBHelper";
      private static readonly String DB_NAME = "cart.db"; // 数据库的名称
        private static readonly int DB_VERSION = 1; // 数据库的版本号
        private static  CartDBHelper mHelper = null; // 数据库帮助器的实例
        private SQLiteDatabase mDB = null; // 数据库的实例
        private Context context;
        private int version;
        private static readonly  String TABLE_NAME = "cart_info"; // 表的名称
        

        // 重写三个构造方法
        public  CartDBHelper(Context context1, string name, SQLiteDatabase.ICursorFactory factory, int version):base(context1, DB_NAME,  factory, DB_VERSION)
        {
            context = context1;

        }
        // 重写三个构造方法
        private CartDBHelper(Context context1) : base(context1, DB_NAME, null, DB_VERSION)
        {
            context = context1;
        }
        // 重写三个构造方法
        private CartDBHelper(Context context1, int version) : base(context1, DB_NAME, null, DB_VERSION)
        {
            context = context1;
        }
     


        // public CartDBHelper(Context context,string DB_NAME ,object o,int DB_VERSION) : base(context, DB_NAME,null, DB_VERSION)
        //{
        //     // this.context = context;
        //     //   [Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Landroid/database/sqlite/SQLiteDatabase$CursorFactory;I)V", "")]
        //     SQLiteOpenHelper sQLiteOpenHelper = new SQLiteOpenHelper(context, DB_NAME, null, DB_VERSION);

        // //    SQLiteOpenHelper SQLiteOpenHelper  =new SQLiteOpenHelper(context, DB_NAME, null, DB_VERSION);
        // }

        //public  CartDBHelper(con)
        //{

        //}
        //private  CartDBHelper(Context context) : base(context)
        //{
        //   base:(context, DB_NAME, null, DB_VERSION);
        //}

        ////private CartDBHelper(Context context, int version)
        ////{
        ////    this:SQLiteOpenHelper(context, DB_NAME, null, version);
        ////}
        //// 利用单例模式获取数据库帮助器的唯一实例
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CartDBHelper getInstance(Context context, int version)
        {
            if (version > 0 && mHelper == null)
            {
                mHelper = new CartDBHelper(context, DB_NAME, null, version);
            }
            else if (mHelper == null)
            {
                mHelper = new CartDBHelper(context);
            }
            return mHelper;
        }
        // 打开数据库的读连接
        public SQLiteDatabase openReadLink()
        {
            if (mDB == null || !mDB.IsOpen)
            {
                // mDB = mHelper.getReadableDatabase();
                mDB = mHelper.ReadableDatabase;
            }
            return mDB;
        }

        // 打开数据库的写连接
        public SQLiteDatabase openWriteLink()
        {
            if (mDB == null || !mDB.IsOpen)
            {
                mDB = mHelper.WritableDatabase;
            }
            return mDB;
        }

        // 关闭数据库连接
        public void closeLink()
        {
            if (mDB != null && mDB.IsOpen)
            {
                mDB.Close();
                mDB = null;
            }
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            Log.Debug(TAG, "onCreate");
            String drop_sql = "DROP TABLE IF EXISTS " + TABLE_NAME + ";";
            Log.Debug(TAG, "drop_sql:" + drop_sql);
            db.ExecSQL(drop_sql);
            String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ("
                    + "_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"
                    + "goods_id LONG NOT NULL," + "count INTEGER NOT NULL,"
                    + "update_time VARCHAR NOT NULL"
                    + ");";
            Log.Debug(TAG, "create_sql:" + create_sql);
            db.ExecSQL(create_sql);

        }
        // 修改数据库，执行表结构变更语句
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
        
        }

        // 根据指定条件删除表记录
        public int delete(String condition)
        {
            // 执行删除记录动作，该语句返回删除记录的数目
            return mDB.Delete(TABLE_NAME, condition, null);
        }

        // 删除该表的所有记录
        public int deleteAll()
        {
            // 执行删除记录动作，该语句返回删除记录的数目
            return mDB.Delete(TABLE_NAME, "1=1", null);
        }
        // 往该表添加一条记录
        public long insert(CartInfo info)
        {
            List<CartInfo> infoArray = new List<CartInfo>();
            infoArray.Add(info);
            return insert(infoArray);
        }

        private long insert(List<CartInfo> infoArray)
        {
            long result = -1;
            foreach (CartInfo info in infoArray)
            {
                Log.Debug(TAG, "goods_id=" + info.goods_id + ", count=" + info.count);
                // 如果存在相同rowid的记录，则更新记录
                if (info.rowid > 0)
                {
                    String condition = String.Format("rowid='{0}'", info.rowid);
                  //  update(info, condition);
                    update(info, condition);
                    result = info.rowid;
                    continue;
                }
                // 不存在唯一性重复的记录，则插入新记录
                ContentValues cv = new ContentValues();
                cv.Put("goods_id", info.goods_id);
                cv.Put("count", info.count);
                cv.Put("update_time", info.update_time);
                // 执行插入记录动作，该语句返回插入记录的行号
                result = mDB.Insert(TABLE_NAME, "", cv);
                // 添加成功后返回行号，失败后返回-1
                if (result == -1)
                {
                    return result;
                }
            }
            return result;
        }

        // 根据条件更新指定的表记录
        public int update(CartInfo info, String condition)
        {
            ContentValues cv = new ContentValues();
            cv.Put("goods_id", info.goods_id);
            cv.Put("count", info.count);
            cv.Put("update_time", info.update_time);
            // 执行更新记录动作，该语句返回记录更新的数目
            return mDB.Update(TABLE_NAME, cv, condition, null);
        }

        public int update(CartInfo info)
        {
            // 执行更新记录动作，该语句返回记录更新的数目
            return update(info, "rowid=" + info.rowid);
        }
        // 根据指定条件查询记录，并返回结果数据队列
        public List<CartInfo> query(String condition)
        {
            String sql = String.Format("select rowid,_id,goods_id,count,update_time" +
                    " from {0} where {1};", TABLE_NAME, condition);
            Log.Debug(TAG, "query sql: " + sql);
            List<CartInfo> infoArray = new List<CartInfo>();
            // 执行记录查询动作，该语句返回结果集的游标
            ICursor cursor = mDB.RawQuery(sql, null);
           
            // 循环取出游标指向的每条记录
            while (cursor.MoveToNext())
            {
                CartInfo info = new CartInfo();
                info.rowid = cursor.GetLong(0);
                info.xuhao = cursor.GetInt(1);
                info.goods_id = cursor.GetLong(2);
                info.count = cursor.GetInt(3);
                info.update_time = cursor.GetString(4);
                infoArray.Add(info);
            }
            cursor.Close(); // 查询完毕，关闭游标
            return infoArray;
        }

        // 根据行号查询指定记录
        public CartInfo queryById(long rowid)
        {
            CartInfo info = null;
            List<CartInfo> infoArray = query(String.Format("rowid='{0}'", rowid));
            //if (infoArray.size() > 0)
            //{
            //    info = infoArray.get(0);
            //}
            if (infoArray.Count > 0)
            {
                info = infoArray.FirstOrDefault();
            }


            return info;
        }

        // 根据商品编号查询指定记录
        public CartInfo queryByGoodsId(long goods_id)
        {
            CartInfo info = null;
            List<CartInfo> infoArray = query(String.Format("goods_id='{0}'", goods_id));
            if (infoArray.Count > 0)
            {
                info = infoArray.FirstOrDefault();
            }
            return info;
        }
    }
}