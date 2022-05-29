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
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "EditHideActivity")]
    public class EditHideActivity : Activity, IOnClickListener
    {
        private EditText et_other; // 声明一个编辑框对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.ll_hide)
            {
                // 实际上不只是et_other的软键盘会关闭，其它编辑框的软键盘也会关闭
                // 因为方法内部去获取视图的WindowToken，这个Token在每个页面上都是唯一的
              //  ViewUtil.hideOneInputMethod(EditHideActivity.this, et_other);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit_hide);
            // 从布局文件中获取名叫ll_hide的线性布局
            LinearLayout ll_hide = FindViewById<LinearLayout>(Resource.Id.ll_hide);
            // 从布局文件中获取名叫et_phone的手机号码编辑框
            EditText et_phone = FindViewById<EditText>(Resource.Id.et_phone);
            // 从布局文件中获取名叫et_password的密码编辑框
            EditText et_password = FindViewById<EditText>(Resource.Id.et_password);
            // 从布局文件中获取名叫et_other的其它编辑框
            et_other = FindViewById<EditText>(Resource.Id.et_other);
            ll_hide.SetOnClickListener(this);
            // 给手机号码编辑框添加文本变化监听器
         //   et_phone.addTextChangedListener(new HideTextWatcher(et_phone));
            // 给密码编辑框添加文本变化监听器
         //   et_password.addTextChangedListener(new HideTextWatcher(et_password));
            // Create your application here
        }
    }
}