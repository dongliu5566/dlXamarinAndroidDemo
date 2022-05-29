using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "LoginForgetActivity")]
    public class LoginForgetActivity : AppCompatActivity, IOnClickListener
    {
        private EditText et_password_first; // 声明一个编辑框对象
        private EditText et_password_second; // 声明一个编辑框对象
        private EditText et_verifycode; // 声明一个编辑框对象
        private String mVerifyCode; // 验证码
        private String mPhone; // 手机号码

        public void OnClick(View v)
        {
           
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login_forget);
            // 从布局文件中获取名叫et_password_first的编辑框
            et_password_first = FindViewById<EditText>(Resource.Id.et_password_first);
            // 从布局文件中获取名叫et_password_second的编辑框
            et_password_second = FindViewById<EditText>(Resource.Id.et_password_second);
            // 从布局文件中获取名叫et_verifycode的编辑框
            et_verifycode = FindViewById<EditText>(Resource.Id.et_verifycode);
            FindViewById(Resource.Id.btn_verifycode).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_confirm).SetOnClickListener(this);
            // 从前一个页面获取要修改密码的手机号码
           // mPhone = getIntent().getStringExtra("phone");
            mPhone = Intent.GetStringExtra("phone");
            // Create your application here
        }
    }
}