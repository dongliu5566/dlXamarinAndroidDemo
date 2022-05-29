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
    [Activity(Label = "LoginForgetActivity")]
    public class LoginForgetActivity : Activity
    {
        private EditText et_password_first;
        private EditText et_password_second;
        private EditText et_verifycode;
        private String mVerifyCode; // 验证码
        private String mPhone; // 手机号码
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}