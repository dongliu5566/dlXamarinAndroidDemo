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
    [Activity(Label = "EditAutoActivity")]
    public class EditAutoActivity : Activity
    {
        private string[] hintArray = { "第一", "第一次", "第一次写代码", "第一次领工资", "第二", "第二个" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit_auto);
            // 从布局文件中获取名叫ac_text的自动完成编辑框
            AutoCompleteTextView ac_text = FindViewById<AutoCompleteTextView>(Resource.Id.ac_text);
            // 声明一个自动完成时下拉展示的数组适配器
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(
                    this, Resource.Layout.item_dropdown, hintArray);
            ac_text.Adapter=adapter;
            // Create your application here
        }
    }
}