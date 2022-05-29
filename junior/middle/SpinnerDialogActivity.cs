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
    [Activity(Label = "SpinnerDialogActivity")]
    public class SpinnerDialogActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_spinner_dialog);
            initSpinner();

            // Create your application here
        }

        private void initSpinner()
        {  // 声明一个下拉列表的数组适配器
            ArrayAdapter<String> starAdapter = new ArrayAdapter<String>(this,
                    Resource.Layout.item_select, starArray);
            // 设置数组适配器的布局样式
            starAdapter.SetDropDownViewResource(Resource.Layout.item_dropdown);
            // 从布局文件中获取名叫sp_dialog的下拉框
            Spinner sp = FindViewById<Spinner>(Resource.Id.sp_dialog);
            // 设置下拉框的标题
           // sp.setPrompt("请选择行星");
            sp.Prompt = "请选择行星";
            // 设置下拉框的数组适配器
           // sp.setAdapter(starAdapter);
            sp.Adapter = starAdapter;
            // 设置下拉框默认显示第一项
            sp.SetSelection(0);
            // 给下拉框设置选择监听器，一旦用户选中某一项，就触发监听器的onItemSelected方法
          //  sp.setOnItemSelectedListener(new MySelectedListener());
            sp.ItemSelected += (s, e) =>
            {
                Toast.MakeText(this, "您选择的是" + starArray[e.Id], ToastLength.Long).Show();
                // Toast.MakeText(this, "您选择的是" + e.Id.ToString(), ToastLength.Long).Show();
            };
        }

        private String[] starArray = { "水星", "金星", "地球", "火星", "木星", "土星" };
    }
}