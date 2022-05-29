using System;
//using System1 = Java.Lang.JavaSystem;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Annotation;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using storage.bean;
using Uri1 = Android.Net.Uri;
using Android.Content.PM;
using Android.Support.V4.Content;
using Java.Lang;
using String = System.String;
//using Android.Content.PM;

namespace storage.util
{
    public   class CommunicationUtil
    {
        private readonly static System.String TAG = "CommunicationUtil";
   //     private static Uri mContactUri = ContactsContract.CommonDataKinds.Phone.CONTENT_URI;
        private static Android.Net.Uri mContactUri = ContactsContract.CommonDataKinds.Phone.ContentFilterUri;

        private static System.String[] mContactColumn = new System.String[]{
               ContactsContract.CommonDataKinds.Phone.Number,
               ContactsContract.CommonDataKinds.Phone.SearchDisplayNameKey,
        };

        // 读取手机保存的联系人数量
        public static int readPhoneContacts(ContentResolver resolver)
        {
            List<Contact> contactArray = new List<Contact>();
            ICursor cursor = resolver.Query(mContactUri, mContactColumn, null, null, null);
            while (cursor.MoveToNext())
            {
                Contact contact = new Contact();
                contact.phone = cursor.GetString(0).Replace("+86", "").Replace(" ", "");
                contact.name = cursor.GetString(1);
                Log.Debug(TAG, contact.name + " " + contact.phone);
                contactArray.Add(contact);
            }
            cursor.Close();
            return contactArray.Count;
        }

        // 往手机中添加一个联系人信息（包括姓名、电话号码、电子邮箱）
        public static void addContacts(ContentResolver resolver, Contact contact)
        {
            // 构建一个指向系统联系人提供器的Uri对象
         //   Android.Net.Uri  raw_uri = Uri.Parse("content://com.android.contacts/raw_contacts");
            Uri1 raw_uri = Uri1.Parse("content://com.android.contacts/raw_contacts");
            // 创建新的配对
            ContentValues values = new ContentValues();
            // 往 raw_contacts 中添加联系人记录，并获取添加后的联系人编号
            long contactId = ContentUris.ParseId(resolver.Insert(raw_uri, values));
            // 构建一个指向系统联系人数据的Uri对象
            Uri1 uri = Uri1.Parse("content://com.android.contacts/data");
            // 创建新的配对
            ContentValues name = new ContentValues();
            // 往配对中添加联系人编号
            name.Put("raw_contact_id", contactId);
            // 往配对中添加数据类型为“姓名”
            name.Put("mimetype", "vnd.android.cursor.item/name");
            // 往配对中添加联系人的姓名
            name.Put("data2", contact.name);
            // 往 data 中添加联系人的姓名
            resolver.Insert(uri, name);
            // 创建新的配对
            ContentValues phone = new ContentValues();
            // 往配对中添加联系人编号
            phone.Put("raw_contact_id", contactId);
            // 往配对中添加数据类型为“电话号码”
            phone.Put("mimetype", "vnd.android.cursor.item/phone_v2");
            phone.Put("data2", "2");
            // 往配对中添加联系人的电话号码
            phone.Put("data1", contact.phone);
            // 往 data 中添加联系人的电话号码
            resolver.Insert(uri, phone);
            // 创建新的配对
            ContentValues email = new ContentValues();
            // 往配对中添加联系人编号
            email.Put("raw_contact_id", contactId);
            // 往配对中添加数据类型为“电子邮箱”
            email.Put("mimetype", "vnd.android.cursor.item/email_v2");
            email.Put("data2", "2");
            // 往配对中添加联系人的电子邮箱
            email.Put("data1", contact.email);
            // 往 data 中添加联系人的电子邮箱
            resolver.Insert(uri, email);
        }


        // 往手机中一次性添加一个联系人信息（包括主记录、姓名、电话号码、电子邮箱）
        public static void addFullContacts(ContentResolver resolver, Contact contact)
        {
            // 构建一个指向系统联系人提供器的Uri对象
            Uri1 raw_uri = Uri1.Parse("content://com.android.contacts/raw_contacts");
            // 构建一个指向系统联系人数据的Uri对象
            Uri1 uri = Uri1.Parse("content://com.android.contacts/data");
            // 创建一个插入联系人主记录的内容操作器
            ContentProviderOperation op_main = ContentProviderOperation
                    .NewInsert(raw_uri).WithValue("account_name", null).Build();
            // 创建一个插入联系人姓名记录的内容操作器
            ContentProviderOperation op_name = ContentProviderOperation
                    .NewInsert(uri).WithValueBackReference("raw_contact_id", 0)
                    .WithValue("mimetype", "vnd.android.cursor.item/name")
                    .WithValue("data2", contact.name).Build();
            // 创建一个插入联系人电话号码记录的内容操作器
            ContentProviderOperation op_phone = ContentProviderOperation
                    .NewInsert(uri).WithValueBackReference("raw_contact_id", 0)
                    .WithValue("mimetype", "vnd.android.cursor.item/phone_v2")
                    .WithValue("data2", "2").WithValue("data1", contact.phone).Build();
            // 创建一个插入联系人电子邮箱记录的内容操作器
            ContentProviderOperation op_email = ContentProviderOperation
                    .NewInsert(uri).WithValueBackReference("raw_contact_id", 0)
                    .WithValue("mimetype", "vnd.android.cursor.item/email_v2")
                    .WithValue("data2", "2").WithValue("data1", contact.email).Build();
            // 声明一个内容操作器的队列，并将上面四个操作器添加到该队列中
            List<ContentProviderOperation> operations = new List<ContentProviderOperation>();
            operations.Add(op_main);
            operations.Add(op_name);
            operations.Add(op_phone);
            operations.Add(op_email);
            try
            {
                // 批量提交四个内容操作器所做的修改
                resolver.ApplyBatch("com.android.contacts", operations);
            }
            catch (Java.Lang.Exception e)
            {
                //  e.printStackTrace();
                Console.WriteLine(e.StackTrace) ;
            }
        }


        //private static Uri mSmsUri = Uri.parse("content://sms"); //该地址表示所有短信，包括收件箱和发件箱
        //private static Uri mSmsUri = Uri.parse("content://sms/inbox"); //该地址为收件箱

        private static Uri1 mSmsUri;
        private static System.String[] mSmsColumn;

        // 读取指定号码发来的短信记录
        //@TargetApi(Build.VERSION_CODES.KITKAT)   @TargetApi(Build.VERSION_CODES.KITKAT)  =[TargetApi(Value=(int))]

        [TargetApi(Value = (int)BuildVersionCodes.Kitkat)]
        public static int readSms(ContentResolver resolver, System.String phone, int gaps)
        {
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Kitkat)
            {
                mSmsUri = Telephony.Sms.Inbox.ContentUri;
            }
            else
            {
                mSmsUri = Uri1.Parse("content://sms/inbox");
            }
            mSmsColumn = new System.String[]{
                  Telephony.Sms.InterfaceConsts.Address, Telephony.Sms.InterfaceConsts.Person,
                  Telephony.Sms.InterfaceConsts.Body, Telephony.Sms.InterfaceConsts.Date,
                  Telephony.Sms.InterfaceConsts.Type
               
                  };
             List<SmsContent> smsArray = new  List<SmsContent>();
            System.String selection = "";
            if (phone != null && phone.Length > 0)
            {
                selection = System.String.Format("address='{0}'", phone);
            }
            if (gaps > 0)
            {
                selection = System.String.Format("{0}{1}date>{2}", selection,
                        (selection.Length > 0) ? " and " : "", Java.Lang.JavaSystem.CurrentTimeMillis() - gaps * 1000);
            }
            ICursor cursor = resolver.Query(mSmsUri, mSmsColumn, selection, null, "date desc");
            while (cursor.MoveToNext())
            {
                SmsContent sms = new SmsContent();
                sms.address = cursor.GetString(0);
                sms.person = cursor.GetString(1);
                sms.body = cursor.GetString(2);
                //sms.date = DateUtil.FormatDate(cursor.GetLong(3));
                sms.date = cursor.GetLong(3).ToString();
                sms.type = cursor.GetInt(4);  //type=1表示收到的短信，type=2表示发送的短信
                Log.Debug(TAG, sms.address + " " + sms.person + " " + sms.date + " " + sms.type + " " + sms.body);
                smsArray.Add(sms);
            }
            cursor.Close();
            return smsArray.Count;
        }

        private static Uri1 mRecordUri = CallLog.Calls.ContentUri;
        private static System.String[] mRecordColumn = new System.String[]{
        
               CallLog.Calls.CachedName, CallLog.Calls.Number, CallLog.Calls.Type,
            CallLog.Calls.Date, CallLog.Calls.Duration, CallLog.Calls.New};

        // 读取规定时间内的通话记录
        public static int readCallRecord(ContentResolver resolver, int gaps)
        {
          
             List<CallRecord> recordArray = new List<CallRecord>();
            // String selection = String.format("date>%d", System.currentTimeMillis() - gaps * 1000);
            //    Cursor cursor = resolver.query(mRecordUri, mRecordColumn, selection, null, "date desc");
            System.String selection = System.String.Format("date>{0}", ( Java.Lang.JavaSystem.CurrentTimeMillis() - gaps * 1000));
            ICursor cursor = resolver.Query(mRecordUri, mRecordColumn, selection, null, "date desc");
            while (cursor.MoveToNext())
            {
                CallRecord record = new CallRecord();
                record.name = cursor.GetString(0);
                record.phone = cursor.GetString(1);
                record.type = cursor.GetInt(2);  //type=1表示接听，2表示拨出，3表示未接
               // record.date = DateUtil.FormatDate(cursor.GetLong(3));
                record.date = cursor.GetLong(3).ToString();
                record.duration = cursor.GetLong(4);
                record._new = cursor.GetInt(5);
                Log.Debug(TAG, record.name + " " + record.phone + " " + record.type + " " + record.date + " " + record.duration);
                recordArray.Add(record);
            }
            cursor.Close();
            return recordArray.Count;
        }

        //// 读取所有的联系人信息
        public static System.String readAllContacts(ContentResolver resolver)
        {
            List<Contact> contactArray = new List<Contact>();
            ICursor cursor = resolver.Query(
                     //   ContactsContract.Contacts.CONTENT_URI, null, null, null, null);
                     ContactsContract.Contacts.ContentUri, null, null, null, null);
            int contactIdIndex = 0;
            int nameIndex = 0;

            if (cursor.Count > 0)
            {
                //  contactIdIndex = cursor.getColumnIndex(ContactsContract.Contacts._ID);
                //  nameIndex = cursor.getColumnIndex(ContactsContract.Contacts.DISPLAY_NAME);
                contactIdIndex = cursor.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id);
                nameIndex = cursor.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName);
            }
            while (cursor.MoveToNext())
            {
                Contact contact = new Contact();
                contact.contactId = cursor.GetString(contactIdIndex);
                contact.name = cursor.GetString(nameIndex);
                contactArray.Add(contact);
            }
            cursor.Close();

            for (int i = 0; i < contactArray.Count; i++)
            {
                Contact contact = contactArray[i];
                contact.phone = getColumn(resolver, contact.contactId,
                          //   ContactsContract.CommonDataKinds.Phone.CONTENT_URI,
                          //    ContactsContract.CommonDataKinds.Phone.CONTACT_ID,
                          //   ContactsContract.CommonDataKinds.Phone.NUMBER
                          ContactsContract.CommonDataKinds.Phone.ContentUri,
                         ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Id,
                        ContactsContract.CommonDataKinds.Phone.Number);
                contact.email = getColumn(resolver, contact.contactId,
                        //ContactsContract.CommonDataKinds.Email.CONTENT_URI,
                        //ContactsContract.CommonDataKinds.Email.CONTACT_ID,
                        //ContactsContract.CommonDataKinds.Email.DATA);
                        ContactsContract.CommonDataKinds.Email.ContentUri,
                        ContactsContract.CommonDataKinds.Email.InterfaceConsts.Id,
                        ContactsContract.CommonDataKinds.Email.InterfaceConsts.Data);
                //     contactArray.Set(i, contact);
                contactArray.Add(contact);
                Log.Debug(TAG, contact.contactId + " " + contact.name + " " + contact.phone + " " + contact.email);
            }
            string result = "";
            foreach (Contact contact in contactArray)
            {
                result = string.Format("{0}{1}	{2}	{3}\n", result, contact.name, contact.phone, contact.email);
            }
            return result;
        }


        private static String getColumn(ContentResolver resolver, String contactId,
                                   Uri1 uri, String selection, String column)
        {
            ICursor cursor = resolver.Query(uri, null, selection + "=" + contactId, null, null);
            int index = 0;
            if (cursor.Count > 0)
            {
                index = cursor.GetColumnIndex(column);
            }
            String value = "";
            while (cursor.MoveToNext())
            {
                value = cursor.GetString(index);
            }
            cursor.Close();
            return value;
        }



        //// 检查多个权限。返回true表示已完全启用权限，返回false表示未完全启用权限
        //public static bool checkMultiPermission(Activity act, String[] permissions, int requestCode)
        //{
        //    bool result = true;
        //    if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M)
        //    {
        //        int check = PackageManager.PERMISSION_GRANTED;
        //        int check = PackageManager.;
        //        // 通过权限数组检查是否都开启了这些权限
        //        foreach (String permission in permissions)
        //        {
        //            check = (int)ContextCompat.CheckSelfPermission(act, permission);
        //            if (check != PackageManager.PERMISSION_GRANTED)
        //            {
        //                break;
        //            }
        //        }
        //        if (check != PackageManager.PERMISSION_GRANTED)
        //        {
        //            // 未开启该权限，则请求系统弹窗，好让用户选择是否立即开启权限
        //            ActivityCompat.requestPermissions(act, permissions, requestCode);
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        //// 检查是否允许修改系统设置
        //public static bool checkWriteSettings(Activity act, int requestCode)
        //{
        //    Log.Debug(TAG, "checkWriteSettings:");
        //    bool result = true;
        //    // 只对Android6.0及Android7.0系统进行校验
        //    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M
        //            && Build.VERSION.SDK_INT < Build.VERSION_CODES.O)
        //    {
        //        // 检查当前App是否允许修改系统设置
        //        if (!Settings.System.canWrite(act))
        //        {
        //            Intent intent = new Intent(Settings.ACTION_MANAGE_WRITE_SETTINGS,
        //                    Uri.parse("package:" + act.getPackageName()));
        //            act.startActivityForResult(intent, requestCode);
        //            Toast.makeText(act, "需要允许设置权限才能调节亮度噢", Toast.LENGTH_SHORT).show();
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        public static void goActivity(Context ctx, Class cls)
        {
            Intent intent = new Intent(ctx, cls);
            ctx.StartActivity(intent);
        }


    }
}