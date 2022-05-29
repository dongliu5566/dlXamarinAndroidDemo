using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Annotation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using custom.util;
using JTypedValue=Android.Util.TypedValue;
namespace custom
{
    [Activity(Label = "MeasureTextActivity")]
  //  [SuppressLintAttribute(Value = "DefaultLocale")]
    public class MeasureTextActivity : Activity
    {
        private TextView tv_desc, tv_text;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_measure_text);
            tv_desc = FindViewById<TextView>(Resource.Id.tv_desc);
            tv_text = FindViewById<TextView>(Resource.Id.tv_text);
            initSizeSpinner();
            // Create your application here
        }

        private void initSizeSpinner()
        {
            ArrayAdapter<String> sizeAdapter = new ArrayAdapter<String>(this,
               Resource.Layout.item_select, descArray);
            Spinner sp_size = FindViewById<Spinner>(Resource.Id.sp_size);
            sp_size.Prompt="请选择文字大小";
            sp_size.Adapter=sizeAdapter;
            //  sp_size.setOnItemSelectedListener(new SizeSelectedListener());
            sp_size.ItemSelected += Sp_size_ItemSelected; ;
            sp_size.SetSelection(0);
        }

        private void Sp_size_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String text = tv_text.Text;
            int textSize = sizeArray[e.Id];
          //  tv_text.setTextSize(TypedValue.COMPLEX_UNIT_SP, textSize);
            tv_text.SetTextSize(JTypedValue.DataNullUndefined, textSize);
            // 计算获取指定文本的宽度（其实就是长度）
            int width = (int)MeasureUtil.getTextWidth(text, textSize);
            // 计算获取指定文本的高度
            int height = (int)MeasureUtil.getTextHeight(text, textSize);
            String desc = String.Format("下面文字的宽度是{0} ,高度是{1}", width, height);
            tv_desc.Text=desc;
        }

        private String[] descArray = { "12sp", "15sp", "17sp", "20sp", "22sp", "25sp", "27sp", "30sp" };
        private int[] sizeArray = { 12, 15, 17, 20, 22, 25, 27, 30 };
    }
}