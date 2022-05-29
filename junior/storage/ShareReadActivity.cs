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
    [Activity(Label = "ShareReadActivity")]
    public class ShareReadActivity : Activity
    {
        private TextView tv_share;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_share_read);
            tv_share = FindViewById<TextView>(Resource.Id.tv_share);
            readSharedPreferences();
            // Create your application here
        }

        private void readSharedPreferences()
        {
            // 从share.xml中获取共享参数对象
            //  SharedPreferences shared = getSharedPreferences("share", MODE_PRIVATE);
            ISharedPreferences shared = GetSharedPreferences("share", FileCreationMode.Private);

            String desc = "共享参数中保存的信息如下：";
            // 获取共享参数中保存的所有映射配对信息
            // Map<String, Object> mapParam = (Map<String, Object>)shared.getAll();
            IDictionary<String, Object> mapParam = (IDictionary<String, Object>)shared.All;
            // 遍历该映射对象，并将配对信息形成描述文字
            foreach (KeyValuePair<string, Object> item_map in mapParam)
            {
                String key = item_map.Key; // 获取该配对的键信息
                Object value = item_map.Value; // 获取该配对的值信息
                                               //  if (value instanceof String) { // 如果配对值的类型为字符串
                if (value is string)
                { // 如果配对值的类型为字符串
                    desc = String.Format("{0}\n　{1}的取值为{1}", desc, key,
                       // shared.getString(key, ""));
                       shared.GetString(value.ToString(), ""));
                }
                else if (value is int)
                { // 如果配对值的类型为整型数
                    desc = String.Format("{0}\n　{1}的取值为{2}", desc, key,
                            shared.GetInt(key, 2));
                }
                else if (value is float)
                { // 如果配对值的类型为浮点数
                    desc = String.Format("{0}\n　{1}的取值为{2}", desc, key,
                            shared.GetFloat(key, 0.0f));
                }
                else if (value is bool)
                { // 如果配对值的类型为布尔数
                    desc = String.Format("{0}\n　{1}的取值为{2}", desc, key,
                            shared.GetBoolean(key, false));
                }
                else if (value is long)
                { // 如果配对值的类型为长整型
                    desc = String.Format("{0}\n　{1}的取值为{2}", desc, key,
                            shared.GetLong(key, 0L));
                }
                else
                { // 如果配对值的类型为未知类型
                    desc = String.Format("{0}\n参数{1}的取值为未知类型", desc, key);
                }
            }
            if (mapParam.Count <= 0)
            {
                desc = "共享参数中保存的信息为空";
            }
            tv_share.Text = desc;
        }
    }
    }
