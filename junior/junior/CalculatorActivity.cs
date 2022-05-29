using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace junior
{
    [Activity(Label = "CalculatorActivity")]
    public class CalculatorActivity : Activity, View.IOnClickListener
    {
        private  static String TAG = "CalculatorActivity";
        private TextView tv_result; // 声明一个文本视图对象
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_calculator);
            // Create your application here
            // 从布局文件中获取名叫tv_result的文本视图
            tv_result = FindViewById<TextView>(Resource.Id.tv_result);
            // 设置tv_result内部文本的移动方式为滚动形式
           // tv_result.setMovementMethod(new ScrollingMovementMethod());
            tv_result.MovementMethod= new ScrollingMovementMethod();
            // 下面给每个按钮控件都注册了点击监听器
            FindViewById(Resource.Id.btn_cancel).SetOnClickListener(this); // “取消”按钮
            FindViewById(Resource.Id.btn_divide).SetOnClickListener(this); // “除法”按钮
            FindViewById(Resource.Id.btn_multiply).SetOnClickListener(this); // “乘法”按钮
            FindViewById(Resource.Id.btn_clear).SetOnClickListener(this); // “清除”按钮
            FindViewById(Resource.Id.btn_seven).SetOnClickListener(this); // 数字7
            FindViewById(Resource.Id.btn_eight).SetOnClickListener(this); // 数字8
            FindViewById(Resource.Id.btn_nine).SetOnClickListener(this); // 数字9
            FindViewById(Resource.Id.btn_plus).SetOnClickListener(this); // “加法”按钮
            FindViewById(Resource.Id.btn_four).SetOnClickListener(this); // 数字4
            FindViewById(Resource.Id.btn_five).SetOnClickListener(this); // 数字5
            FindViewById(Resource.Id.btn_six).SetOnClickListener(this); // 数字6
            FindViewById(Resource.Id.btn_minus).SetOnClickListener(this); // “减法”按钮
            FindViewById(Resource.Id.btn_one).SetOnClickListener(this); // 数字1
            FindViewById(Resource.Id.btn_two).SetOnClickListener(this); // 数字2
            FindViewById(Resource.Id.btn_three).SetOnClickListener(this); // 数字3
            FindViewById(Resource.Id.btn_zero).SetOnClickListener(this); // 数字0
            FindViewById(Resource.Id.btn_dot).SetOnClickListener(this); // “小数点”按钮
            FindViewById(Resource.Id.btn_equal).SetOnClickListener(this); // “等号”按钮
            FindViewById(Resource.Id.ib_sqrt).SetOnClickListener(this); // “开平方”按钮
        }
        public void OnClick(View v)
        {
            int resid = v.Id; // 获得当前按钮的编号
            String inputText;
            if (resid == Resource.Id.ib_sqrt)
            { // 如果是开根号按钮
                inputText = "√";
            }
            else
            { // 除了开根号按钮之外的其它按钮
                inputText = ((TextView)v).Text;
            }
            Log.Debug(TAG, "resid=" + resid + ",inputText=" + inputText);
            if (resid == Resource.Id.btn_clear)
            { // 点击了清除按钮
                clear("");
            }
            else if (resid == Resource.Id.btn_cancel)
            { // 点击了取消按钮
                if (operator1.Equals("")) { // 无操作符，则表示逐位取消前一个操作数
                    if (firstNum.Length == 1)
                    {
                        firstNum = "0";
                    }
                    else if (firstNum.Length > 0)
                    {
                        firstNum = firstNum.Substring(0, firstNum.Length - 1);
                    }
                    else
                    {
                        Toast.MakeText(this, "没有可取消的数字了", ToastLength.Short).Show();
                        return;
                    }
                    showText = firstNum;
                    tv_result.Text=showText;
                } else
                { // 有操作符，则表示逐位取消后一个操作数
                    if (nextNum.Length == 1)
                    {
                        nextNum = "";
                    }
                    else if (nextNum.Length > 0)
                    {
                        nextNum = nextNum.Substring(0, nextNum.Length - 1);
                    }
                    else
                    {
                        Toast.MakeText(this, "没有可取消的数字了", ToastLength.Short).Show();
                        return;
                    }
                    showText = showText.Substring(0, showText.Length - 1);
                    tv_result.Text=showText;
                }
            }
            else if (resid == Resource.Id.btn_equal)
            { // 点击了等号按钮
                if (operator1.Length == 0 || operator1.Equals("＝")) {
                    Toast.MakeText(this, "请输入运算符", ToastLength.Short).Show();
                    return;
                } else if (nextNum.Length <= 0)
                {
                    Toast.MakeText(this, "请输入数字", ToastLength.Short).Show();
                    return;
                }
                if (caculate())
                { // 计算成功，则显示计算结果
                    operator1 = inputText;
                    showText = showText + "=" + result;
                    tv_result.Text=showText;
                }
                else
                { // 计算失败，则直接返回
                    return;
                }
            }
            else if (resid == Resource.Id.btn_plus || resid == Resource.Id.btn_minus // 点击了加、减、乘、除按钮
                  || resid == Resource.Id.btn_multiply || resid == Resource.Id.btn_divide)
            {
                if (firstNum.Length <= 0)
                {
                    Toast.MakeText(this, "请输入数字",ToastLength.Short).Show();
                    return;
                }
                if (operator1.Length == 0 || operator1.Equals("＝") || operator1.Equals("√")) {
                operator1 = inputText; // 操作符
                    showText = showText + operator1;
                    tv_result.Text=showText;
                } else
                {
                    Toast.MakeText(this, "请输入数字", ToastLength.Short).Show();
                    return;
                }
            }
            else if (resid == Resource.Id.ib_sqrt)
            { // 点击了开根号按钮
                if (firstNum.Length <= 0)
                {
                    Toast.MakeText(this, "请输入数字", ToastLength.Short).Show();
                    return;
                }
                if (Double.IsNaN(Convert.ToDouble(firstNum)))
                {
                    Toast.MakeText(this, "开根号的数值不能小于0", ToastLength.Short).Show();
                    return;
                }
                // 进行开根号运算
                //result = String.valueOf(Math.sqrt(Double.parseDouble(firstNum)));
                //firstNum = result;
                //nextNum = "";
                //   operato1r = inputText;
                //showText = showText + "√=" + result;
                //tv_result.setText(showText);
                Log.Debug(TAG, "result=" + result + ",firstNum=" + firstNum + ",operator=" + operator1);
            }
            else
            { // 点击了其它按钮，包括数字和小数点
                if (operator1.Equals("＝")) { // 上一次点击了等号按钮，则清空操作符
                    operator1 = "";
                    firstNum = "";
                    showText = "";
                }
                if (resid == Resource.Id.btn_dot)
                { // 点击了小数点
                    inputText = ".";
                }
                if (operator1.Equals("")) { // 无操作符，则继续拼接前一个操作数
                    if (firstNum.Contains(".") && inputText.Equals("."))
                    {
                        return; // 一个数字不能有两个小数点
                    }
                    firstNum = firstNum + inputText;
                } else
                { // 有操作符，则继续拼接后一个操作数
                    if (nextNum.Contains(".") && inputText.Equals("."))
                    {
                        return; // 一个数字不能有两个小数点
                    }
                    nextNum = nextNum + inputText;
                }
                showText = showText + inputText;
                tv_result.Text=showText;
            }
            return;
        }

        private string operator1="";
        private string firstNum = ""; // 前一个操作数
        private string nextNum = ""; // 后一个操作数
        private string result = ""; // 当前的计算结果
        private string showText = ""; // 显示的文本内容
                                      // 开始加减乘除四则运算，计算成功则返回true，计算失败则返回false
        private bool caculate()
        {
            if (operator1.Equals("＋")) { // 当前是相加运算
              //  result = String.valueOf(Arith.add(firstNum, nextNum));
                result = decimal.Add(Convert.ToDecimal(firstNum), Convert.ToDecimal(nextNum)).ToString();
            } else if (operator1.Equals("－")) { // 当前是相减运算
               // result = String.valueOf(Arith.sub(firstNum, nextNum));
                result = decimal.Subtract(Convert.ToDecimal(firstNum), Convert.ToDecimal(nextNum)).ToString();
            } else if (operator1.Equals("×")) { // 当前是相乘运算
              //  result = String.valueOf(Arith.mul(firstNum, nextNum));
                result = decimal.Multiply(Convert.ToDecimal(firstNum), Convert.ToDecimal(nextNum)).ToString();
            } else if (operator1.Equals("÷")) { // 当前是相除运算
             //   if (Double.parseDouble(nextNum) == 0)
                    if (Double.IsNaN(Convert.ToDouble(nextNum)))
                    { // 发现被除数是0
                  // 被除数为0，要弹窗提示用户
                    Toast.MakeText(this, "被除数不能为零", ToastLength.Short).Show();
                    // 返回false表示运算失败
                    return false;
                }
                else
                { // 被除数非0，则进行正常的除法运算
                 //   result = String.valueOf(Arith.div(firstNum, nextNum));
                    result = decimal.Divide(Convert.ToDecimal(firstNum), Convert.ToDecimal(nextNum)).ToString();
                }
            }
            // 把运算结果打印到日志中
            Log.Debug(TAG, "result=" + result);
            firstNum = result;
            nextNum = "";
            // 返回true表示运算成功
            return true;
        }
        private void clear(String text)
        {
            showText = text;
            tv_result.Text=showText;
            operator1 = "";
            firstNum = "";
            nextNum = "";
            result = "";
        }
    }
}