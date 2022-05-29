using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using static Android.Graphics.Paint;
using static Android.Views.View;
using LayoutParams = Android.Widget.LinearLayout.LayoutParams;
namespace custom.util
{
   public  class MeasureUtil
    {
        // 获取指定文本的宽度（其实就是长度）
        public static float getTextWidth(String text, float textSize)
        {
            if (TextUtils.IsEmpty(text))
            {
                return 0;
            }
            Paint paint = new Paint(); // 创建一个画笔对象
            paint.TextSize=textSize; // 设置画笔的文本大小
            return paint.MeasureText(text); // 利用画笔丈量指定文本的宽度
        }

        // 获取指定文本的高度
        public static float getTextHeight(String text, float textSize)
        {
            Paint paint = new Paint(); // 创建一个画笔对象
            paint.TextSize=textSize; // 设置画笔的文本大小
            FontMetrics fm = paint.GetFontMetrics(); // 获取画笔默认字体的度量衡
            return fm.Descent - fm.Ascent; // 返回文本自身的高度
                                           //return fm.bottom - fm.top + fm.leading;  // 返回文本所在行的行高
        }

        // 根据资源编号获得线性布局的实际高度（页面来源）
        public static float getRealHeight(Activity act, int resid)
        {
            LinearLayout llayout = act.FindViewById<LinearLayout>(resid);
            return getRealHeight(llayout);
        }

        // 根据资源编号获得线性布局的实际高度（视图来源）
        public static float getRealHeight(View parent, int resid)
        {
            LinearLayout llayout = parent.FindViewById<LinearLayout>(resid);
            return getRealHeight(llayout);
        }

        // 计算指定线性布局的实际高度
        public static float getRealHeight(View child)
        {
            LinearLayout llayout = (LinearLayout)child;
            // 获得线性布局的布局参数  ??
            // LayoutParams params = llayout.getLayoutParams();
            //  Android.Widget.LinearLayout.LayoutParams params = new Android.Widget.LinearLayout.LayoutParams(,);
            //Android.Widget.LinearLayout.LayoutParams params = LinearLayout.LayoutParams(llayout);
            //  if (true) 
            //  {
            //  params = new LayoutParams(
            //         LayoutParams.MatchParent, LayoutParams.WrapContent);
            //  }
            // 获得布局参数里面的宽度规格
         //   int widthSpec = ViewGroup.GetChildMeasureSpec(0, 0, params.width);
            int widthSpec = ViewGroup.GetChildMeasureSpec(0, 0,800);
            int heightSpec;
            //if (800 > 0) { // 高度大于0，说明这是明确的dp数值
            //                         // 按照精确数值的情况计算高度规格
            //    heightSpec = MeasureSpec.MakeMeasureSpec(params.height, MeasureSpec.EXACTLY);
            //} else
            //{ // MATCH_PARENT=-1，WRAP_CONTENT=-2，所以二者都进入该分支
            //  // 按照不确定的情况计算高度规则
            //    heightSpec = MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED);
            //}
            //// 重新进行线性布局的宽高丈量
            //llayout.measure(widthSpec, heightSpec);
            // 获得并返回线性布局丈量之后的高度数值。调用getMeasuredWidth方法可获得宽度数值
            return llayout.MeasuredHeight;
           
        }

    }
}