using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "LoginMainActivity")]
    public class LoginMainActivity : Activity, IOnClickListener
    {
        public RadioGroup rg_login; // 声明一个单选组对象
        public RadioButton rb_password; // 声明一个单选按钮对象
        public RadioButton rb_verifycode; // 声明一个单选按钮对象
        public EditText et_phone; // 声明一个编辑框对象
        public TextView tv_password; // 声明一个文本视图对象
        public EditText et_password; // 声明一个编辑框对象
        public Button btn_forget; // 声明一个按钮控件对象
        public CheckBox ck_remember; // 声明一个复选框对象

        public int mRequestCode = 0; // 跳转页面时的请求代码
        public int mType = 0; // 用户类型
        public bool bRemember = false; // 是否记住密码
        public String mPassword = "111111"; // 默认密码
        public String mVerifyCode; // 验证码
        public object listener;

        public void OnClick(View v)
        {
            String phone = et_phone.Text;
           
         
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            rg_login = FindViewById<RadioGroup>(Resource.Id.rg_login);
            rb_password =FindViewById<RadioButton>(Resource.Id.rb_password);
            rb_verifycode = FindViewById<RadioButton>(Resource.Id.rb_verifycode);
            et_phone = FindViewById<EditText>(Resource.Id.et_phone);
            tv_password = FindViewById<TextView>(Resource.Id.tv_password);
            et_password = FindViewById<EditText>(Resource.Id.et_password);
            btn_forget = FindViewById<Button>(Resource.Id.btn_forget);
            ck_remember = FindViewById<CheckBox>(Resource.Id.ck_remember);
            // 给rg_login设置单选监听器
       //    rg_login.SetOnCheckedChangeListener(new RadioListener());
           rg_login.CheckedChange += Rg_login_CheckedChange;
        //    rg_login.SetOnCheckedChangeListener(new RadioGroup.IOnCheckedChangeListener )


            // 给ck_remember设置勾选监听器
         //  ck_remember.setOnCheckedChangeListener(new CheckListener());
           ck_remember.CheckedChange += Ck_remember_CheckedChange1;
            // 给et_phone添加文本变更监听器
         //   et_phone.addTextChangedListener(new HideTextWatcher(et_phone));
            et_phone.TextChanged += Et_phone_TextChanged;

            // 给et_password添加文本变更监听器
        //    et_password.addTextChangedListener(new HideTextWatcher(et_password));
            et_password.TextChanged += Et_password_TextChanged;
          //  btn_forget.setOnClickListener(this);
            btn_forget.SetOnClickListener(this);
          //  findViewById(R.id.btn_login).setOnClickListener(this);
            //initTypeSpinner();
            // Create your application here
        }

        private void Et_password_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
          
        }

        private void Et_phone_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
        }


        private void Ck_remember_CheckedChange1(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
          
                bRemember = e.IsChecked;
        
        }

       

        private void Rg_login_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            if (e.CheckedId == Resource.Id.rb_password)
            { // 选择了密码登录
                tv_password.Text="登录密码：";
                et_password.Hint="请输入密码";
                
                btn_forget.Text="忘记密码";
              //  ck_remember.setVisibility(View.VISIBLE);
                ck_remember.Visibility = ViewStates.Visible;
            }
            else if (e.CheckedId == Resource.Id.rb_verifycode)
            { // 选择了验证码登录
                tv_password.Text="　验证码：";
                et_password.Hint="请输入验证码";
                btn_forget.Text="获取验证码";
                ck_remember.Visibility= ViewStates.Invisible;
            }
        }

        //   private class RadioListener : Java.Lang.Object, RadioGroup.IOnCheckedChangeListener
      //public  class RadioListener : Java.Lang.Object, RadioGroup.IOnCheckedChangeListener
      //  {
      //      public void OnCheckedChanged(RadioGroup group, int checkedId)
      //      {
      //          if (group.Id == Resource.Id.rb_password)
      //          { // 选择了密码登录
      //              tv_password.Text = "登录密码：";
      //              et_password.Hint = "请输入密码";

      //              btn_forget.Text = "忘记密码";
      //              //  ck_remember.setVisibility(View.VISIBLE);
      //              ck_remember.Visibility = ViewStates.Visible;
      //          }
      //          else if (group.Id == Resource.Id.rb_verifycode)
      //          { // 选择了验证码登录
      //              tv_password.Text = "　验证码：";
      //              et_password.Hint = "请输入验证码";
      //              btn_forget.Text = "获取验证码";
      //              ck_remember.Visibility = ViewStates.Invisible;
      //          }
      //      }
      //  }
    }

 
}