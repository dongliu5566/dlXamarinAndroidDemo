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

namespace storage.database
{
    public class UserDBHelper : SQLiteOpenHelper
    {
        /// <summary>
        /// final对应const. // 如果不是静态并且不是编译时的,对应的是readonly关键字// const是编译时只读,在编译时决定类型和值,编译后就不能改变的.
        /// //readonly是运行时只读,在运行时赋值,比如读取配置文件之类的,如果是const类型就不可以了.
        /// </summary>
        private static readonly String TAG = "UserDBHelper";
        private static readonly String DB_NAME = "user.db"; // 数据库的名称
        private static readonly int DB_VERSION = 1; // 数据库的版本号
        private static UserDBHelper mHelper = null; // 数据库帮助器的实例
        private SQLiteDatabase mDB = null; // 数据库的实例
        public static readonly String TABLE_NAME = "user_info"; // 表的名称
        private Context context;
        private UserDBHelper(Context context1, string name, SQLiteDatabase.ICursorFactory factory, int version) : base(context1, name, factory, version)
        {
            context = context1;
        }


        private UserDBHelper(Context context1) : base(context1, DB_NAME, null, DB_VERSION)
        {
            context = context1;
            //  super(context, DB_NAME, null, DB_VERSION);
        }

        private UserDBHelper(Context context1, int version) : base(context1, DB_NAME, null, DB_VERSION)
        {
            context = context1;
        }

        // 利用单例模式获取数据库帮助器的唯一实例
        public static UserDBHelper getInstance(Context context, int version)
        {
            if (version > 0 && mHelper == null)
            {
                mHelper = new UserDBHelper(context, version);
            }
            else if (mHelper == null)
            {
                mHelper = new UserDBHelper(context);
            }
            return mHelper;
        }

        // 打开数据库的读连接
        public SQLiteDatabase openReadLink()
        {
            if (mDB == null || !mDB.IsOpen)
            {
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
        // 创建数据库，执行建表语句
        public void onCreate(SQLiteDatabase db)
        {
            Log.Debug(TAG, "onCreate");
            String drop_sql = "DROP TABLE IF EXISTS " + TABLE_NAME + ";";
            Log.Debug(TAG, "drop_sql:" + drop_sql);
            db.ExecSQL(drop_sql);
            String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ("
                    + "_id INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL,"
                    + "name VARCHAR NOT NULL," + "age INTEGER NOT NULL,"
                    + "height LONG NOT NULL," + "weight FLOAT NOT NULL,"
                    + "married INTEGER NOT NULL," + "update_time VARCHAR NOT NULL"
                    //演示数据库升级时要先把下面这行注释
                    + ",phone VARCHAR" + ",password VARCHAR"
                    + ");";
            Log.Debug(TAG, "create_sql:" + create_sql);
            db.ExecSQL(create_sql);
        }

        // 修改数据库，执行表结构变更语句
        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            Log.Debug(TAG, "onUpgrade oldVersion=" + oldVersion + ", newVersion=" + newVersion);
            if (newVersion > 1)
            {
                //Android的ALTER命令不支持一次添加多列，只能分多次添加
                String alter_sql = "ALTER TABLE " + TABLE_NAME + " ADD COLUMN " + "phone VARCHAR;";
                Log.Debug(TAG, "alter_sql:" + alter_sql);
                db.ExecSQL(alter_sql);
                alter_sql = "ALTER TABLE " + TABLE_NAME + " ADD COLUMN " + "password VARCHAR;";
                Log.Debug(TAG, "alter_sql:" + alter_sql);
                db.ExecSQL(alter_sql);
            }
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
        public long insert(UserInfo info)
        {
           List<UserInfo> infoArray = new List<UserInfo>();
            infoArray.Add(info);
            return insert(infoArray);
        }

        // 往该表添加多条记录
        public long insert(List<UserInfo> infoArray)
        {
            long result = -1;
            for (int i = 0; i < infoArray.Count; i++)
            {
                UserInfo info = infoArray[i];
                List<UserInfo> tempArray = new List<UserInfo>();
                // 如果存在同名记录，则更新记录
                // 注意条件语句的等号后面要用单引号括起来
                if (info.name != null && info.name.Length > 0)
                {
                    String condition = String.Format("name='{0}'", info.name);
                    tempArray = query(condition);
                    if (tempArray.Count > 0)
                    {
                        update(info, condition);
                        result = tempArray.FirstOrDefault().rowid;
                        continue;
                    }
                }
                // 如果存在同样的手机号码，则更新记录
                if (info.phone != null && info.phone.Length > 0)
                {
                    String condition = String.Format("phone='{0}'", info.phone);
                    tempArray = query(condition);
                    if (tempArray.Count > 0)
                    {
                        update(info, condition);
                        result = tempArray.FirstOrDefault().rowid;
                        continue;
                    }
                }
                // 不存在唯一性重复的记录，则插入新记录
                ContentValues cv = new ContentValues();
                cv.Put("name", info.name);
                cv.Put("age", info.age);
                cv.Put("height", info.height);
                cv.Put("weight", info.weight);
                cv.Put("married", info.married);
                cv.Put("update_time", info.update_time);
                cv.Put("phone", info.phone);
                cv.Put("password", info.password);
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
        public int update(UserInfo info, String condition)
        {
            ContentValues cv = new ContentValues();
            cv.Put("name", info.name);
            cv.Put("age", info.age);
            cv.Put("height", info.height);
            cv.Put("weight", info.weight);
            cv.Put("married", info.married);
            cv.Put("update_time", info.update_time);
            cv.Put("phone", info.phone);
            cv.Put("password", info.password);
            // 执行更新记录动作，该语句返回记录更新的数目
            return mDB.Update(TABLE_NAME, cv, condition, null);
        }

        public int update(UserInfo info)
        {
            // 执行更新记录动作，该语句返回记录更新的数目
            return update(info, "rowid=" + info.rowid);
        }
        // 根据指定条件查询记录，并返回结果数据队列
        public List<UserInfo> query(String condition)
        {
            String sql = String.Format("select rowid,_id,name,age,height,weight,married,update_time," +
                    "phone,password from {0} where {1};", TABLE_NAME, condition);
            Log.Debug(TAG, "query sql: " + sql);
            List<UserInfo> infoArray = new List<UserInfo>();
            // 执行记录查询动作，该语句返回结果集的游标
            ICursor cursor = mDB.RawQuery(sql, null);
            // 循环取出游标指向的每条记录
            while (cursor.MoveToNext())
            {
                UserInfo info = new UserInfo();
                info.rowid = cursor.GetLong(0); // 取出长整型数
                info.xuhao = cursor.GetInt(1); // 取出整型数
                info.name = cursor.GetString(2); // 取出字符串
                info.age = cursor.GetInt(3);
                info.height = cursor.GetLong(4);
                info.weight = cursor.GetFloat(5); // 取出浮点数
                                                  //SQLite没有布尔型，用0表示false，用1表示true
                info.married = (cursor.GetInt(6) == 0) ? false : true;
                info.update_time = cursor.GetString(7);
                info.phone = cursor.GetString(8);
                info.password = cursor.GetString(9);
                infoArray.Add(info);
            }
            cursor.Close(); // 查询完毕，关闭游标
            return infoArray;
        }

        // 根据手机号码查询指定记录
        public UserInfo queryByPhone(String phone)
        {
            UserInfo info = null;
            List<UserInfo> infoArray = query(String.Format("phone='%s'", phone));
            if (infoArray.Count > 0)
            {
                info = infoArray.FirstOrDefault();
            }
            return info;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            Log.Debug(TAG, "onCreate");
            String drop_sql = "DROP TABLE IF EXISTS " + TABLE_NAME + ";";
            Log.Debug(TAG, "drop_sql:" + drop_sql);
            db.ExecSQL(drop_sql);
            String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ("
                    + "_id INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL,"
                    + "name VARCHAR NOT NULL," + "age INTEGER NOT NULL,"
                    + "height LONG NOT NULL," + "weight FLOAT NOT NULL,"
                    + "married INTEGER NOT NULL," + "update_time VARCHAR NOT NULL"
                    //演示数据库升级时要先把下面这行注释
                    + ",phone VARCHAR" + ",password VARCHAR"
                    + ");";
            Log.Debug(TAG, "create_sql:" + create_sql);
            db.ExecSQL(create_sql);

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
           
        }
    }
}