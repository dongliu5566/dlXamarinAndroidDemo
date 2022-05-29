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
using static Android.Widget.TextView;

namespace middle 
{
    [Activity(Label = "TextCheckActivity")]
    public class TextCheckActivity : Activity, IOnClickListener
    {
        private EditText et_input; // 声明一个编辑框对象
        private TextView tv_result; // 声明一个文本视图对象

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_empty)
            {
                // 判断字符串是否为空值
                bool isEmpty = TextUtils.IsEmpty(et_input.Text);
                String desc = String.Format("输入框的文本{0}空的", isEmpty ? "是" : "不是");
                tv_result.SetText(desc,BufferType.Normal);
            }
            else if (v.Id == Resource.Id.btn_trim_length)
            {
                // 获取字符串去除头尾空格之后的长度
              //  int length = TextUtils.getTrimmedLength(et_input.Text());
                int length = TextUtils.GetTrimmedLength(et_input.Text);
                String desc = String.Format("输入框的文本去掉左右空格后的长度是{0}", length);
                tv_result.SetText(desc, BufferType.Normal);
            }
            else if (v.Id == Resource.Id.btn_digit)
            {
                // 判断字符串是否全部由数字组成
                bool isDigit = TextUtils.IsDigitsOnly(et_input.Text);
                String desc = String.Format("输入框的文本{0}纯数字", isDigit ? "是" : "不是");
                tv_result.SetText(desc, BufferType.Normal);
            }
            else if (v.Id == Resource.Id.btn_ellipsize)
            {
                // 总共显示十个字符（因为省略号占了一个，所以还剩九个可显示汉字）
              //  float avail = et_input.getTextSize() * 10;
                float avail = et_input.TextSize * 10;
                // 如果字符串超过十位，则返回在尾部截断并添加省略号的字串
              //  CharSequence ellips = TextUtils.ellipsize(et_input.getText(), et_input.getPaint(), avail, TruncateAt.END);
                string  ellips = TextUtils.Ellipsize(et_input.Text, et_input.Paint, avail,TextUtils.TruncateAt.End);
                tv_result.SetText("输入框的文本加省略号的样式为：" + ellips, BufferType.Normal);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_text_check);
            // 从布局文件中获取名叫et_input的编辑框
            et_input = FindViewById<EditText>(Resource.Id.et_input);
            // 从布局文件中获取名叫tv_result的文本视图
            tv_result = FindViewById<TextView>(Resource.Id.tv_result);
            // 下面通过四个按钮分别演示TextUtils的四种常用方法
            FindViewById<Button>(Resource.Id.btn_empty).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_trim_length).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_digit).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_ellipsize).SetOnClickListener(this);
            // Create your application here
        }
    }
}