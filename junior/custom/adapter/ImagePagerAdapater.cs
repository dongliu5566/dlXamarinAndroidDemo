using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JObject = Java.Lang.Object;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;

using Android.Widget;
using custom.bean;
using Android.Views;

namespace custom.adapter
{
    public class ImagePagerAdapater : PagerAdapter
    {
        private Context mContext; // 声明一个上下文对象
                                  // 声明一个图像视图队列
        private List<ImageView> mViewList = new List<ImageView>();
        // 声明一个商品信息队列
        private List<GoodsInfo> mGoodsList = new List<GoodsInfo>();
        private CustomPropertyActivity customPropertyActivity;
        private List<GoodsInfo> goodsList;

        public ImagePagerAdapater(CustomPropertyActivity context, List<GoodsInfo> goodsList)
        {
            mContext = context;
            mGoodsList = goodsList;
           
        }

        public override int Count => mViewList.Count;

        public override bool IsViewFromObject(View view, JObject @object)
        {
            return view == @object;
          //  throw new NotImplementedException();
        }

        // 从容器中销毁指定位置的页面
        public void destroyItem(ViewGroup container, int position, JObject @object)
        {
          //  container.removeView(mViewList.get(position));
            container.RemoveView(mViewList[position]);
        }

        // 实例化指定位置的页面，并将其添加到容器中
        public JObject instantiateItem(ViewGroup container, int position)
        {
           // container.addView(mViewList.get(position));
            container.AddView(mViewList[position]);
            return mViewList[position];
        }

        // 获得指定页面的标题文本
        public string getPageTitle(int position)
        {
            return mGoodsList[position].name;
        }

        //public CharSequence getPageTitle(int position)
        //{
        //    return mGoodsList.get(position).name;
        //}
    }
}