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


namespace middle 
{
    [Activity(Label = "SpinnerIconActivity")]
    public class SpinnerIconActivity : Activity
    {

        /// <summary>
        /// 重要
        ///  JavaDictionary<String, Object> item = new JavaDictionary<String, Object>();
           // item.Add("icon", iconArray[i]);
            //    item.Add("name", starArray[i]);
               // item.Add(starArray[i], iconArray[i]);
             //   list.Add(item);
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_spinner_icon);
            initSpinnerForSimpleAdapter();

        }

        private void initSpinnerForSimpleAdapter()
        {
            // 声明一个映射对象的队列，用于保存行星的图标与名称配对信息
          //  List<Map<String, Object>> list = new ArrayList<Map<String, Object>>();
            IList<IDictionary<String, Object>> list = new List<IDictionary<String, Object>>();
         // List<string, object> list = new List<string, object>();
            // iconArray是行星的图标数组，starArray是行星的名称数组
            for (int i = 0; i < iconArray.Length; i++)
            {
                JavaDictionary<String, Object> item = new JavaDictionary<String, Object>();
                item.Add("icon", iconArray[i]);
                item.Add("name", starArray[i]);
               // item.Add(starArray[i], iconArray[i]);
                list.Add(item);
            }
            // 声明一个下拉列表的简单适配器，其中指定了图标与文本两组数据
            SimpleAdapter starAdapter = new SimpleAdapter(this, list,
                    Resource.Layout.item_simple, new String[] { "icon", "name" },
                    new int[] { Resource.Id.iv_icon, Resource.Id.tv_name });
            // 设置简单适配器的布局样式
            starAdapter.SetDropDownViewResource(Resource.Layout.item_simple);
            // 从布局文件中获取名叫sp_icon的下拉框
            Spinner sp = FindViewById<Spinner>(Resource.Id.sp_icon);
            // 设置下拉框的标题
            sp.Prompt="请选择行星";
            // 设置下拉框的简单适配器
          //  sp.SetAdapter(starAdapter);
            sp.Adapter = starAdapter;
            // 设置下拉框默认显示第一项
            sp.SetSelection(0);
            // 给下拉框设置选择监听器，一旦用户选中某一项，就触发监听器的onItemSelected方法

           // sp.setOnItemSelectedListener(new MySelectedListener());
            sp.ItemSelected += (s, e) =>
            {
                Toast.MakeText(this, "您选择的是" + starArray[e.Id], ToastLength.Long).Show();
                // Toast.MakeText(this, "您选择的是" + e.Id.ToString(), ToastLength.Long).Show();
            };
        }

        // 定义下拉列表需要显示的行星图标数组
        private int[] iconArray = {Resource.Drawable.shuixing, Resource.Drawable.jinxing, Resource.Drawable.diqiu,
            Resource.Drawable.huoxing, Resource.Drawable.muxing, Resource.Drawable.tuxing};
        // 定义下拉列表需要显示的行星名称数组
        private String[] starArray = { "水星", "金星", "地球", "火星", "木星", "土星" };
    }
}