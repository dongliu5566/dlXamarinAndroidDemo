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
using static Android.Views.View;

namespace middle 
{
    [Activity(Label = "EditJumpActivity")]
    public class EditJumpActivity : Activity , IOnClickListener
    {
       public  EditText et_username;
        public EditText et_password;
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_login)
            {
                Toast.MakeText(this, "这个登录按钮啥事也没做", ToastLength.Short).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit_jump);
            // 从布局文件中获取名叫et_username的用户名编辑框
            et_username = FindViewById<EditText>(Resource.Id.et_username);
            // 从布局文件中获取名叫et_password的密码编辑框
            et_password = FindViewById<EditText>(Resource.Id.et_password);
           Button btn_login = FindViewById<Button>(Resource.Id.btn_login);
            // 给用户名编辑框添加文本变化监听器
            //  et_username.addTextChangedListener(new JumpTextWatcher(et_username, et_password));
            et_username.TextChanged += Et_username_TextChanged;
            // 给密码编辑框添加文本变化监听器
            //et_password.addTextChangedListener(new JumpTextWatcher(et_password, btn_login));
            // 给密码编辑框添加编辑动作监听器
        
        btn_login.SetOnClickListener(this);
        // Create your application here
        }
        // 在编辑框的输入文本变化前触发
     

        // 在编辑框的输入文本变化时触发
      //  public void onTextChanged(CharSequence s, int start, int before, int count) { }

        // 在编辑框的输入文本变化后触发
        private void Et_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            String str = ((EditText)sender).Text;
            // 发现输入回车符或换行符
            //if (str.Contains("\r") || str.Contains("\n"))
            //{
            //    // 去掉回车符和换行符
            //    mThisView.setText(str.replace("\r", "").replace("\n", ""));
            //    if (mNextView != null)
            //    {
            //        // 让下一个视图获得焦点，即将光标移到下个视图
            //        mNextView.requestFocus();
            //        // 如果下一个视图是编辑框，则将光标自动移到编辑框的文本末尾
            //        if (mNextView instanceof EditText) {
            //            EditText et = (EditText)mNextView;
            //            // 让光标自动移到编辑框内部的文本末尾
            //            // 方式一：直接调用EditText的setSelection方法
            //            et.setSelection(et.getText().length());
            //            // 方式二：调用Selection类的setSelection方法
            //            //Editable edit = et.getText();
            //            //Selection.setSelection(edit, edit.length());
            //        }
            //    }
            //}
        }
    }
}