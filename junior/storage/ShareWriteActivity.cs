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
    [Activity(Label = "ShareWriteActivity")]
    public class ShareWriteActivity : Activity,IOnClickListener
    {
        private ISharedPreferences mShared; // 声明一个共享参数对象
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

                //  ISharedPreferences.Editor editor = mShared.Edit(); // 获得编辑器的对象
                var editor = mShared.Edit(); // 获得编辑器的对象
              
                editor.PutString("name", name); // 添加一个名叫name的字符串参数
                editor.PutInt("age", int.Parse(age)); // 添加一个名叫age的整型参数
                editor.PutLong("height",long.Parse(height)); // 添加一个名叫height的长整型参数
                editor.PutFloat("weight", float.Parse(weight)); // 添加一个名叫weight的浮点数参数
                editor.PutBoolean("married", bMarried); // 添加一个名叫married的布尔型参数
                editor.PutString("update_time", DateUtil.getNowDateTime1());
                editor.Commit(); // 提交编辑器中的修改
                showToast("数据已写入共享参数");
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_share_write);
            et_name = FindViewById<EditText>(Resource.Id.et_name);
            et_age = FindViewById<EditText>(Resource.Id.et_age);
            et_height = FindViewById<EditText>(Resource.Id.et_height);
            et_weight = FindViewById<EditText>(Resource.Id.et_weight);
            FindViewById(Resource.Id.btn_save).SetOnClickListener(this);
            initTypeSpinner();
            // 从share.xml中获取共享参数对象
            //  mShared = getSharedPreferences("share", MODE_PRIVATE);
            mShared = GetSharedPreferences("share",FileCreationMode.Private);
        }

        private void initTypeSpinner()
        {
            ArrayAdapter<String> typeAdapter = new ArrayAdapter<String>(this,
                  Resource.Layout.item_select, typeArray);
            typeAdapter.SetDropDownViewResource(Resource.Layout.item_dropdown);
            Spinner sp_married = FindViewById<Spinner>(Resource.Id.sp_married);
            sp_married.Prompt="请选择婚姻状况";
            sp_married.Adapter=typeAdapter;
            sp_married.SetSelection(0);
            //  sp_married.setOnItemSelectedListener(new TypeSelectedListener());
           // sp_married.ItemSelected += Sp_married_ItemSelected;
            sp_married.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Sp_married_ItemSelected);
        }

        private void Sp_married_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            bMarried = (e.Id == 0) ? false : true;
        }

        private String[] typeArray = { "未婚", "已婚" };
        private void showToast(String desc)
        {
            // Toast.makeText(this, desc, Toast.LENGTH_SHORT).show();
            Toast.MakeText(this, desc, ToastLength.Short).Show();
        }

    }
}