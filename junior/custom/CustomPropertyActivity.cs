using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using custom.adapter;
using custom.bean;
using static Android.Support.V4.View.ViewPager;

namespace custom
{
    [Activity(Label = "CustomPropertyActivity")]
    public class CustomPropertyActivity : Activity ,IOnPageChangeListener
    {
        private  List<GoodsInfo> goodsList;
        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
           
        }

        public void OnPageScrollStateChanged(int state)
        {
            
        }

        public void OnPageSelected(int position)
        {
            Toast.MakeText(this, "您翻到的手机品牌是：" + goodsList[position].name, ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_property);
            goodsList = GoodsInfo.getDefaultList();
            // 构建一个商品图片的翻页适配器
            ImagePagerAdapater adapter = new ImagePagerAdapater(this, goodsList);
            // 从布局视图中获取名叫vp_content的翻页视图
            ViewPager vp_content = FindViewById<ViewPager>(Resource.Id.vp_content);
            // 给vp_content设置图片翻页适配器
            vp_content.Adapter=adapter;
            // 设置vp_content默认显示第一个页面
           // vp_content.setCurrentItem(0);
            vp_content.CurrentItem=0;
            // 给vp_content添加页面变化监听器
           vp_content.AddOnPageChangeListener(this);
            // Create your application here
        }
    }
}