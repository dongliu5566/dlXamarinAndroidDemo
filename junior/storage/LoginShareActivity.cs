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

namespace storage
{
    [Activity(Label = "LoginShareActivity")]
    public class LoginShareActivity : Activity, IOnClickListener
    {
        private RadioGroup rg_login;
        private RadioButton rb_password;
        private RadioButton rb_verifycode;
        private EditText et_phone;
        private TextView tv_password;
        private EditText et_password;
        private Button btn_forget;
        private CheckBox ck_remember;

        private int mRequestCode = 0; // 跳转页面时的请求代码
        private int mType = 0; // 用户类型
        private bool bRemember = false; // 是否记住密码
        private String mPassword = "111111"; // 默认密码
        private String mVerifyCode; // 验证码
        private ISharedPreferences mShared; // 声明一个共享参数对象

        public void OnClick(View v)
        {
            String phone = et_phone.Text;
            if (v.Id == Resource.Id.btn_forget)
            { // 点击了“忘记密码”按钮
                if (phone.Length < 11)
                { // 手机号码不足11位
                    Toast.MakeText(this, "请输入正确的手机号", ToastLength.Short).Show();
                    return;
                }
                if (rb_password.Checked)
                { // 选择了密码方式校验，此时要跳到找回密码页面
                    Intent intent = new Intent(this,typeof(LoginForgetActivity));
                // 携带手机号码跳转到找回密码页面
                intent.PutExtra("phone", phone);
                StartActivityForResult(intent, mRequestCode);
            } else if (rb_verifycode.Checked) { // 选择了验证码方式校验，此时要生成六位随机数字验证码
                                                // 生成六位随机数字的验证码
                                                //   mVerifyCode = String.format("%06d", (int)(Math.random() * 1000000 % 1000000));
                    Random random = new Random();
                    mVerifyCode = String.Format("{0}", (int) (random.Next(100000,900000)));
                // 弹出提醒对话框，提示用户六位验证码数字
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                  builder.SetTitle("请记住验证码");
                builder.SetMessage("手机号" + phone + "，本次验证码是" + mVerifyCode + "，请输入验证码");
                    //  builder.SetPositiveButton("好的", null);
                 //   builder.SetPositiveButton("", new EventHandler <DialogClickEventArgs > handler);
                AlertDialog alert = builder.Create();
                 alert.Show();
            }
        } else if (v.Id ==  Resource.Id.btn_login) { // 点击了“登录”按钮
            if (phone.Length < 11) { // 手机号码不足11位
                Toast.MakeText(this, "请输入正确的手机号",ToastLength.Short).Show();
                return;
}
            if (rb_password.Checked) { // 密码方式校验
                if (!et_password.Text.Equals(mPassword)) {
                    Toast.MakeText(this, "请输入正确的密码", ToastLength.Short).Show();
               } else { // 密码校验通过
                    LoginSuccess(); // 提示用户登录成功
                }
            } else if (rb_verifycode.Checked) { // 验证码方式校验
                if (!et_password.Text.Equals(mVerifyCode)) {
                    Toast.MakeText(this, "请输入正确的验证码", ToastLength.Short).Show();
             } else { // 验证码校验通过
                    LoginSuccess(); // 提示用户登录成功
                }
            }
        }
        }
        // 校验通过，登录成功
        private void LoginSuccess()
        {
            String desc = String.Format("您的手机号码是{0}，类型是{1}。恭喜你通过登录验证，点击“确定”按钮返回上个页面",
             et_phone.Text, typeArray[mType]);
            // 弹出提醒对话框，提示用户登录成功
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("登录成功");
            builder.SetMessage(desc);
            builder.SetPositiveButton("确定返回", HandlePositiveButtonClick);
            builder.SetNegativeButton("我再看看", HandelNegativeButtonClick);
            AlertDialog alert = builder.Create();
            alert.Show();

            if (bRemember)
            {
                // SharedPreferences.Editor editor = mShared.edit(); // 获得编辑器的对象
                ISharedPreferencesEditor editor = mShared.Edit(); // 获得编辑器的对象
                editor.PutString("phone", et_phone.Text); // 添加名叫phone的手机号码
                editor.PutString("password", et_password.Text); // 添加名叫password的密码
                editor.Commit(); // 提交编辑器中的修改
            }
        }

        private void HandelNegativeButtonClick(object sender, DialogClickEventArgs e)
        {
            Finish();
        }

        private void HandlePositiveButtonClick(object sender, DialogClickEventArgs e)
        {
            
        }

        private String[] typeArray = { "个人用户", "公司用户" };
        protected  override void OnRestart()
        {
            et_password.Text="";
            base.OnRestart();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login_share);
            rg_login = FindViewById<RadioGroup>(Resource.Id.rg_login);
            rb_password = FindViewById<RadioButton>(Resource.Id.rb_password);
            rb_verifycode = FindViewById<RadioButton>(Resource.Id.rb_verifycode);
            et_phone = FindViewById<EditText>(Resource.Id.et_phone);
            tv_password = FindViewById<TextView>(Resource.Id.tv_password);
            et_password = FindViewById<EditText>(Resource.Id.et_password);
            btn_forget = FindViewById<Button>(Resource.Id.btn_forget);
            ck_remember = FindViewById<CheckBox>(Resource.Id.ck_remember);
          //  rg_login.setOnCheckedChangeListener(new RadioListener());
            rg_login.CheckedChange += Rg_login_CheckedChange;
            //  ck_remember.setOnCheckedChangeListener(new CheckListener());
            ck_remember.CheckedChange += Ck_remember_CheckedChange;
          //  et_phone.addTextChangedListener(new HideTextWatcher(et_phone));
            et_phone.TextChanged += Et_phone_TextChanged;
           // et_password.addTextChangedListener(new HideTextWatcher(et_password));
            et_password.TextChanged += Et_password_TextChanged;
            btn_forget.SetOnClickListener(this);
            
            FindViewById<Button>(Resource.Id.btn_login).SetOnClickListener(this);
            initTypeSpinner();
            // 从share.xml中获取共享参数对象
            mShared = GetSharedPreferences("share_login",FileCreationMode.Private);
            // 获取共享参数中保存的手机号码
            String phone = mShared.GetString("phone", "");
            // 获取共享参数中保存的密码
            String password = mShared.GetString("password", "");
            et_phone.Text=phone; // 给手机号码编辑框填写上次保存的手机号
            et_password.Text=password; // 给密码编辑框填写上次保存的密码

        }

        private void initTypeSpinner()
        {
           
        }
        
        protected   void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
          
            if (requestCode == mRequestCode && data != null)
            {
                // 用户密码已改为新密码，故更新密码变量
                mPassword = data.GetStringExtra("new_password");
            }
        }
        private void Et_password_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
           
        }

        private void Et_phone_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
          
        }

        private void Ck_remember_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            
        }

        private void Rg_login_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
         
        }
    }
}