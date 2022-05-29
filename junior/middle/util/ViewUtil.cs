using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace middle.util 
{
    public class ViewUtil
    {
        // 获取编辑框的最大长度，通过反射机制调用隐藏方法
        //public static int getMaxLength(EditText et)
        //{
        //    int length = 0;
        //    try
        //    {

        //        // InputFilter[] inputFilters = et.getFilters();
        //        IInputFilter[] inputFilters = et.GetFilters();
                  
        //        foreach (IInputFilter filter in inputFilters)
        //        {
        //            //  Class <?> c = filter.getClass();
        //               Type c=   filter.GetType();
        //          //     if (c.getName().equals("android.text.InputFilter$LengthFilter"))
        //                if (c.Name.Equals("android.text.InputFilter$LengthFilter"))
        //                {
        //                //    Field[] f = c.getDeclaredFields();
        //                PropertyInfo[] f = c.GetProperties();
        //                foreach (PropertyInfo field in f)
        //                {
        //                       // if (field.GetName().equals("mMax"))
        //                        if (field.GETN.equals("mMax"))
        //                        {
        //                        field.setAccessible(true);
        //                        length = (Integer)field.get(filter);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        e.printStackTrace();
        //    }
        //    return length;
        //}

        //public static void hideAllInputMethod(Activity act)
        //{
        //    // 从系统服务中获取输入法管理器
        //    InputMethodManager imm = (InputMethodManager)act.getSystemService(Context.INPUT_METHOD_SERVICE);
        //    if (imm.isActive())
        //    { // 软键盘如果已经打开则关闭之
        //        imm.toggleSoftInput(0, InputMethodManager.HIDE_NOT_ALWAYS);
        //    }
        //}

        //public static void hideOneInputMethod(Activity act, View v)
        //{
        //    // 从系统服务中获取输入法管理器
        //  //  InputMethodManager imm = (InputMethodManager)act.GetSystemService(Context.INPUT_METHOD_SERVICE);
        //  //  InputMethodManager imm = (InputMethodManager)act.GetSystemService(Context.INPUT_METHOD_SERVICE);
        //    // 关闭屏幕上的输入法软键盘
        //    // imm.hideSoftInputFromWindow(v.getWindowToken(), 0);
        //   // imm.HideSoftInputFromWindow(v.WindowToken, 0);
        //}
    }
}