using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using junior.util;

namespace junior
{
    [Activity(Label = "CaptureActivity")]
    public class CaptureActivity : Activity, View.IOnClickListener, View.IOnLongClickListener
    {
        private TextView tv_capture; // 声明一个文本视图对象
        private ImageView iv_capture; // 声明一个图像视图对象



        public bool OnLongClick(View v)
        {

            // 长按了按钮btn_chat，则清空文本视图tv_capture
            if (v.Id == Resource.Id.btn_chat)
            {
                tv_capture.Text = "";
            }
            return true;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_capture);
            tv_capture = FindViewById<TextView>(Resource.Id.tv_capture);
            // 从布局文件中获取名叫iv_capture的图像视图
            iv_capture = FindViewById<ImageView>(Resource.Id.iv_capture);
            // 开启文本视图tv_capture的绘图缓存
            //  tv_capture.SetDrawingCacheEnabled(true);
            tv_capture.DrawingCacheEnabled = true;
            // 从布局文件中获取名叫btn_chat的按钮
            Button btn_chat = FindViewById<Button>(Resource.Id.btn_chat);
            // 从布局文件中获取名叫btn_capture的按钮
            Button btn_capture = FindViewById<Button>(Resource.Id.btn_capture);
            // 给btn_chat设置点击监听器
            btn_chat.SetOnClickListener(this);
            // 给btn_chat设置长按监听器
            btn_chat.SetOnLongClickListener(this);
            // 给btn_capture设置点击监听器
            btn_capture.SetOnClickListener(this);
        }
        private string[] mChatStr = { "你吃饭了吗？", "今天天气真好呀。", "我中奖啦！", "我们去看电影吧。", "晚上干什么好呢？" };
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_chat)
            { // 点击了聊天按钮，则给文本视图添加聊天文字
                Random ran = new Random();
                int random = ran.Next(0, 4);
                // 拼接聊天的文本内容
                string newStr = string.Format("{0}\n{1} {2}",
                        tv_capture.Text, DateUtil.getNowDateTime1(), mChatStr[random]);
                // 设置文本视图tv_bbs的文本内容
                tv_capture.Text = newStr;
            }
            else if (v.Id == Resource.Id.btn_capture)
            { // 点击了截图按钮，则将截图信息显示在图像视图上
              // 从文本视图tv_capture的绘图缓存中获取位图对象
              //  Bitmap bitmap = tv_capture.DrawingCache();
                Bitmap bitmap = tv_capture.DrawingCache;
                // 给图像视图iv_capture设置位图对象
                //  iv_capture.setImageBitmap(bitmap);
                iv_capture.SetImageBitmap(bitmap);
                // 注意这里在截图完毕后不能马上关闭绘图缓存，因为画面渲染需要时间，
                // 如果立即关闭缓存，渲染画面就会找不到位图对象，会报错：
                // “java.lang.IllegalArgumentException: Cannot draw recycled bitmaps”。
                // 所以要等界面渲染完成后再关闭绘图缓存，下面的做法是延迟200毫秒再关闭
                //    mHandler.postDelayed(mResetCache, 200);
                //    mHandler.PostDelayed(mResetCache, 200);
                IRunnable run = new Runnable(() => {
                    //do what  you want
                   
                    tv_capture.DrawingCacheEnabled=false;
                    tv_capture.DrawingCacheEnabled=true;
                    //        // 开启文本视图tv_capture的绘图缓存
                    //        tv_capture.setDrawingCacheEnabled(true);
                });

            }

        }

    //    private Handler mHandler = new Handler(); // 声明一个任务处理器
    //    private Runnable mResetCache = new Runnable() {
    //    @Override
    //    public void run()
    //    {
    //        // 关闭文本视图tv_capture的绘图缓存
    //        tv_capture.setDrawingCacheEnabled(false);
    //        // 开启文本视图tv_capture的绘图缓存
    //        tv_capture.setDrawingCacheEnabled(true);
    //    }
    //};  //等效上面的代码
 

    }
}