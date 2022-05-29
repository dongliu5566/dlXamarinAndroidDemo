using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using storage.util;
using static Android.Views.View;

namespace storage
{
    [Activity(Label = "AppWriteActivity")]
    public class AppWriteActivity : Activity, IOnClickListener
    {
        private EditText et_name;
        private EditText et_age;
        private EditText et_height;
        private EditText et_weight;
        private bool bMarried = false;

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_save)
            {
                String name = et_name.Text;
                String age = et_age.Text;
                String height = et_height.Text;
                String weight = et_weight.Text;
                if (TextUtils.IsEmpty(name))
                {
                    showToast("请先填写姓名");
                    return;
                }
                else if (TextUtils.IsEmpty(age))
                {
                    showToast("请先填写年龄");
                    return;
                }
                else if (TextUtils.IsEmpty(height))
                {
                    showToast("请先填写身高");
                    return;
                }
                else if (TextUtils.IsEmpty(weight))
                {
                    showToast("请先填写体重");
                    return;
                }
                // 获取当前应用的Application实例
                MainApplication app = MainApplication.getInstance();
                // 以下直接修改Application实例中保存的映射全局变量
             //   app.mInfoMap.Add("name", name);
               // app.mInfoMap.Add("name", "1");
                app.mInfoMap.Add("age", age);
                app.mInfoMap.Add("height", height);
                app.mInfoMap.Add("weight", weight);
                app.mInfoMap.Add("married", typeArray[!bMarried ? 0 : 1]);
                app.mInfoMap.Add("update_time", DateUtil.getNowDateTime1());
                showToast("数据已写入全局内存");

            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_app_write);
            et_name = FindViewById<EditText>(Resource.Id.et_name);
            et_age = FindViewById<EditText>(Resource.Id.et_age);
            et_height = FindViewById<EditText>(Resource.Id.et_height);
            et_weight = FindViewById<EditText>(Resource.Id.et_weight);
            FindViewById<Button>(Resource.Id.btn_save).SetOnClickListener(this);
            initTypeSpinner();
            // Create your application here
        }
        private String[] typeArray = { "未婚", "已婚" };
        private void initTypeSpinner()
        {
            ArrayAdapter<String> typeAdapter = new ArrayAdapter<String>(this,
               Resource.Layout.item_select, typeArray);
            typeAdapter.SetDropDownViewResource(Resource.Layout.item_dropdown);
            Spinner sp_married = FindViewById<Spinner>(Resource.Id.sp_married);
            sp_married.Prompt="请选择婚姻状况";
            sp_married.Adapter=typeAdapter;
            sp_married.SetSelection(0);
           // sp_married.setOnItemSelectedListener(new TypeSelectedListener());
            sp_married.ItemSelected += Sp_married_ItemSelected;
        }

        private void Sp_married_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            bMarried = (e.Id == 0) ? false : true;
        }

        private void showToast(String desc)
        {
            Toast.MakeText(this, desc, ToastLength.Short).Show();
        }
    }
}