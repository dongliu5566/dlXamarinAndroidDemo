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

namespace junior
{
    [Activity(Label = "ScaleActivity")]
    public class ScaleActivity : Activity, View.IOnClickListener
    {
        private ImageView iv_scale; // 声明一个图像视图的对象
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_center)
            {
                // 将拉伸类型设置为“按照原尺寸居中显示”
                iv_scale.SetScaleType(ImageView.ScaleType.Center);
            }
            else if (v.Id == Resource.Id.btn_fitCenter)
            {
                // 将拉伸类型设置为“保持宽高比例，拉伸图片使其位于视图中间”
                iv_scale.SetScaleType(ImageView.ScaleType.FitCenter);
                // iv_scale.setScaleType(ImageView.ScaleType.FIT_CENTER);
            }
            else if (v.Id == Resource.Id.btn_centerCrop)
            {
                // 将拉伸类型设置为“拉伸图片使其充满视图，并位于视图中间”
                iv_scale.SetScaleType(ImageView.ScaleType.CenterCrop);
            }
            else if (v.Id == Resource.Id.btn_centerInside)
            {
                // 将拉伸类型设置为“保持宽高比例，缩小图片使之位于视图中间（只缩小不放大）”
                iv_scale.SetScaleType(ImageView.ScaleType.CenterInside);
            }
            else if (v.Id == Resource.Id.btn_fitXY)
            {
                // 将拉伸类型设置为“拉伸图片使其正好填满视图（图片可能被拉伸变形）”
                iv_scale.SetScaleType(ImageView.ScaleType.FitXy);
            }
            else if (v.Id == Resource.Id.btn_fitStart)
            {
                // 将拉伸类型设置为“保持宽高比例，拉伸图片使其位于视图上方或左侧”
                iv_scale.SetScaleType(ImageView.ScaleType.FitStart);
            }
            else if (v.Id == Resource.Id.btn_fitEnd)
            {
                // 将拉伸类型设置为“保持宽高比例，拉伸图片使其位于视图下方或右侧”
                iv_scale.SetScaleType(ImageView.ScaleType.FitEnd);
            }

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_scale);
            // Create your application here
            iv_scale = FindViewById<ImageView>(Resource.Id.iv_scale);

            FindViewById<Button>(Resource.Id.btn_center).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_fitCenter).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_centerCrop).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_centerInside).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_fitXY).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_fitStart).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.btn_fitEnd).SetOnClickListener(this);
        }
    }
}